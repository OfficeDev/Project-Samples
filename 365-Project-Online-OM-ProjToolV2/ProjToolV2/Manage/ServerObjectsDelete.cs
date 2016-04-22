/*
 * Copyright (c) Microsoft Corporation. All rights reserved. Licensed under the MIT license.
 * See LICENSE in the project root for license information.
 */

using Microsoft.ProjectServer.Client;
using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Calendar = Microsoft.ProjectServer.Client.Calendar;
using Resources = ProjToolV2.Properties.Resources;
using View = System.Windows.Forms.View;

namespace ProjToolV2
{
    public partial class ServerObjectsDelete : BaseForm
    {
        private List<BackgroundExecutorWithStatus> _bgws = new List<BackgroundExecutorWithStatus>();
        private ServerObjectType _selectedServerObject = ServerObjectType.Project;

        public ServerObjectsDelete()
        {
            InitializeComponent();
            Icon = Resources.Project;
        }

        private void ServerObjectsDelete_Load(object sender, EventArgs e)
        {
            LV_ServerObjects.View = View.Details;
            LV_ServerObjects.Alignment = ListViewAlignment.SnapToGrid;
            LV_ServerObjects.GridLines = true;
            LV_ServerObjects.FullRowSelect = true;
            LV_ServerObjects.Scrollable = true;
            LV_ServerObjects.HideSelection = false;
            LV_ServerObjects.FullRowSelect = true;
            PropulateServerObjects();
        }

        private void PropulateServerObjects()
        {
            _bgws.ForEach(s =>
                {
                    if (!s.ActionTask.IsCompleted)
                    {
                        s.Cancel();
                    }
                });
            _bgws = new List<BackgroundExecutorWithStatus>();
            switch (_selectedServerObject)
            {
                case ServerObjectType.Resource:
                    LoadResources();
                    break;

                case ServerObjectType.Calendar:
                    LoadCalendars();
                    break;

                case ServerObjectType.CustomField:
                    LoadCustomFields();
                    break;

                case ServerObjectType.LookupTable:
                    LoadLookupTables();
                    break;

                default:
                    LoadProjects();
                    break;
            }
        }

        private void LoadLookupTables()
        {
            BackgroundExecutorWithStatus bgeLookupTables = new BackgroundExecutorWithStatus(TB_Status, "Querying for Enterprise LookupTables");
            _bgws.Add(bgeLookupTables);
            bgeLookupTables.ExecuteWorker(LoadLookupTablesList);
        }

        private void LoadLookupTablesList()
        {
            LV_ServerObjects.InvokeIfRequired(s =>
            {
                s.Items.Clear();
                s.Columns.Clear();
                s.Columns.Add(new ColumnHeader { Text = "Id", DisplayIndex = 0, Width = 20 });
                s.Columns.Add(new ColumnHeader { Text = "Name", DisplayIndex = 0, Width = 20 });
                s.Columns.Add(new ColumnHeader { Text = "Type", DisplayIndex = 0, Width = 20 });
                s.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                s.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            });

            IEnumerable<LookupTable> lookupFieldList = ProjContext.LoadQuery(ProjContext.LookupTables.Include(r => r.Name, r => r.Id, r => r.FieldType));
            ProjContext.ExecuteQuery();
            List<ListViewItem> listViewItems = new List<ListViewItem>();
            foreach (LookupTable lt in lookupFieldList)
            {
                ListViewItem lvi = new ListViewItem(lt.Id.ToString());
                lvi.SubItems.Add(lt.Name);
                lvi.SubItems.Add(lt.FieldType.ToString());
                lvi.Tag = lt;
                listViewItems.Add(lvi);
            }
            LV_ServerObjects.InvokeIfRequired(s =>
            {
                s.Items.AddRange(listViewItems.ToArray());
                s.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                s.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            });
        }

        private void LoadCustomFields()
        {
            BackgroundExecutorWithStatus bgeCustomFields = new BackgroundExecutorWithStatus(TB_Status, "Querying for Enterprise Custom Fields");
            _bgws.Add(bgeCustomFields);
            bgeCustomFields.ExecuteWorker(LoadCustomFieldsList);
        }

