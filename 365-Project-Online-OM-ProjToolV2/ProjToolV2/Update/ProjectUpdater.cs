/*
 * Copyright (c) Microsoft Corporation. All rights reserved. Licensed under the MIT license.
 * See LICENSE in the project root for license information.
 */

using Microsoft.ProjectServer.Client;
using Microsoft.SharePoint.Client;
using ProjToolV2.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Resources = ProjToolV2.Properties.Resources;

namespace ProjToolV2
{
    public partial class ProjectUpdater : BaseForm
    {
        private readonly string[] _fieldsToExclude =
        {
            "ObjectVersion", "ServerObjectIsNull", "Tag", "Item",
            "FieldValues", "IncludeCustomFields", "ProjectSummaryTask"
        };

        private PublishedProject _publishedProject;
        private IEnumerable<Calendar> _calendars;
        private IEnumerable<EnterpriseResource> _enterpriseResources;
        private DateTimePicker _dateTimePicker;

        private DataGridViewComboBoxCell _dgvComboCell = new DataGridViewComboBoxCell
        {
            DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing,
            FlatStyle = FlatStyle.Flat
        };

        public ProjectUpdater()
        {
            Icon = Resources.Project;
            InitializeComponent();
            DGV_Tasks.ShowCellToolTips = false;
            DGV_Assignments.ShowCellToolTips = false;
            DGV_Resources.ShowCellToolTips = false;
        }

        private void ProjectUpdater_Load(object sender, EventArgs e)
        {
            LoadProjectList();
        }

        private BackgroundExecutorWithStatus _backgroundExecutorWithStatus;

        private void LoadProjectList()
        {
            _backgroundExecutorWithStatus = new BackgroundExecutorWithStatus(TB_Status, "Querying for all Enterprise projects");
            _backgroundExecutorWithStatus.ExecuteWorker(LoadProjects);
        }

        private void LoadProjects()
        {
            CB_ProjectList.InvokeIfRequired(s =>
            {
                s.DataSource = null;
                s.Items.Clear();
            });

            IEnumerable<PublishedProject> projectList = CsomHelper.LoadAllProjects(
                p => p.Draft.Name, p => p.Draft, p => p.IsCheckedOut);
            Dictionary<string, PublishedProject> projList = new Dictionary<string, PublishedProject>
            {
                {"Select a Project", null}
            };
            foreach (PublishedProject project in projectList)
            {
                projList.Add(project.Draft.Name, project);
            }
            CB_ProjectList.InvokeIfRequired(s =>
            {
                CB_ProjectList.SelectedIndexChanged += CB_ProjectList_SelectedIndexChanged;
                CB_ProjectList.DropDownStyle = ComboBoxStyle.DropDown;
                CB_ProjectList.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                CB_ProjectList.AutoCompleteSource = AutoCompleteSource.ListItems;
                CB_ProjectList.DataSource = new BindingSource(projList, null);
                CB_ProjectList.DisplayMember = "Key";
                CB_ProjectList.ValueMember = "Value";
            });
        }

        private static Expression<Func<T, object>> GetExpression<T>(T clientObject, MethodInfo methodInfo,
            PropertyInfo propertyInfo)
        {
            try
            {
                ParameterExpression param = Expression.Parameter(clientObject.GetType(), "p");
                MemberExpression name = Expression.PropertyOrField(param, propertyInfo.Name);
                UnaryExpression body = Expression.Convert(name, typeof(object));
                return (Expression<Func<T, object>>)methodInfo.Invoke(null, new object[] { body, new[] { param } });
            }
            catch (Exception ex)
            {
                Log.WriteError(new SourceInfo(), "Failed creating expression for Name:{0} of Type:{1}. Exception:{2}",
                    propertyInfo.Name, propertyInfo.PropertyType.Name, ex.InnerException);
                return null;
            }
        }

        private static bool IsPrimitiveEquatable(Type t)
        {
            return (t.BaseType != null && t.BaseType.IsPrimitive) ||
                   t.Namespace.Equals("System") ||
                   t.IsPrimitive ||
                   t.IsValueType ||
                   t == typeof(Guid);
        }

