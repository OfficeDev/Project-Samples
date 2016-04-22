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
using Resources = ProjToolV2.Properties.Resources;
using View = System.Windows.Forms.View;

namespace ProjToolV2
{
    public partial class CheckInCheckOut : BaseForm
    {
        private bool _checkin = true;
        private BackgroundExecutorWithStatus _backgroundExecutorWithStatus;

        private ServerObjectType _selectedServerObject = ServerObjectType.Project;

        public CheckInCheckOut()
        {
            InitializeComponent();
            Icon = Resources.Project;
        }

        private void CheckInCheckOut_Load(object sender, EventArgs e)
        {
            LV_ServerObjects.Items.Clear();
            LV_ServerObjects.Columns.Clear();
            LV_ServerObjects.Columns.Add(new ColumnHeader { Text = "Name", DisplayIndex = 0, Width = 20 });
            LV_ServerObjects.Columns.Add(new ColumnHeader { Text = "CheckOut", DisplayIndex = 0, Width = 20 });
            LV_ServerObjects.Columns.Add(new ColumnHeader { Text = "Owner", DisplayIndex = 0, Width = 30 });
            LV_ServerObjects.Columns.Add(new ColumnHeader { Text = "CheckOut By", DisplayIndex = 0, Width = 20 });
            LV_ServerObjects.Columns.Add(new ColumnHeader { Text = "CheckOut Date", DisplayIndex = 0, Width = 20 });
            LV_ServerObjects.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            LV_ServerObjects.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            PropulateServerObjects();
            LV_ServerObjects.View = View.Details;
            LV_ServerObjects.Alignment = ListViewAlignment.SnapToGrid;
            LV_ServerObjects.GridLines = true;
            LV_ServerObjects.FullRowSelect = true;
            LV_ServerObjects.Scrollable = true;
            LV_ServerObjects.HideSelection = false;
            LV_ServerObjects.FullRowSelect = true;
        }

        private void PropulateServerObjects()
        {
            _backgroundExecutorWithStatus?.Cancel();

            switch (_selectedServerObject)
            {
                case ServerObjectType.Resource:
                    BTN_CheckOut.Enabled = false;
                    LoadResources();
                    break;

                default:
                    BTN_CheckOut.Enabled = true;
                    LoadProjects();
                    break;
            }
        }

        private void LoadResources()
        {
            _backgroundExecutorWithStatus = new BackgroundExecutorWithStatus(TB_Status, "Querying for all Enterprise Resources");
            _backgroundExecutorWithStatus.ExecuteWorker(LoadResourcesList);
        }

        private void LoadResourcesList()
        {
            IEnumerable<EnterpriseResource> resourcesList = ProjContext.LoadQuery(ProjContext.EnterpriseResources.Include(p => p.Name, p => p.Id, p => p.IsCheckedOut));
            ProjContext.ExecuteQuery();

            List<ListViewItem> listViewItems = new List<ListViewItem>();
            foreach (EnterpriseResource res in resourcesList)
            {
                ListViewItem lvi = new ListViewItem(res.Id.ToString());
                lvi.SubItems.Add(res.Name);
                lvi.SubItems.Add(res.IsCheckedOut.ToString());
                lvi.Tag = res;
                Log.WriteVerbose(new SourceInfo(), TB_Status, "Found Resource {0}", res.Name);
                listViewItems.Add(lvi);
            }
            LV_ServerObjects.InvokeIfRequired(s =>
            {
                s.Items.Clear();
                s.Columns.Clear();
                s.Columns.Add(new ColumnHeader { Text = "Id", DisplayIndex = 0, Width = 20 });
                s.Columns.Add(new ColumnHeader { Text = "Name", DisplayIndex = 0, Width = 20 });
                s.Columns.Add(new ColumnHeader { Text = "CheckOut", DisplayIndex = 0, Width = 20 });
                s.Items.AddRange(listViewItems.ToArray());
                s.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                s.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            });
        }

        private void CheckInSelectedResources()
        {
            _backgroundExecutorWithStatus = new BackgroundExecutorWithStatus(TB_Status, "Checking in Enterprise Resources");
            _backgroundExecutorWithStatus.ExecuteWorker(CheckInResources);
        }

