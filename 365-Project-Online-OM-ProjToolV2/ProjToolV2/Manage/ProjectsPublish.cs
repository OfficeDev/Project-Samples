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
    public partial class ProjectsPublish : BaseForm
    {
        private BackgroundExecutorWithStatus _backgroundExecutorWithStatus;

        public ProjectsPublish()
        {
            InitializeComponent();
            Icon = Resources.Project;
        }

        private void ProjectsPublish_Load(object sender, EventArgs e)
        {
            LV_Projects.View = View.Details;
            LV_Projects.Alignment = ListViewAlignment.SnapToGrid;
            LV_Projects.GridLines = true;
            LV_Projects.FullRowSelect = true;
            LV_Projects.Scrollable = true;
            LV_Projects.HideSelection = false;
            LV_Projects.FullRowSelect = true;
            LV_Projects.ColumnClick += ControlHelpers.SortListView;
            LoadProjects();
        }

        private void BTN_Publish_Click(object sender, EventArgs e)
        {
            PublishSelectedProjects();
        }

        #region Project

        private void LoadProjects()
        {
            _backgroundExecutorWithStatus = new BackgroundExecutorWithStatus(TB_Status, "Querying for all Enterprise projects");
            _backgroundExecutorWithStatus.ExecuteWorker(LoadProjectsList);
        }

        private void LoadProjectsList()
        {
            LV_Projects.InvokeIfRequired(s =>
            {
                s.Items.Clear();
                s.Columns.Clear();
                s.Columns.Add(new ColumnHeader { Text = "Id", DisplayIndex = 0, Width = 20 });
                s.Columns.Add(new ColumnHeader { Text = "Name", DisplayIndex = 0, Width = 20 });
                s.Columns.Add(new ColumnHeader { Text = "Owner", DisplayIndex = 0, Width = 20 });
                s.Columns.Add(new ColumnHeader { Text = "CheckOut by", DisplayIndex = 0, Width = 20 });
                s.Columns.Add(new ColumnHeader { Text = "Published Date", DisplayIndex = 0, Width = 20 });
                s.Columns.Add(new ColumnHeader { Text = "Updated Date", DisplayIndex = 0, Width = 20 });
                s.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                s.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            });

            IEnumerable<PublishedProject> projectList =
                ProjContext.LoadQuery(ProjContext.Projects.Include(p => p.Name, p => p.Id, p => p.IsCheckedOut,
                    p => p.CheckedOutBy.LoginName, p => p.LastPublishedDate, p => p.Owner.LoginName,
                    p => p.Draft.LastSavedDate));
            ProjContext.ExecuteQuery();

            List<ListViewItem> listViewItems = new List<ListViewItem>();
            foreach (PublishedProject proj in projectList)
            {
                ListViewItem lvi = new ListViewItem(proj.Id.ToString());
                lvi.SubItems.Add(proj.Name);
                lvi.SubItems.Add(proj.Owner.LoginName);
                lvi.SubItems.Add(proj.IsCheckedOut ? proj.CheckedOutBy.LoginName : string.Empty);
                lvi.SubItems.Add(proj.LastPublishedDate.ToString(CultureInfo.InvariantCulture));
                lvi.SubItems.Add(proj.Draft.LastSavedDate.ToString(CultureInfo.InvariantCulture));
                lvi.Tag = proj;
                listViewItems.Add(lvi);
            }
            LV_Projects.InvokeIfRequired(s =>
            {
                s.Items.AddRange(listViewItems.ToArray());
                s.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                s.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            });
        }

        private void PublishSelectedProjects()
        {
            _backgroundExecutorWithStatus = new BackgroundExecutorWithStatus(TB_Status, "Publishing Enterprise Projects");
            _backgroundExecutorWithStatus.ExecuteWorker(PublishProjects);
        }

        private void PublishProjects()
        {
            List<PublishedProject> projectList = new List<PublishedProject>();

            LV_Projects.InvokeIfRequired(s =>
            {
                ListView.SelectedListViewItemCollection selectedItems = s.SelectedItems;
                projectList.AddRange(selectedItems.Cast<ListViewItem>().Select(selectedItem => (PublishedProject)selectedItem.Tag));
            });
            if (!projectList.Any()) return;
            List<QueueJob> jobs = projectList.Select(p =>
            {
                if (!p.IsCheckedOut)
                {
                    p.CheckOut();
                }
                Log.WriteVerbose(new SourceInfo(), TB_Status, "Publishing project:{0}.", p.Name);
                QueueJob job = p.Draft.Publish(true);
                return job;
            }).ToList();
            Log.WriteVerbose(new SourceInfo(), TB_Status, _backgroundExecutorWithStatus, "Waiting for the Publish queue job to complete.");
            CsomHelper.ExecuteAndWait(jobs, TB_Status);
            Log.WriteVerbose(new SourceInfo(), TB_Status, _backgroundExecutorWithStatus, "Refreshing Projects.");
            LoadProjects();
        }

        #endregion Project

        private void BTN_Back_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void BTN_Cancel_Click(object sender, EventArgs e)
        {
            _backgroundExecutorWithStatus?.Cancel();
        }
    }
}