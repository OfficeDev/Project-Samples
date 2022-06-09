/*
 * Copyright (c) Microsoft Corporation. All rights reserved. Licensed under the MIT license.
 * See LICENSE in the project root for license information.
 */

using Microsoft.ProjectServer.Client;
using Microsoft.SharePoint.Client;
using ProjToolV2.Properties;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Windows.Forms;

namespace ProjToolV2
{
    public class CsomHelper
    {
        public static ProjectContext ProjContext;

        public static EnterpriseResource LoadMe()
        {
            Log.WriteVerbose(new SourceInfo(), "Loading current user info.");
            User user = ProjContext.Web.CurrentUser;
            IEnumerable<EnterpriseResource> resources =
                ProjContext.LoadQuery(ProjContext.EnterpriseResources.Where(r => r.Name == user.Title).IncludeWithDefaultProperties(r => r.User));
            ProjContext.ExecuteQuery();
            return resources.FirstOrDefault();
        }

        public static bool CheckCurrentResourceIsAssignable()
        {
            Log.WriteVerbose(new SourceInfo(), "Current user resource type:[{0}].",
                CsomBase.CurrentResource.ResourceType);
            return CsomBase.CurrentResource.ResourceType == EnterpriseResourceType.Work;
        }

        public static void ExecuteAndWait(QueueJob queueJob, TextBox textbox)
        {
            ExecuteAndWait(new List<QueueJob> { queueJob }, textbox);
        }

        public static void ExecuteAndWait(List<QueueJob> queueJobs, TextBox textbox)
        {
            if (Settings.Default.WaitForQueue)
            {
                foreach (QueueJob queuejob in queueJobs)
                {
                    if (queuejob == null)
                    {
                        queueJobs.Remove(queuejob);
                    }
                    try
                    {
                        ProjContext.Load(queuejob);
                    }
                    catch (ClientRequestException cre)
                    {
                        Log.WriteError(new SourceInfo(), textbox, cre.Message);
                    }
                }
                ProjContext.ExecuteQuery();

                //considering one minute timeout for each queuejob.
                int totalWaitTime = queueJobs.Count;
                DateTime startTime = DateTime.Now;
                while (queueJobs.Count > 0)
                {
                    //Execute the first job in the list if completed remove it.
                    if (queueJobs[0] == null || ExecuteAndWaitInternal(queueJobs[0], textbox))
                    {
                        queueJobs.RemoveAt(0);
                    }
                    else
                    {
                        //Job needs to be checked again, so move it down below the list.
                        QueueJob currentJob = queueJobs[0];
                        queueJobs.RemoveAt(0);
                        queueJobs.Add(currentJob);
                    }
                    if (DateTime.Now - startTime <= TimeSpan.FromMinutes(totalWaitTime)) continue;
                    Log.WriteVerbose(new SourceInfo(), textbox,
                        "Queue jobs did not complete within the timeout period: {0} Minutes.", totalWaitTime);
                    break;
                }
            }
            else
            {
                Log.WriteVerbose(new SourceInfo(), textbox,
                    "Wait For Queue job is turned off. Not waiting for the queue jobs to complete.");
            }
        }

        private static bool ExecuteAndWaitInternal(QueueJob job, TextBox textbox)
        {
            bool queueJobCompleted = false;
            JobState[] jobStateToMarkAsProcessed =
            {
                JobState.Canceled, JobState.CorrelationBlocked, JobState.Failed,
                JobState.FailedNotBlocking, JobState.Success,
            };

            Log.WriteVerbose(new SourceInfo(), textbox,
                "Current Queue job State:{0}, Percent Complete:{1}, Job Type:{2}", job.JobState,
                job.PercentComplete, job.MessageType);

            JobState jobState = ProjContext.WaitForQueue(job, 3);
            if (job.IsNull())
            {
                //Server returned a null object probably the job is completed and CSOM doesnt know about the job anymore.
                queueJobCompleted = true;
            }
            if (jobStateToMarkAsProcessed.Contains(jobState))
            {
                LogStatus(job, textbox);
                queueJobCompleted = true;
            }
            else
            {
                queueJobCompleted = false;
            }
            return queueJobCompleted;
        }

        private static void LogStatus(QueueJob job, TextBox textbox)
        {
            if (job.JobState != JobState.Success)
            {
                Log.WriteWarning(new SourceInfo(), textbox, "Queue job failed. Job State:{0}, Job Type:{1}",
                    job.JobState, job.MessageType);
            }
            else
            {
                Log.WriteVerbose(new SourceInfo(), textbox,
                    "Queue job successfully completed. Job State:{0}, Job Type:{1}", job.JobState, job.MessageType);
            }
        }
    }
}