/*
 * Copyright (c) Microsoft Corporation. All rights reserved. Licensed under the MIT license.
 * See LICENSE in the project root for license information.
 */

using Microsoft.ProjectServer.Client;
using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Resources = ProjToolV2.Properties.Resources;
using View = System.Windows.Forms.View;

namespace ProjToolV2
{
    public partial class ProjectTeamBuilder : BaseForm
    {
        private readonly List<BackgroundExecutorWithStatus> _bgws = new List<BackgroundExecutorWithStatus>();

        public ProjectTeamBuilder()
        {
            InitializeComponent();
            Icon = Resources.Project;
        }

        private void ProjectTeamBuilder_Load(object sender, EventArgs e)
        {
            LV_Projects.View = View.Details;
            LV_Projects.Alignment = ListViewAlignment.SnapToGrid;
            LV_Projects.FullRowSelect = true;
            LV_Projects.Scrollable = true;
            LV_Projects.HideSelection = false;
            LV_Projects.Columns.Add(new ColumnHeader { Text = "Projects", DisplayIndex = 0 });
            LV_Projects.MultiSelect = false;

            LV_ProjectResources.View = View.Details;
            LV_ProjectResources.Alignment = ListViewAlignment.SnapToGrid;
            LV_ProjectResources.Scrollable = true;
            LV_ProjectResources.HideSelection = false;
            LV_ProjectResources.FullRowSelect = true;
            LV_ProjectResources.MultiSelect = true;
            LV_ProjectResources.Columns.Add(new ColumnHeader { Text = "Project Resources", DisplayIndex = 0 });

            LV_EnterpiseResources.View = View.Details;
            LV_EnterpiseResources.Alignment = ListViewAlignment.SnapToGrid;
            LV_EnterpiseResources.Scrollable = true;
            LV_EnterpiseResources.HideSelection = false;
            LV_EnterpiseResources.FullRowSelect = true;
            LV_EnterpiseResources.MultiSelect = true;
            LV_EnterpiseResources.Columns.Add(new ColumnHeader { Text = "Enterprise Resources", DisplayIndex = 0 });

            LV_Projects.OwnerDraw = true;
            LV_Projects.Resize += ListView_Resize;
            LV_Projects.DrawItem += ControlHelpers.ListViewDrawItem;
            LV_Projects.DrawSubItem += ControlHelpers.ListViewDrawSubItem;
            LV_Projects.DrawColumnHeader += ControlHelpers.ListViewDrawColumnHeader;
            LV_Projects.ColumnClick += ControlHelpers.SortListView;

            LV_ProjectResources.OwnerDraw = true;
            LV_ProjectResources.Resize += ListView_Resize;
            LV_ProjectResources.DrawItem += ControlHelpers.ListViewDrawItem;
            LV_ProjectResources.DrawSubItem += ControlHelpers.ListViewDrawSubItem;
            LV_ProjectResources.DrawColumnHeader += ControlHelpers.ListViewDrawColumnHeader;
            LV_ProjectResources.ColumnClick += ControlHelpers.SortListView;

            LV_EnterpiseResources.OwnerDraw = true;
            LV_EnterpiseResources.Resize += ListView_Resize;
            LV_EnterpiseResources.DrawItem += ControlHelpers.ListViewDrawItem;
            LV_EnterpiseResources.DrawSubItem += ControlHelpers.ListViewDrawSubItem;
            LV_EnterpiseResources.DrawColumnHeader += ControlHelpers.ListViewDrawColumnHeader;
            LV_EnterpiseResources.ColumnClick += ControlHelpers.SortListView;

            LoadProjectsAndResources();
        }

        private void LoadProjectsAndResources()
        {
            BackgroundExecutorWithStatus bgeProject = new BackgroundExecutorWithStatus(TB_Status, "Querying for all projects");
            BackgroundExecutorWithStatus bgeResource = new BackgroundExecutorWithStatus(TB_Status, "Querying for all Enterprise Resources");

            _bgws.Add(bgeProject);
            _bgws.Add(bgeResource);

            bgeProject.ExecuteWorker(GetDraftProjectsList);
            bgeResource.ExecuteWorker(GetEnterpriseResourcesList);
            Log.WriteVerbose(new SourceInfo(), "Loading Projects and Enterprise resources.");
        }