        private void LoadQueryFields<T>(T clientObject) where T : ClientObject
        {
            IOrderedEnumerable<PropertyInfo> props = clientObject.GetType().GetProperties().Where(p =>
                p.ReflectedType.Namespace.Contains("Project") &&
                !_fieldsToExclude.Contains(p.Name)).OrderBy(p => p.Name);

            MethodInfo lambdaMethod = typeof(Expression)
                .GetMethods()
                .First(x => x.Name.Contains("Lambda")
                            && x.IsGenericMethod
                            && x.GetParameters().Length == 2
                            && x.GetParameters()[1].ParameterType == typeof(ParameterExpression).MakeArrayType())
                .MakeGenericMethod(typeof(Func<T, object>));
            foreach (PropertyInfo prop in props)
            {
                if (IsPrimitiveEquatable(prop.PropertyType))
                {
                    Log.WriteVerbose(new SourceInfo(), "Loading property:{0} of Type:{1}.", prop.Name, prop.PropertyType.Name);
                    Expression<Func<T, object>> expr = GetExpression(clientObject, lambdaMethod, prop);
                    if (expr != null)
                    {
                        ProjContext.Load(clientObject, expr);
                    }
                    else
                    {
                        Log.WriteWarning(new SourceInfo(), "Failed loading property:{0} of Type:{1}.", prop.Name,
                            prop.PropertyType.Name);
                    }
                }
                else if (prop.PropertyType.IsEnum)
                {
                    Log.WriteVerbose(new SourceInfo(), "Loading Enum:{0} of Type:{1}.", prop.Name, prop.PropertyType.Name);
                    Expression<Func<T, object>> expr = GetExpression(clientObject, lambdaMethod, prop);
                    if (expr != null)
                    {
                        ProjContext.Load(clientObject, expr);
                    }
                    else
                    {
                        Log.WriteWarning(new SourceInfo(), "Failed loading Enum:{0} of Type:{1}.", prop.Name,
                            prop.PropertyType.Name);
                    }
                }
                else if (prop.PropertyType.IsSubclassOf(typeof(ClientObject)) ||
                         prop.PropertyType.IsSubclassOf(typeof(ClientObjectCollection)))
                {
                    Log.WriteVerbose(new SourceInfo(), "Loading Object:{0} of Type:{1}.", prop.Name,
                        prop.PropertyType.Name);
                    Expression<Func<T, object>> expr = GetExpression(clientObject, lambdaMethod, prop);
                    if (expr != null)
                    {
                        ProjContext.Load(clientObject, expr);
                    }
                    else
                    {
                        Log.WriteWarning(new SourceInfo(), "Failed loading Object:{0} of Type:{1}.", prop.Name,
                            prop.PropertyType.Name);
                    }
                }
                else
                {
                    Log.WriteWarning(new SourceInfo(), "Unknown property type {0} for property {1}",
                        prop.PropertyType.Name, prop.Name);
                }
            }
        }

        private List<PropertyInfo> DisplayFields<T>(T clientObject) where T : ClientObject
        {
            IOrderedEnumerable<PropertyInfo> props = clientObject.GetType().GetProperties().Where(p =>
                p.ReflectedType.Namespace.Contains("Project") &&
                !_fieldsToExclude.Contains(p.Name)).OrderBy(p => p.Name);

            List<PropertyInfo> retrievedFields = new List<PropertyInfo>();
            foreach (
                PropertyInfo prop in
                    props.Where(prop => !prop.PropertyType.IsSubclassOf(typeof(ClientObjectCollection))))
            {
                if (IsPrimitiveEquatable(prop.PropertyType))
                {
                    if (clientObject.IsPropertyAvailable(prop.Name))
                    {
                        Log.WriteVerbose(new SourceInfo(), "Displaying property:{0} of Type:{1}.", prop.Name,
                            prop.PropertyType.Name);
                        retrievedFields.Add(prop);
                    }
                    else
                    {
                        Log.WriteWarning(new SourceInfo(), "Failed Displaying property:{0} of Type:{1}.", prop.Name,
                            prop.PropertyType.Name);
                    }
                }
                else if (prop.PropertyType.IsEnum)
                {
                    if (clientObject.IsPropertyAvailable(prop.Name))
                    {
                        Log.WriteVerbose(new SourceInfo(), "Displaying Enum:{0} of Type:{1}.", prop.Name,
                            prop.PropertyType.Name);

                        retrievedFields.Add(prop);
                    }
                    else
                    {
                        Log.WriteWarning(new SourceInfo(), "Failed Displaying Enum:{0} of Type:{1}.", prop.Name,
                            prop.PropertyType.Name);
                    }
                }
                else if (prop.PropertyType.IsSubclassOf(typeof(ClientObject)))
                {
                    if (clientObject.IsObjectPropertyInstantiated(prop.Name))
                    {
                        Log.WriteVerbose(new SourceInfo(), "Displaying Object:{0} of Type:{1}.", prop.Name,
                            prop.PropertyType.Name);
                        retrievedFields.Add(prop);
                    }
                    else
                    {
                        Log.WriteWarning(new SourceInfo(), "Failed Displaying Object:{0} of Type:{1}.", prop.Name,
                            prop.PropertyType.Name);
                    }
                }
                else
                {
                    Log.WriteWarning(new SourceInfo(), "Unknown property type {0} for property {1}", prop.PropertyType.Name,
                        prop.Name);
                }
            }
            return retrievedFields;
        }