        private void CheckInResources()
        {
            List<EnterpriseResource> resourceList = new List<EnterpriseResource>();

            LV_ServerObjects.InvokeIfRequired(s =>
            {
                ListView.SelectedListViewItemCollection selectedItems = s.SelectedItems;
                resourceList.AddRange(selectedItems.Cast<ListViewItem>().Select(selectedItem => (EnterpriseResource)selectedItem.Tag));
            });
            if (!resourceList.Any()) return;
            foreach (var res in resourceList.Where(r => r.IsCheckedOut))
            {
                Log.WriteVerbose(new SourceInfo(), TB_Status, "Checking in Resource {0}", res.Name);
                res.ForceCheckIn();
            }

            ProjContext.ExecuteQuery();
            Log.WriteVerbose(new SourceInfo(), TB_Status, _backgroundExecutorWithStatus, "Loading Resources");
            LoadResources();
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

        private void BTN_CheckOut_Click(object sender, EventArgs e)
        {
            _checkin = false;
            switch (_selectedServerObject)
            {
                case ServerObjectType.Resource:
                    CheckInSelectedResources();
                    break;

                default:
                    CheckInCheckOutSelectedProjects();
                    break;
            }
        }

        #region Project

        private void LoadProjects()
        {
            _backgroundExecutorWithStatus = new BackgroundExecutorWithStatus(TB_Status, "Querying for all Enterprise projects");
            _backgroundExecutorWithStatus.ExecuteWorker(LoadProjectsList);
        }

        private void LoadProjectsList()
        {
            IEnumerable<PublishedProject> projectList =
                ProjContext.LoadQuery(ProjContext.Projects.Include(p => p.Name, p => p.Id, p => p.IsCheckedOut,
                    p => p.Owner.LoginName, p => p.CheckedOutBy.LoginName, p => p.CheckedOutDate));
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
                Log.WriteVerbose(new SourceInfo(), TB_Status, "Found Project {0}", project.Name);
                listViewItems.Add(lvi);
            }
            LV_ServerObjects.InvokeIfRequired(s =>
            {
                s.Items.Clear();
                s.Columns.Clear();
                s.Columns.Add(new ColumnHeader { Text = "Name", DisplayIndex = 0, Width = 20 });
                s.Columns.Add(new ColumnHeader { Text = "CheckOut", DisplayIndex = 0, Width = 20 });
                s.Columns.Add(new ColumnHeader { Text = "Owner", DisplayIndex = 0, Width = 30 });
                s.Columns.Add(new ColumnHeader { Text = "CheckOut By", DisplayIndex = 0, Width = 20 });
                s.Columns.Add(new ColumnHeader { Text = "CheckOut Date", DisplayIndex = 0, Width = 20 });
                s.Items.AddRange(listViewItems.ToArray());
                s.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                s.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            });
        }

        private void CheckInCheckOutSelectedProjects()
        {
            string statusText = _checkin ? "Checking in Enterprise Projects" : "Checking out Enterprise Projects";
            _backgroundExecutorWithStatus = new BackgroundExecutorWithStatus(TB_Status, statusText);
            _backgroundExecutorWithStatus.ExecuteWorker(CheckInCheckoutProjects);
        }

        private void CheckInCheckoutProjects()
        {
            List<PublishedProject> projectList = new List<PublishedProject>();

            LV_ServerObjects.InvokeIfRequired(s =>
            {
                ListView.SelectedListViewItemCollection selectedItems = s.SelectedItems;
                projectList.AddRange(selectedItems.Cast<ListViewItem>().Select(selectedItem => (PublishedProject)selectedItem.Tag));
            });
            if (!projectList.Any()) return;
            if (_checkin)
            {
                List<QueueJob> jobs = projectList.Where(s => s.IsCheckedOut).Select(p =>
                  {
                      QueueJob job = null;
                      Log.WriteVerbose(new SourceInfo(), TB_Status, "Checking in Project {0}", p.Name);
                      job = p.Draft.CheckIn(true);
                      return job;
                  }).ToList();

                if (jobs.Count <= 0)
                {
                    return;
                }
                Log.WriteVerbose(new SourceInfo(), TB_Status, _backgroundExecutorWithStatus, "Waiting for the Queue jobs to complete");
                CsomHelper.ExecuteAndWait(jobs, TB_Status);
                Log.WriteVerbose(new SourceInfo(), TB_Status, _backgroundExecutorWithStatus, "Loading Projects");
                LoadProjects();
            }
            else
            {
                bool needExecute = false;
                projectList.ForEach(p =>
                {
                    if (p.IsCheckedOut) return;
                    Log.WriteVerbose(new SourceInfo(), TB_Status, "Checking out Project {0}", p.Name);
                    p.CheckOut();
                    needExecute = true;
                });
                if (needExecute)
                {
                    ProjContext.ExecuteQuery();
                    LoadProjects();
                }
                else
                {
                    Log.WriteVerbose(new SourceInfo(), TB_Status, _backgroundExecutorWithStatus,
                        "All selected projects are in checked out state.");
                }
            }
        }

        #endregion Project

        private void BTN_Back_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void BTN_CheckIn_Click(object sender, EventArgs e)
        {
            _checkin = true;
            switch (_selectedServerObject)
            {
                case ServerObjectType.Resource:
                    CheckInResources();
                    break;

                default:
                    CheckInCheckOutSelectedProjects();
                    break;
            }
        }

        private void BTN_Cancel_Click(object sender, EventArgs e)
        {
            _backgroundExecutorWithStatus?.Cancel();
        }
    }
}