        private void GetDraftProjectsList()
        {
            LV_Projects.InvokeIfRequired(s => s.Items.Clear());
            IEnumerable<PublishedProject> projectList = CsomHelper.LoadAllProjects(
                p => p.Draft.Name, p => p.Draft.Id, p => p.IsCheckedOut);
            PublishedProject[] publishedProjects = projectList.ToArray();
            List<ListViewItem> listViewItems = new List<ListViewItem>();
            foreach (PublishedProject project in publishedProjects)
            {
                ListViewItem lvi = new ListViewItem(project.Draft.Name) { Tag = project };
                Log.WriteVerbose(new SourceInfo(), "Found Project:{0}", project.Draft.Name);
                listViewItems.Add(lvi);
            }
            LV_Projects.InvokeIfRequired(s =>
            {
                s.Columns[0].Text = $"Projects({publishedProjects.Length})";
                s.Items.AddRange(listViewItems.ToArray());
            });
        }

        private void GetDraftTeamForSelectedProject()
        {
            PublishedProject project = null;

            LV_Projects.InvokeIfRequired(s => project = s.SelectedItems[0].Tag as PublishedProject);
            LV_ProjectResources.InvokeIfRequired(s => s.Items.Clear());

            IEnumerable<DraftProjectResource> resourceList = ProjContext.LoadQuery(project.Draft.ProjectResources);
            ProjContext.ExecuteQuery();

            DraftProjectResource[] draftProjectResources = resourceList.ToArray();

            foreach (ListViewItem lvi in draftProjectResources.Select(res => new ListViewItem(res.Name) { Tag = res }))
            {
                LV_ProjectResources.InvokeIfRequired(s => s.Items.Add(lvi));
            }

            LV_ProjectResources.InvokeIfRequired(s => s.Columns[0].Text = $"Project Resources({draftProjectResources.Length})");
        }

        private void GetEnterpriseResourcesList()
        {
            LV_EnterpiseResources.InvokeIfRequired(s => s.Items.Clear());
            IEnumerable<EnterpriseResource> resourcesList = ProjContext.LoadQuery(ProjContext.EnterpriseResources.Where(r => r.ResourceType == EnterpriseResourceType.Work));
            ProjContext.ExecuteQuery();

            EnterpriseResource[] enterpriseResources = resourcesList.ToArray();
            foreach (EnterpriseResource res in enterpriseResources)
            {
                ListViewItem lvi = new ListViewItem(res.Name) { Tag = res };
                Log.WriteVerbose(new SourceInfo(), "Found Resource:{0}", res.Name);

                LV_EnterpiseResources.InvokeIfRequired(s => s.Items.Add(lvi));
            }
            LV_EnterpiseResources.InvokeIfRequired(s => s.Columns[0].Text = $"Enterprise Resources({enterpriseResources.Length})");
        }

        private BackgroundExecutorWithStatus _bgeAddResourcesToProject;

        private void BTN_AddResources_Click(object sender, EventArgs e)
        {
            if (LV_Projects.SelectedItems.Count <= 0) return;
            _bgeAddResourcesToProject = new BackgroundExecutorWithStatus(TB_Status, "Adding Enterprise resources to the selected project");
            _bgws.Add(_bgeAddResourcesToProject);
            _bgeAddResourcesToProject.ExecuteWorker(AddResourcesToProject);
        }