        private void LoadProjectInfo()
        {
            DGV_Project.InvokeIfRequired(dg =>
            {
                dg.Columns.Clear();
                dg.DataSource = null;
                dg.AllowUserToAddRows = false;
            });

            CB_ProjectList.InvokeIfRequired(cb => _publishedProject = cb.SelectedValue as PublishedProject);
            if (_publishedProject == null) return;

            if (Settings.Default.LoadAllProperties)
            {
                LoadQueryFields(_publishedProject.Draft);
            }
            else
            {
                ProjContext.Load(_publishedProject.Draft, p => p, p => p.Tasks, p => p.Assignments, p => p.ProjectResources);
            }
            ProjContext.ExecuteQuery();
            List<PropertyInfo> retrievedFields = DisplayFields(_publishedProject.Draft);
            DataTable dt = CreateDataTableForDisplay(retrievedFields);
            dt.ExtendedProperties.Add(dt.Rows.Count, _publishedProject.Draft);
            DataRow dr = dt.NewRow();
            retrievedFields.ForEach(prop => SetPropertyValueInDataColumn(dr, prop, _publishedProject.Draft));
            dt.Rows.Add(dr);

            DGV_Project.InvokeIfRequired(dg =>
            {
                dg.DataSource = dt;
                dg.Refresh();
                TP_Tasks.Text = $"Tasks({_publishedProject.Draft.Tasks.Count()})";
                TP_Assignments.Text = $"Assignments({_publishedProject.Draft.Assignments.Count()})";
                TP_Resources.Text = $"Resources({_publishedProject.Draft.ProjectResources.Count()})";
                if (_publishedProject.Draft.Tasks.Any())
                {
                    LoadTasksInfo(_publishedProject.Draft.Tasks);
                }
                if (_publishedProject.Draft.Assignments.Any())
                {
                    LoadAssignments(_publishedProject.Draft.Assignments);
                }
                if (_publishedProject.Draft.ProjectResources.Any())
                {
                    LoadProjectResources(_publishedProject.Draft.ProjectResources);
                }
            });
        }

        private static DataTable CreateDataTableForDisplay(List<PropertyInfo> retrievedFields)
        {
            DataTable dt = new DataTable();
            foreach (PropertyInfo p in retrievedFields)
            {
                DataColumn dc = new DataColumn(p.Name, p.PropertyType);
                if (!p.CanWrite)
                {
                    dc.ReadOnly = true;
                }
                dt.Columns.Add(dc);
            }
            return dt;
        }

        private static void SetPropertyValueInDataColumn(DataRow dr, PropertyInfo property, ClientObject clientObject)
        {
            object propValue = property.GetValue(clientObject);
            Log.WriteVerbose(new SourceInfo(), "Retrieved  {0}: {1}", property.Name, propValue);
            if (IsPrimitiveEquatable(property.PropertyType))
            {
                dr[property.Name] = propValue;
            }
            else
            {
                ClientObject co = (ClientObject)propValue;
                if (co.IsNull())
                {
                    dr[property.Name] = null;
                }
                else
                {
                    dr[property.Name] = co;
                }
            }
        }

