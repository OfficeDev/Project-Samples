/*
 * Copyright (c) Microsoft Corporation. All rights reserved. Licensed under the MIT license.
 * See LICENSE in the project root for license information.
 */

using Microsoft.ProjectServer.Client;
using ProjToolV2.Properties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjToolV2
{
    public partial class ProjectsCreation : BaseForm
    {
        private BackgroundExecutorWithStatus _backgroundExecutorWithStatus;

        public ProjectsCreation()
        {
            Icon = Resources.Project;
            InitializeComponent();
        }

        private void BTN_Create_Click(object sender, EventArgs e)
        {
            _backgroundExecutorWithStatus = new BackgroundExecutorWithStatus(TB_Status, "Creating Projects");
            _backgroundExecutorWithStatus.ExecuteWorker(CreateProjects);
        }

        private void CreateProjects()
        {
            IList<EnterpriseResource> enterpriseResources = null;
            List<QueueJob> projectCreationJobs = new List<QueueJob>();
            if (RB_AssignExistingEnterpriseResources.Checked)
            {
                IEnumerable<EnterpriseResource> resList = ProjContext.LoadQuery(ProjContext.EnterpriseResources.Where(r => r.ResourceType == EnterpriseResourceType.Work));
                ProjContext.ExecuteQuery();
                enterpriseResources = resList.ToList();
            }
            for (int projCount = 1; projCount <= numProjects.Value; projCount++)
            {
                string projName = txtProjName.Text + projCount;
                List<EnterpriseResource> projectTeam = new List<EnterpriseResource>();
                PublishedProject newProject = ProjContext.Projects.Add(new ProjectCreationInformation { Name = projName });

                //Build the team first.
                if (RB_AssignExistingEnterpriseResources.Checked)
                {
                    if (enterpriseResources.Count > 0)
                    {
                        projectTeam = enterpriseResources.PickRandom((int)numTasks.Value);
                        projectTeam.ForEach(p => newProject.Draft.ProjectResources.AddEnterpriseResource(p));
                    }
                    else
                    {
                        Log.WriteWarning(new SourceInfo(), TB_Status, "No enterprise resources available in the server.");
                    }
                }
                else if (RB_AssignToMe.Checked)
                {
                    if (CsomBase.CurrentResourceIsAssignable)
                    {
                        newProject.Draft.ProjectResources.AddEnterpriseResource(CsomBase.CurrentResource);
                    }
                    else
                    {
                        Log.WriteWarning(new SourceInfo(), TB_Status,
                            "Current user is not resource. Not creating assignments.");
                    }
                }

                List<TaskCreationInformation> dtc = CreateTasks();
                if (CB_Tasks.Checked)
                {
                    foreach (var task in dtc)
                    {
                        newProject.Draft.Tasks.Add(task);
                        if (RB_AssignExistingEnterpriseResources.Checked)
                        {
                            if (projectTeam.Count > 0)
                            {
                                EnterpriseResource res = projectTeam.PickRandom();
                                newProject.Draft.Assignments.Add(new AssignmentCreationInformation
                                {
                                    TaskId = task.Id,
                                    ResourceId = res.Id
                                });
                            }
                            else
                            {
                                Log.WriteWarning(new SourceInfo(), TB_Status,
                                    "No enterprise resources available in the server. Not creating assignments.");
                            }
                        }
                        else if (RB_AssignToMe.Checked)
                        {
                            if (CsomBase.CurrentResourceIsAssignable)
                            {
                                AssignmentCreationInformation assnCi = CreateAssignment(task.Id,
                                    CsomBase.CurrentResource.Id);
                                newProject.Draft.Assignments.Add(assnCi);
                            }
                            else
                            {
                                Log.WriteWarning(new SourceInfo(), TB_Status,
                                    "Current user is not resource. Not creating assignments.");
                            }
                        }
                    }
                }
                if (RB_UseLocalResources.Checked)
                {
                    for (int localResourceCount = 1; localResourceCount <= numTasks.Value; localResourceCount++)
                    {
                        ProjectResourceCreationInformation localResourceCi = CreateLocalResource(localResourceCount);
                        newProject.Draft.ProjectResources.Add(localResourceCi);

                        if (chkResAssign.Checked)
                        {
                            AssignmentCreationInformation assnCi =
                                CreateAssignment(dtc.PickRandom().Id, localResourceCi.Id);
                            newProject.Draft.Assignments.Add(assnCi);
                        }
                    }
                }

                Log.WriteVerbose(new SourceInfo(), TB_Status, "Creating project {0} of {1} with name {2}.", projCount,
                    numProjects.Value, projName);
                projectCreationJobs.Add(newProject.Draft.Update());
            }

            Log.WriteVerbose(new SourceInfo(), TB_Status, _backgroundExecutorWithStatus,
                "Waiting for the Project creation queue job to complete.");
            CsomHelper.ExecuteAndWait(projectCreationJobs, TB_Status);
        }

        private static AssignmentCreationInformation CreateAssignment(Guid taskGuid, Guid resourceGuid)
        {
            AssignmentCreationInformation assnCi = new AssignmentCreationInformation
            {
                TaskId = taskGuid,
                ResourceId = resourceGuid
            };
            return assnCi;
        }

        private List<TaskCreationInformation> CreateTasks()
        {
            List<TaskCreationInformation> draftTasks = new List<TaskCreationInformation>();

            for (int taskCount = 1; taskCount <= numTasks.Value; taskCount++)
            {
                TaskCreationInformation taskCreationInformation = new TaskCreationInformation
                {
                    Name = txtTaskName.Text + 1,
                    IsManual = false,
                    Duration = $"{RandomEx.Random.Next(1, 16)}d"
                };

                draftTasks.Add(taskCreationInformation);
            }
            return draftTasks;
        }

        private
            ProjectResourceCreationInformation CreateLocalResource(int resourceSuffix)
        {
            ProjectResourceCreationInformation localResourceCi = new ProjectResourceCreationInformation
            {
                Name = txtResName.Text + resourceSuffix,
            };
            return localResourceCi;
        }

        private void BTN_Cancel_Click(object sender, EventArgs e)
        {
            _backgroundExecutorWithStatus?.Cancel();
        }

        private void BTN_Back_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void chkTasks_CheckedChanged(object sender, EventArgs e)
        {
            txtTaskName.Enabled = CB_Tasks.Checked;
            numTasks.Enabled = CB_Tasks.Checked;
            RB_UseLocalResources.Enabled = CB_Tasks.Checked;
            RB_UseEnterpriseResources.Enabled = CB_Tasks.Checked;

            if (!CB_Tasks.Checked)
            {
                RB_UseLocalResources.Checked = CB_Tasks.Checked;
                RB_UseEnterpriseResources.Checked = CB_Tasks.Checked;
            }
        }

        private void RB_UseLocalResources_CheckedChanged(object sender, EventArgs e)
        {
            txtResName.Enabled = RB_UseLocalResources.Checked;
            numResources.Enabled = RB_UseLocalResources.Checked;
            chkResAssign.Enabled = RB_UseLocalResources.Checked;
            if (!RB_UseLocalResources.Checked)
            {
                chkResAssign.Checked = RB_UseLocalResources.Checked;
            }
        }

        private void RB_UseEnterpriseResources_CheckedChanged(object sender, EventArgs e)
        {
            RB_AssignExistingEnterpriseResources.Enabled = RB_UseEnterpriseResources.Checked;
            RB_AssignToMe.Enabled = RB_UseEnterpriseResources.Checked;
            RB_AssignToMe.Checked = RB_UseEnterpriseResources.Checked;

            if (!RB_UseEnterpriseResources.Checked)
            {
                RB_AssignExistingEnterpriseResources.Checked = RB_UseEnterpriseResources.Checked;
            }
        }

        private void RB_UseEnterpriseResources_EnabledChanged(object sender, EventArgs e)
        {
            if (!RB_UseEnterpriseResources.Enabled)
            {
                RB_AssignExistingEnterpriseResources.Checked = RB_UseEnterpriseResources.Enabled;
                RB_AssignToMe.Checked = RB_UseEnterpriseResources.Enabled;
            }
        }
    }
}