        private void AddResourcesToProject()
        {
            PublishedProject publishedProject = null;
            DraftProject draftProject;
            LV_Projects.InvokeIfRequired(s => publishedProject = s.SelectedItems[0].Tag as PublishedProject);

            List<EnterpriseResource> resourceList = new List<EnterpriseResource>();

            LV_EnterpiseResources.InvokeIfRequired(s =>
            {
                ListView.SelectedListViewItemCollection selectedItems = s.SelectedItems;
                resourceList.AddRange(selectedItems.Cast<ListViewItem>().Select(selectedItem => (EnterpriseResource)selectedItem.Tag));
            });

            if (resourceList.Any())
            {
                draftProject = publishedProject.IsCheckedOut ? publishedProject.Draft : publishedProject.CheckOut();

                resourceList.ToList().ForEach(r =>
                    {
                        Log.WriteVerbose(new SourceInfo(), TB_Status, "Adding Resource:{0} to Project:{1}.", r.Name, publishedProject.Draft.Name);
                        draftProject.ProjectResources.AddEnterpriseResource(r);
                    });

                QueueJob queueJob = draftProject.Update();
                Log.WriteVerbose(new SourceInfo(), TB_Status, _bgeAddResourcesToProject, "Waiting for the Project Update job to complete.");
                CsomHelper.ExecuteAndWait(queueJob, TB_Status);
            }
            Log.WriteVerbose(new SourceInfo(), TB_Status, _bgeAddResourcesToProject, "Refreshing Project resources.");
            GetDraftTeamForSelectedProject();
        }

        private BackgroundExecutorWithStatus _bgeRemoveProjectResources;

        private void BTN_RemoveResources_Click(object sender, EventArgs e)
        {
            if (LV_Projects.SelectedItems.Count <= 0 || LV_ProjectResources.SelectedItems.Count <= 0) return;
            _bgeRemoveProjectResources = new BackgroundExecutorWithStatus(TB_Status, "Removing Project Resources on the selected Project");
            _bgws.Add(_bgeRemoveProjectResources);
            _bgeRemoveProjectResources.ExecuteWorker(RemoveResources);
        }

        private void RemoveResources()
        {
            PublishedProject publishedProject = null;
            DraftProject draftProject;
            List<DraftProjectResource> draftProjectResourceresList = new List<DraftProjectResource>();

            LV_Projects.InvokeIfRequired(s => publishedProject = (PublishedProject)s.SelectedItems[0].Tag);

            LV_ProjectResources.InvokeIfRequired(s =>
            {
                ListView.SelectedListViewItemCollection selectedItems = s.SelectedItems;
                draftProjectResourceresList.AddRange(selectedItems.Cast<ListViewItem>().Select(selectedItem => (DraftProjectResource)selectedItem.Tag));
            });

            if (draftProjectResourceresList.Any())
            {
                draftProject = publishedProject.IsCheckedOut ? publishedProject.Draft : publishedProject.CheckOut();

                draftProjectResourceresList.ForEach(r =>
                    {
                        Log.WriteVerbose(new SourceInfo(), TB_Status, "Removing Resource:{0} from Project:{1}.", r.Name, publishedProject.Draft.Name);
                        draftProject.ProjectResources.Remove(r);
                    });
                QueueJob queueJob = draftProject.Update();
                Log.WriteVerbose(new SourceInfo(), TB_Status, _bgeRemoveProjectResources, "Waiting for the Project Update job to complete.");
                CsomHelper.ExecuteAndWait(queueJob, TB_Status);
            }
            Log.WriteVerbose(new SourceInfo(), TB_Status, _bgeRemoveProjectResources, "Refreshing Project resources.");
            GetDraftTeamForSelectedProject();
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

        private void LV_Projects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LV_Projects.SelectedItems.Count <= 0) return;
            BackgroundExecutorWithStatus bgeProjectResources = new BackgroundExecutorWithStatus(TB_Status, "Querying for Project Resources on the selected Project");
            _bgws.Add(bgeProjectResources);
            bgeProjectResources.ExecuteWorker(GetDraftTeamForSelectedProject);
        }

        private void ProjectTeamBuilder_ResizeEnd(object sender, EventArgs e)
        {
            LV_Projects.ResizeColumnHeaders();
            LV_ProjectResources.ResizeColumnHeaders();
            LV_EnterpiseResources.ResizeColumnHeaders();
        }

        private static void ListView_Resize(object sender, EventArgs e)
        {
            ListView lv = sender as ListView;
            lv.ResizeColumnHeaders();
        }
    }
}