        private void LoadProjectResources(DraftProjectResourceCollection drc)
        {
            DGV_Resources.InvokeIfRequired(dg =>
            {
                dg.Columns.Clear();
                dg.DataSource = null;
                dg.AllowUserToAddRows = false;
            });
            List<PropertyInfo> retrievedFields = DisplayFields(drc.FirstOrDefault());
            DataTable dt = CreateDataTableForDisplay(retrievedFields);

            foreach (DraftProjectResource draftResource in drc)
            {
                dt.ExtendedProperties.Add(dt.Rows.Count, draftResource);
                DataRow dr = dt.NewRow();
                retrievedFields.ForEach(prop => SetPropertyValueInDataColumn(dr, prop, draftResource));
                dt.Rows.Add(dr);
            }
            DGV_Resources.InvokeIfRequired(dg =>
            {
                dg.DataSource = dt;
                dg.Refresh();
            });
        }

        private void LoadAssignments(DraftAssignmentCollection dac)
        {
            DGV_Assignments.InvokeIfRequired(dg =>
            {
                dg.Columns.Clear();
                dg.DataSource = null;
                dg.AllowUserToAddRows = false;
            });
            List<PropertyInfo> retrievedFields = DisplayFields(dac.FirstOrDefault());
            DataTable dt = CreateDataTableForDisplay(retrievedFields);
            foreach (DraftAssignment draftAssignment in dac)
            {
                dt.ExtendedProperties.Add(dt.Rows.Count, draftAssignment);
                DataRow dr = dt.NewRow();
                retrievedFields.ForEach(prop => SetPropertyValueInDataColumn(dr, prop, draftAssignment));
                dt.Rows.Add(dr);
            }
            DGV_Assignments.InvokeIfRequired(dg =>
            {
                dg.DataSource = dt;
                dg.Refresh();
            });
        }

        private void LoadTasksInfo(DraftTaskCollection dtc)
        {
            DGV_Tasks.InvokeIfRequired(dg =>
            {
                dg.Columns.Clear();
                dg.DataSource = null;
                dg.AllowUserToAddRows = false;
            });
            List<PropertyInfo> retrievedFields = DisplayFields(dtc.FirstOrDefault());
            DataTable dt = CreateDataTableForDisplay(retrievedFields);

            foreach (DraftTask draftTask in dtc)
            {
                dt.ExtendedProperties.Add(dt.Rows.Count, draftTask);
                DataRow dr = dt.NewRow();
                retrievedFields.ForEach(prop => SetPropertyValueInDataColumn(dr, prop, draftTask));
                dt.Rows.Add(dr);
            }
            DGV_Tasks.InvokeIfRequired(dg =>
            {
                dg.DataSource = dt;
                dg.Refresh();
            });
        }

        private BackgroundExecutorWithStatus _beProjectLoad;

