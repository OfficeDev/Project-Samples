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
    public partial class ProjectOwner : BaseForm
    {
        private readonly List<BackgroundExecutorWithStatus> _bgws = new List<BackgroundExecutorWithStatus>();

        public ProjectOwner()
        {
            InitializeComponent();
            Icon = Resources.Project;
        }

        private void ProjectOwner_Load(object sender, EventArgs e)
        {
            LV_Projects.View = View.Details;
            LV_Projects.Alignment = ListViewAlignment.SnapToGrid;
            LV_Projects.FullRowSelect = true;
            LV_Projects.Scrollable = true;
            LV_Projects.HideSelection = false;
            LV_Projects.MultiSelect = true;
            LV_Projects.Columns.Add(new ColumnHeader { Text = "Projects", DisplayIndex = 0 });
            LV_Projects.Columns.Add(new ColumnHeader { Text = "Owner", DisplayIndex = 1 });
            LV_Projects.Columns.Add(new ColumnHeader { Text = "CheckedOut By", DisplayIndex = 2 });
            LV_Projects.Columns.Add(new ColumnHeader { Text = "Updated Date", DisplayIndex = 3 });
            LV_Projects.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            LV_Projects.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            LV_EnterpiseResources.View = View.Details;
            LV_EnterpiseResources.Alignment = ListViewAlignment.SnapToGrid;
            LV_EnterpiseResources.Scrollable = true;
            LV_EnterpiseResources.HideSelection = false;
            LV_EnterpiseResources.FullRowSelect = true;
            LV_EnterpiseResources.MultiSelect = false;
            LV_EnterpiseResources.Columns.Add(new ColumnHeader { Text = "Enterprise Resources", DisplayIndex = 0 });

            LV_Projects.OwnerDraw = true;
            //LV_Projects.Resize += ListView_Resize;
            LV_Projects.DrawItem += ListView_DrawItem;
            LV_Projects.DrawSubItem += ListView_DrawSubItem;
            LV_Projects.DrawColumnHeader += ControlHelpers.ListViewDrawColumnHeader;
            LV_Projects.ColumnClick += ControlHelpers.SortListView;

            LV_EnterpiseResources.OwnerDraw = true;
            LV_EnterpiseResources.Resize += ListView_Resize;
            LV_EnterpiseResources.DrawItem += ListView_DrawItem;
            LV_EnterpiseResources.DrawSubItem += ListView_DrawSubItem;
            LV_EnterpiseResources.DrawColumnHeader += ControlHelpers.ListViewDrawColumnHeader;
            LV_EnterpiseResources.ColumnClick += ControlHelpers.SortListView;
            LV_EnterpiseResources.MultiSelect = false;
            LoadProjectsAndResources();
        }

        private void LoadProjectsAndResources()
        {
            BackgroundExecutorWithStatus bgeProject = new BackgroundExecutorWithStatus(TB_Status, "Querying for all projects");
            BackgroundExecutorWithStatus bgeResource = new BackgroundExecutorWithStatus(TB_Status, "Querying for all Enterprise Resources");

            _bgws.Add(bgeProject);
            _bgws.Add(bgeResource);

            bgeProject.ExecuteWorker(LoadProjects);
            bgeResource.ExecuteWorker(LoadEnterpriseResources);
            Log.WriteVerbose(new SourceInfo(), "Loading Projects and Enterprise resources.");
        }

        private void LoadProjects()
        {
            Log.WriteVerbose(new SourceInfo(), "Loading projects");

            IEnumerable<PublishedProject> projectList = CsomHelper.LoadAllProjects(
                p => p.Name, p => p.Owner, p => p.Id, p => p.Owner.Title, p => p.IsCheckedOut, 
                p => p.CheckedOutBy.Title, p => p.Draft.LastSavedDate, p => p.Draft);
            List<ListViewItem> listViewItems = new List<ListViewItem>();
            foreach (PublishedProject project in projectList)
            {
                ListViewItem lvi = new ListViewItem(project.Name);
                lvi.SubItems.Add(project.Owner.Title);
                if (project.CheckedOutBy.IsNull())
                {
                    lvi.SubItems.Add(String.Empty);
                }
                else
                {
                    lvi.SubItems.Add(project.CheckedOutBy.Title);
                }
                lvi.SubItems.Add(project.Draft.LastSavedDate.ToString(CultureInfo.InvariantCulture));

                lvi.Tag = project;
                Log.WriteVerbose(new SourceInfo(), "Found Project:{0}", project.Name);
                listViewItems.Add(lvi);
            }
            LV_Projects.InvokeIfRequired(s =>
            {
                s.Items.Clear();
                s.Items.AddRange(listViewItems.ToArray());
                s.Columns[0].Text = $"Projects({listViewItems.Count})";
                LV_Projects.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                LV_Projects.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            });
        }

        private void LoadEnterpriseResources()
        {
            Log.WriteVerbose(new SourceInfo(), "Loading Enterprise Resources");

            LV_EnterpiseResources.InvokeIfRequired(s => s.Items.Clear());
            IEnumerable<EnterpriseResource> resourcesList = ProjContext.LoadQuery(ProjContext.EnterpriseResources.Include(r => r.Name, r => r.User));
            ProjContext.ExecuteQuery();
            List<ListViewItem> listViewItems = resourcesList.Where(r => !r.User.IsNull()).Select(res =>
              {
                  Log.WriteVerbose(new SourceInfo(), TB_Status, "Found Enterprise Resource {0}", res.Name);
                  return new ListViewItem(res.Name) { Tag = res };
              }).ToList();
            LV_EnterpiseResources.InvokeIfRequired(s =>
            {
                s.Items.AddRange(listViewItems.ToArray());
                s.Columns[0].Text = $"Enterprise Resources({listViewItems.Count})";
            });
        }

        private void BTN_Back_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void BTN_Cancel_Click(object sender, EventArgs e)
        {
            foreach (BackgroundExecutorWithStatus bgw in _bgws)
            {
                bgw.Cancel();
            }
        }

        private void ProjectOwner_ResizeEnd(object sender, EventArgs e)
        {
            LV_EnterpiseResources.ResizeColumnHeaders();
        }

        private static void ListView_Resize(object sender, EventArgs e)
        {
            ListView lv = sender as ListView;
            lv.ResizeColumnHeaders();
        }

        private static void ListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private static void ListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private BackgroundExecutorWithStatus _bgeProject;

        private void BTN_ChangeOwner_Click(object sender, EventArgs e)
        {
            if (LV_Projects.SelectedItems.Count <= 0 || LV_EnterpiseResources.SelectedItems.Count <= 0) return;
            _bgeProject = new BackgroundExecutorWithStatus(TB_Status, "Updating Project owner of the selected project");
            _bgws.Add(_bgeProject);
            _bgeProject.ExecuteWorker(UpdateProjectOwner);
        }

        private void UpdateProjectOwner()
        {
            List<PublishedProject> projectList = new List<PublishedProject>();
            EnterpriseResource resource = null;

            LV_Projects.InvokeIfRequired(s =>
            {
                ListView.SelectedListViewItemCollection selectedItems = s.SelectedItems;
                projectList.AddRange(selectedItems.Cast<ListViewItem>().Select(selectedItem => (PublishedProject)selectedItem.Tag));
            });

            LV_EnterpiseResources.InvokeIfRequired(s => resource = (EnterpriseResource)s.SelectedItems[0].Tag);

            if (resource == null)
            {
                Log.WriteWarning(new SourceInfo(), TB_Status, "No enterprise resource selected.");
                return;
            }

            List<QueueJob> jobs = new List<QueueJob>();
            foreach (PublishedProject publishedproject in projectList)
            {
                if (!publishedproject.IsCheckedOut)
                {
                    publishedproject.CheckOut();
                }
                else if (!publishedproject.CheckedOutBy.IsNull() && publishedproject.CheckedOutBy.Title != CsomBase.CurrentResource.User.Title)
                {
                    Log.WriteWarning(new SourceInfo(), TB_Status,
                        "Project:{0} checked out to a different user:{1}, not changing the owner to {2}.",
                        publishedproject.Name,
                        publishedproject.Owner.Title,
                        resource.User.Title);
                    continue;
                }

                Log.WriteVerbose(new SourceInfo(), TB_Status, "Updating project:{0}, Setting owner to:{1}", publishedproject.Name,
                    resource.Name);

                publishedproject.Owner = resource.User;
                jobs.Add(publishedproject.Draft.Update());
            }
            Log.WriteVerbose(new SourceInfo(), TB_Status, _bgeProject, "Waiting for the Project Update job to complete.");
            CsomHelper.ExecuteAndWait(jobs, TB_Status);
            Log.WriteVerbose(new SourceInfo(), TB_Status, _bgeProject, "Loading Projects.");
            LoadProjects();
        }
    }
}