        private void LoadCustomFieldsList()
        {
            LV_ServerObjects.InvokeIfRequired(s =>
            {
                s.Items.Clear();
                s.Columns.Clear();
                s.Columns.Add(new ColumnHeader { Text = "Id", DisplayIndex = 0, Width = 20 });
                s.Columns.Add(new ColumnHeader { Text = "Name", DisplayIndex = 0, Width = 20 });
                s.Columns.Add(new ColumnHeader { Text = "Type", DisplayIndex = 0, Width = 20 });
                s.Columns.Add(new ColumnHeader { Text = "Required", DisplayIndex = 0, Width = 20 });
                s.Columns.Add(new ColumnHeader { Text = "LookupTable", DisplayIndex = 0, Width = 20 });
                s.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                s.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            });

            IEnumerable<CustomField> customFieldList = ProjContext.LoadQuery(ProjContext.CustomFields.Include(r => r.Name, r => r.EntityType.Name, r => r.Id, r => r.IsRequired, r => r.LookupTable.Name));
            ProjContext.ExecuteQuery();
            List<ListViewItem> listViewItems = new List<ListViewItem>();
            foreach (CustomField cf in customFieldList)
            {
                ListViewItem lvi = new ListViewItem(cf.Id.ToString());
                lvi.SubItems.Add(cf.Name);
                lvi.SubItems.Add(cf.EntityType.Name);
                lvi.SubItems.Add(cf.IsRequired.ToString());
                if (cf.LookupTable.ServerObjectIsNull != null && !cf.LookupTable.ServerObjectIsNull.Value)
                {
                    lvi.SubItems.Add(cf.LookupTable.Name);
                }
                lvi.Tag = cf;
                listViewItems.Add(lvi);
            }
            LV_ServerObjects.InvokeIfRequired(s =>
            {
                s.Items.AddRange(listViewItems.ToArray());
                s.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                s.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            });
        }

        private BackgroundExecutorWithStatus _bgeCalendars;

        private void LoadCalendars()
        {
            _bgeCalendars = new BackgroundExecutorWithStatus(TB_Status, "Querying for Enterprise Calendars");
            _bgws.Add(_bgeCalendars);
            _bgeCalendars.ExecuteWorker(LoadCalendarsList);
        }

        private void LoadCalendarsList()
        {
            LV_ServerObjects.InvokeIfRequired(s =>
            {
                s.Items.Clear();
                s.Columns.Clear();
                s.Columns.Add(new ColumnHeader { Text = "Id", DisplayIndex = 0, Width = 20 });
                s.Columns.Add(new ColumnHeader { Text = "Name", DisplayIndex = 0, Width = 20 });
                s.Columns.Add(new ColumnHeader { Text = "Changed Date", DisplayIndex = 0, Width = 20 });
                s.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                s.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            });

            IEnumerable<Calendar> calendarList = ProjContext.LoadQuery(ProjContext.Calendars.Include(r => r.Name, r => r.Id, r => r.Modified));
            ProjContext.ExecuteQuery();
            List<ListViewItem> listViewItems = new List<ListViewItem>();
            foreach (Calendar cal in calendarList)
            {
                ListViewItem lvi = new ListViewItem(cal.Id.ToString());
                lvi.SubItems.Add(cal.Name);
                lvi.SubItems.Add(cal.Modified.ToString(CultureInfo.InvariantCulture));
                lvi.Tag = cal;
                listViewItems.Add(lvi);
            }
            LV_ServerObjects.InvokeIfRequired(s =>
            {
                s.Items.AddRange(listViewItems.ToArray());
                s.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                s.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            });
        }

        private BackgroundExecutorWithStatus _bgeResource;

        private void LoadResources()
        {
            _bgeResource = new BackgroundExecutorWithStatus(TB_Status, "Querying for all Enterprise Resources");
            _bgws.Add(_bgeResource);
            _bgeResource.ExecuteWorker(LoadResourcesList);
        }