        private void CB_ProjectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_ProjectList.SelectedIndex == 0)
            {
                DGV_Tasks.Columns.Clear();
                DGV_Tasks.DataSource = null;
                DGV_Tasks.AllowUserToAddRows = false;
                DGV_Assignments.Columns.Clear();
                DGV_Assignments.DataSource = null;
                DGV_Assignments.AllowUserToAddRows = false;
                DGV_Resources.Columns.Clear();
                DGV_Resources.DataSource = null;
                DGV_Resources.AllowUserToAddRows = false;
                DGV_Project.Columns.Clear();
                DGV_Project.DataSource = null;
                DGV_Project.AllowUserToAddRows = false;
                TP_Tasks.Text = "Tasks";
                TP_Assignments.Text = "Assignments";
                TP_Resources.Text = "Resources";
            }
            else
            {
                _beProjectLoad = new BackgroundExecutorWithStatus(TB_Status, "Querying for Project info");
                _beProjectLoad.ExecuteWorker(LoadProjectInfo);
            }
        }

        private void DataGridViewCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null) return;
            DataGridViewCell dgvCell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (dgvCell.ReadOnly)
            {
                dgvCell.Style.BackColor = SystemColors.ControlLight;
            }

            if (dgvCell.Value == null) return;
            //dgvCell.Tag = dgvCell.Value;
            Type t = dgvCell.Value.GetType();
            if (!t.IsSubclassOf(typeof(ClientObject))) return;
            if (t.Name.Contains("Calendar") || t.Name.Contains("EnterpriseProjectType") || t.Name.Contains("Phase"))
            {
                e.Value = ((ClientObject)dgvCell.Value).GetFieldValueAsString("Name");
            }
            else if (t.Name.Contains("User"))
            {
                e.Value = ((User)dgvCell.Value).Title;
            }
        }

        private void BTN_Update_Click(object sender, EventArgs e)
        {
            if (_publishedProject == null) return;
            if (!_publishedProject.IsCheckedOut)
            {
                _publishedProject.CheckOut();
            }
            QueueJob job = _publishedProject.Draft.Update();
            CsomHelper.ExecuteAndWait(job, TB_Status);
            LoadProjectInfo();
        }

        private void GridViewCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null) return;
            DataTable dt = (DataTable)dgv.DataSource;
            ClientObject co = (ClientObject)dt.ExtendedProperties[dgv.CurrentCell.OwningRow.Index];

            PropertyInfo prop =
                co.GetType()
                    .GetProperties()
                    .FirstOrDefault(p => p.Name == dgv.Columns[e.ColumnIndex].HeaderText);

            prop.SetValue(co, dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
        }

        public static Dictionary<int, string> ParseTypeToDictionary(Type type)
        {
            return Enum.GetValues(type).Cast<int>().ToDictionary(e => e, e => Enum.GetName(type, e));
        }

        private void DataGridViewDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            string txt = "Error with " +
                         DGV_Project.Columns[e.ColumnIndex].HeaderText +
                         " \n\n" + e.Exception.Message;
            Log.WriteError(new SourceInfo(), txt);
            e.Cancel = false;
        }

        private void DateTimePickerOnTextChange(object sender, EventArgs e)
        {
            var dateTimePicker = sender as DateTimePicker;
            if (dateTimePicker == null) return;
            DataGridView dgv = dateTimePicker.Parent as DataGridView;
            if (dgv == null) return;
            dgv.CurrentCell.Value = _dateTimePicker.Text;
        }

        private void DateTimePickerCloseUp(object sender, EventArgs e)
        {
            _dateTimePicker.Visible = false;
        }

        private void DataGridViewClick(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            var currentCell = dgv?.CurrentCell;
            if (currentCell == null || currentCell.ReadOnly) return;

            if (currentCell.OwningColumn.ValueType == typeof(DateTime))
            {
                Rectangle oRectangle = dgv.GetCellDisplayRectangle(currentCell.ColumnIndex, currentCell.RowIndex, true);
                _dateTimePicker = new DateTimePicker
                {
                    Format = DateTimePickerFormat.Short,
                    Size = new Size(oRectangle.Width, oRectangle.Height),
                    Location = new Point(oRectangle.X, oRectangle.Y)
                };
                if (currentCell.FormattedValue.ToString() != string.Empty) _dateTimePicker.Value = (DateTime)currentCell.Value;
                _dateTimePicker.CloseUp += DateTimePickerCloseUp;
                _dateTimePicker.TextChanged += DateTimePickerOnTextChange;
                dgv.Controls.Add(_dateTimePicker);
                _dateTimePicker.Visible = true;
            }
            else if (currentCell.OwningColumn.ValueType.IsEnum)
            {
                var enumToDictionary = ParseTypeToDictionary(currentCell.OwningColumn.ValueType);
                DataGridViewComboBoxCell dgComboCell = new DataGridViewComboBoxCell
                {
                    DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing,
                    DataSource = new BindingSource(enumToDictionary, null),
                    DisplayMember = "Value",
                    ValueMember = "Key"
                };
                dgv[currentCell.ColumnIndex, currentCell.RowIndex].ValueType = dgComboCell.ValueType;
                dgv[currentCell.ColumnIndex, currentCell.RowIndex] = dgComboCell;
            }
            else if (currentCell.OwningColumn.ValueType.IsSubclassOf(typeof(ClientObject)))
            {
                if (currentCell.OwningColumn.ValueType.Name.Contains("Calendar"))
                {
                    if (_calendars == null)
                    {
                        _calendars = ProjContext.LoadQuery(ProjContext.Calendars);
                        ProjContext.ExecuteQuery();
                    }
                    Dictionary<string, Calendar> blah = _calendars.ToDictionary(er => er.Name, er => er);
                    _dgvComboCell = new DataGridViewComboBoxCell
                    {
                        DataSource = new BindingSource(blah, null),
                        DisplayMember = "Key",
                        ValueMember = "Value",
                        ValueType = typeof(Calendar)
                    };
                    dgv[currentCell.ColumnIndex, currentCell.RowIndex] = _dgvComboCell;
                }
                else if (currentCell.OwningColumn.ValueType.Name.Contains("User"))
                {
                    if (_enterpriseResources == null)
                    {
                        _enterpriseResources = ProjContext.LoadQuery(ProjContext.EnterpriseResources.Include(p => p.User));
                        ProjContext.ExecuteQuery();
                    }

                    Dictionary<string, User> blah =
                        _enterpriseResources.Where(resource => !resource.User.IsNull())
                            .ToDictionary(resource => resource.User.Title, resource => resource.User);

                    _dgvComboCell = new DataGridViewComboBoxCell
                    {
                        DisplayMember = "Key",
                        ValueMember = "Value",
                        ValueType = typeof(User),
                        DataSource = new BindingSource(blah, null)
                    };
                    dgv[currentCell.ColumnIndex, currentCell.RowIndex] = _dgvComboCell;
                }
            }
        }

        private void DataGridViewMouseClick(object sender, MouseEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null) return;

            if (dgv.Tag.ToString().Contains("Project")) return;
            if (e.Button != MouseButtons.Right) return;
            ContextMenu m = new ContextMenu();
            m.MenuItems.Add(new MenuItem("Delete selected " + dgv.Tag, (o, ev) =>
            {
                string dgvTag = dgv.Tag.ToString();
                if (dgv.SelectedRows.Count == 0)
                {
                    Log.WriteVerbose(new SourceInfo(), TB_Status, "Select at least one {0} row to delete", dgvTag);
                    return;
                }
                DataTable dt = (DataTable)dgv.DataSource;
                foreach (DataGridViewRow dgvr in dgv.SelectedRows)
                {
                    if (dgvTag.Contains("Tasks"))
                    {
                        var task = (DraftTask)dt.ExtendedProperties[dgvr.Index];
                        task.DeleteObject();
                    }
                    else if (dgvTag.Contains("Resources"))
                    {
                        var projectResource = (DraftProjectResource)dt.ExtendedProperties[dgvr.Index];
                        projectResource.DeleteObject();
                    }
                    else if (dgvTag.Contains("Assignments"))
                    {
                        var assignment = (DraftAssignment)dt.ExtendedProperties[dgvr.Index];
                        assignment.DeleteObject();
                    }
                }
            }));
            m.Show(dgv, new Point(e.X, e.Y));
        }

        private void BTN_Publish_Click(object sender, EventArgs e)
        {
            if (_publishedProject == null) return;
            _backgroundExecutorWithStatus = new BackgroundExecutorWithStatus(TB_Status, "Publishing project " + _publishedProject.Draft.Name);
            _backgroundExecutorWithStatus.ExecuteWorker(PublishProject);
        }

        private void PublishProject()
        {
            CsomHelper.ExecuteAndWait(_publishedProject.Draft.Publish(true), TB_Status);
        }

        private void TB_FieldsFilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox filterTextBox = (TextBox)sender;
                string[] filterSplit = filterTextBox.Text.Split(",".ToCharArray());

                foreach (Control ctrl in TC_Main.SelectedTab.Controls)
                {
                    if (ctrl.GetType() != typeof(DataGridView)) continue;
                    DataGridView dataGridView = (DataGridView)ctrl;
                    foreach (DataGridViewColumn filterColumn in dataGridView.Columns)
                    {
                        if (string.IsNullOrEmpty(filterSplit[0]))
                        {
                            filterColumn.Visible = true;
                        }
                        else
                        {
                            for (int i = 0; i < filterSplit.Length && !string.IsNullOrEmpty(filterSplit[i]); i++)
                            {
                                if (!Regex.IsMatch(filterColumn.Name, filterSplit[i], RegexOptions.IgnoreCase))
                                {
                                    filterColumn.Visible = false;
                                }
                                else
                                {
                                    filterColumn.Visible = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (ArgumentException)
            {
                Log.WriteVerbose(new SourceInfo(), TB_Status, "Incorrect Regex pattern.");
            }
        }

        private void ShowToolTipOnCellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            if (e.ColumnIndex == -1)
            {
                TT_ProjectUpdate.SetToolTip(dataGridView, "Select Row and right click to delete " + dataGridView.Tag);
            }
        }

        private void BTN_Cancel_Click(object sender, EventArgs e)
        {
            Visible = false;
        }
    }
}