        private void LoadResourcesList()
        {
            LV_ServerObjects.InvokeIfRequired(s =>
            {
                s.Items.Clear();
                s.Columns.Clear();
                s.Columns.Add(new ColumnHeader { Text = "Id", DisplayIndex = 0, Width = 20 });
                s.Columns.Add(new ColumnHeader { Text = "Name", DisplayIndex = 0, Width = 20 });
                s.Columns.Add(new ColumnHeader { Text = "Active", DisplayIndex = 0, Width = 20 });
                s.Columns.Add(new ColumnHeader { Text = "CheckOut", DisplayIndex = 0, Width = 20 });
                s.Columns.Add(new ColumnHeader { Text = "Modified", DisplayIndex = 0, Width = 20 });
                s.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                s.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            });

            IEnumerable<EnterpriseResource> resourcesList = ProjContext.LoadQuery(ProjContext.EnterpriseResources.Include(p => p.Name, p => p.Id, p => p.IsCheckedOut, p => p.Modified, p => p.IsActive));
            ProjContext.ExecuteQuery();
            List<ListViewItem> listViewItems = new List<ListViewItem>();
            foreach (EnterpriseResource res in resourcesList)
            {
                ListViewItem lvi = new ListViewItem(res.Id.ToString());
                lvi.SubItems.Add(res.Name);
                lvi.SubItems.Add(res.IsActive.ToString());
                lvi.SubItems.Add(res.IsCheckedOut.ToString());
                lvi.SubItems.Add(res.Modified.ToString(CultureInfo.InvariantCulture));
                lvi.Tag = res;
                listViewItems.Add(lvi);
            }
            LV_ServerObjects.InvokeIfRequired(s =>
            {
                s.Items.AddRange(listViewItems.ToArray());
                s.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                s.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            });
        }

        private void BTN_Projects_Click(object sender, EventArgs e)
        {
            _selectedServerObject = ServerObjectType.Project;
            PropulateServerObjects();
        }

        private void BTN_Resources_Click(object sender, EventArgs e)
        {
            _selectedServerObject = ServerObjectType.Resource;
            PropulateServerObjects();
        }

        private void BTN_Calendars_Click(object sender, EventArgs e)
        {
            _selectedServerObject = ServerObjectType.Calendar;
            PropulateServerObjects();
        }

        private void BTN_CustomFields_Click(object sender, EventArgs e)
        {
            _selectedServerObject = ServerObjectType.CustomField;
            PropulateServerObjects();
        }

        private void BTN_LookupTables_Click(object sender, EventArgs e)
        {
            _selectedServerObject = ServerObjectType.LookupTable;
            PropulateServerObjects();
        }

        private void BTN_Delete_Click(object sender, EventArgs e)
        {
            _bgws.ForEach(s => s.Cancel());
            _bgws = new List<BackgroundExecutorWithStatus>();
            switch (_selectedServerObject)
            {
                case ServerObjectType.Resource:
                    DeleteSelectedResources();
                    break;

                case ServerObjectType.Calendar:
                    DeleteSelectedCalendars();
                    break;

                case ServerObjectType.CustomField:
                    DeleteSelectedCustomFields();
                    break;

                case ServerObjectType.LookupTable:
                    DeleteSelectedLookupTables();
                    break;

                default:
                    DeleteSelectedProjects();
                    break;
            }
        }

        private BackgroundExecutorWithStatus _bgeLookupTablesDelete;

        private void DeleteSelectedLookupTables()
        {
            _bgeLookupTablesDelete = new BackgroundExecutorWithStatus(TB_Status, "Deleting Enterprise LookupTables");
            _bgws.Add(_bgeLookupTablesDelete);
            _bgeLookupTablesDelete.ExecuteWorker(DeleteLookupTables);
        }

        private void DeleteLookupTables()
        {
            List<LookupTable> lookupTableList = new List<LookupTable>();

            LV_ServerObjects.InvokeIfRequired(s =>
            {
                ListView.SelectedListViewItemCollection selectedItems = s.SelectedItems;
                lookupTableList.AddRange(selectedItems.Cast<ListViewItem>().Select(selectedItem => (LookupTable)selectedItem.Tag));
            });

            if (!lookupTableList.Any()) return;
            lookupTableList.ForEach(lt =>
            {
                lt.DeleteObject();
            });

            ProjContext.ExecuteQuery();
            LoadLookupTables();
        }

        private BackgroundExecutorWithStatus _bgeCustomFieldsDelete;

        private void DeleteSelectedCustomFields()
        {
            _bgeCustomFieldsDelete = new BackgroundExecutorWithStatus(TB_Status, "Deleting Enterprise Custom Fields");
            _bgws.Add(_bgeCustomFieldsDelete);
            _bgeCustomFieldsDelete.ExecuteWorker(DeleteCustomFields);
        }

        private void DeleteCustomFields()
        {
            List<CustomField> customFieldList = new List<CustomField>();

            LV_ServerObjects.InvokeIfRequired(s =>
            {
                ListView.SelectedListViewItemCollection selectedItems = s.SelectedItems;
                customFieldList.AddRange(selectedItems.Cast<ListViewItem>().Select(selectedItem => (CustomField)selectedItem.Tag));
            });

            if (!customFieldList.Any()) return;
            customFieldList.ForEach(cf => cf.DeleteObject());
            ProjContext.ExecuteQuery();
            LoadCustomFields();
        }

        private BackgroundExecutorWithStatus _bgeCalendarsDelete;

        private void DeleteSelectedCalendars()
        {
            _bgeCalendarsDelete = new BackgroundExecutorWithStatus(TB_Status, "Deleting Enterprise Calendars");
            _bgws.Add(_bgeCalendarsDelete);
            _bgeCalendarsDelete.ExecuteWorker(DeleteCalendars);
        }

        private void DeleteCalendars()
        {
            List<Calendar> calendarList = new List<Calendar>();

            LV_ServerObjects.InvokeIfRequired(s =>
            {
                ListView.SelectedListViewItemCollection selectedItems = s.SelectedItems;
                calendarList.AddRange(selectedItems.Cast<ListViewItem>().Select(selectedItem => (Calendar)selectedItem.Tag));
            });
            if (!calendarList.Any()) return;
            calendarList.ForEach(c =>
            {
                c.DeleteObject();
            });

            ProjContext.ExecuteQuery();
            LoadCalendars();
        }

        private BackgroundExecutorWithStatus _bgeResourcesDelete;

        private void DeleteSelectedResources()
        {
            _bgeResourcesDelete = new BackgroundExecutorWithStatus(TB_Status, "Deleting Enterprise Resources");
            _bgws.Add(_bgeResourcesDelete);
            _bgeResourcesDelete.ExecuteWorker(DeleteResources);
        }

        private void DeleteResources()
        {
            List<EnterpriseResource> resourceList = new List<EnterpriseResource>();

            LV_ServerObjects.InvokeIfRequired(s =>
            {
                ListView.SelectedListViewItemCollection selectedItems = s.SelectedItems;
                resourceList.AddRange(selectedItems.Cast<ListViewItem>().Select(selectedItem => (EnterpriseResource)selectedItem.Tag));
            });
            if (!resourceList.Any()) return;
            resourceList.ForEach(r =>
            {
                if (r.IsCheckedOut)
                {
                    Log.WriteVerbose(new SourceInfo(), TB_Status, "Checking in resource:{0}.", r.Name);
                    r.ForceCheckIn();
                }
                Log.WriteVerbose(new SourceInfo(), TB_Status, "Deleting resource:{0}.", r.Name);
                r.DeleteObject();
            });

            ProjContext.EnterpriseResources.Update();
            ProjContext.ExecuteQuery();

            Log.WriteVerbose(new SourceInfo(), TB_Status, _bgeResourcesDelete, "Refreshing Resources");
            LoadResources();
        }

        #region Project

        private BackgroundExecutorWithStatus _bgeProjects;

        private void LoadProjects()
        {
            _bgeProjects = new BackgroundExecutorWithStatus(TB_Status, "Querying for all Enterprise projects");
            _bgws.Add(_bgeProjects);
            _bgeProjects.ExecuteWorker(LoadProjectsList);
        }

        private void LoadProjectsList()
        {
            LV_ServerObjects.InvokeIfRequired(s =>
            {
                s.Items.Clear();
                s.Columns.Clear();
                s.Columns.Add(new ColumnHeader { Text = "Name", DisplayIndex = 0, Width = 20 });
                s.Columns.Add(new ColumnHeader { Text = "CheckOut", DisplayIndex = 0, Width = 20 });
                s.Columns.Add(new ColumnHeader { Text = "Owner", DisplayIndex = 0, Width = 30 });
                s.Columns.Add(new ColumnHeader { Text = "CheckOut By", DisplayIndex = 0, Width = 20 });
                s.Columns.Add(new ColumnHeader { Text = "CheckOut Date", DisplayIndex = 0, Width = 20 });
                s.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                s.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            });

            IEnumerable<PublishedProject> projectList = ProjContext.LoadQuery(ProjContext.Projects.Include(p => p.Name, p => p.Id, p => p.IsCheckedOut, p => p.Owner.LoginName, p => p.CheckedOutBy.LoginName, p => p.CheckedOutDate));
            ProjContext.ExecuteQuery();

            List<ListViewItem> listViewItems = new List<ListViewItem>();
            foreach (PublishedProject project in projectList)
            {
                ListViewItem lvi = new ListViewItem(project.Name);
                lvi.SubItems.Add(project.IsCheckedOut.ToString());
                lvi.SubItems.Add(project.Owner.LoginName);
                if (project.IsCheckedOut)
                {
                    lvi.SubItems.Add(project.CheckedOutBy.LoginName);
                    lvi.SubItems.Add(project.CheckedOutDate.ToString(CultureInfo.InvariantCulture));
                }
                lvi.Tag = project;
                listViewItems.Add(lvi);
            }
            LV_ServerObjects.InvokeIfRequired(s =>
            {
                s.Items.AddRange(listViewItems.ToArray());
                s.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                s.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            });
        }

        private BackgroundExecutorWithStatus _bgeProjectsDelete;

        private void DeleteSelectedProjects()
        {
            _bgeProjectsDelete = new BackgroundExecutorWithStatus(TB_Status, "Deleting Enterprise Projects");
            _bgws.Add(_bgeProjectsDelete);
            _bgeProjectsDelete.ExecuteWorker(DeleteProjects);
        }

        private void DeleteProjects()
        {
            List<PublishedProject> projectList = new List<PublishedProject>();

            LV_ServerObjects.InvokeIfRequired(s =>
            {
                ListView.SelectedListViewItemCollection selectedItems = s.SelectedItems;
                projectList.AddRange(selectedItems.Cast<ListViewItem>().Select(selectedItem => (PublishedProject)selectedItem.Tag));
            });
            if (!projectList.Any()) return;
            int projectCounter = 1;
            List<QueueJob> jobs = projectList.Select(p =>
            {
                if (p.IsCheckedOut)
                {
                    QueueJob checkinJob = p.Draft.CheckIn(true);

                    CsomHelper.ExecuteAndWait(checkinJob, TB_Status);
                }

                QueueJob job = p.DeleteObject();
                Log.WriteVerbose(new SourceInfo(), TB_Status, "Deleting project {0} of {1} with name {2}.", projectCounter++, projectList.Count, p.Name);
                return job;
            }).ToList();

            Log.WriteVerbose(new SourceInfo(), TB_Status, _bgeProjectsDelete, "Waiting for the Delete queue job to complete.");
            CsomHelper.ExecuteAndWait(jobs, TB_Status);
            Log.WriteVerbose(new SourceInfo(), TB_Status, _bgeProjectsDelete, "Refreshing Projects.");
            LoadProjectsList();
        }

        #endregion Project

        private void BTN_Back_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void BTN_Cancel_Click(object sender, EventArgs e)
        {
            _bgws.ForEach(s => s.Cancel());
            _bgws = new List<BackgroundExecutorWithStatus>();
        }
    }
}