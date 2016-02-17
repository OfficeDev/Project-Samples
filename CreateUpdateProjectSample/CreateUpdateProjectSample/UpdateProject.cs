using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

using Microsoft.SharePoint.Client;
using csom = Microsoft.ProjectServer.Client;

namespace CreateUpdateProjectSample
{
    partial class CreateUpdateProjectSample
    {
        /// <summary>
        /// Read and update the project,
        /// this method need a project named "New Project" with a task "New task" and assign to a local resource named "New local resource" already created.
        /// Basically please run CreateProjectWithTaskAndAssignment() before running this to avoid exceptions
        /// </summary>
        public static void ReadAndUpdateProject()
        {
            // Load csom context
            context = GetContext(pwaInstanceUrl);

            // Retrieve publish project named "New Project"
            // if you know the Guid of project, you can just call context.Projects.GetByGuid()
            csom.PublishedProject project = GetProjectByName(projectName, context);
            if(project == null)
            {
                Console.WriteLine("Failed to retrieve expected data, make sure you set up server data right. Press any key to continue....");
                return;
            }

            csom.DraftProject draft = project.CheckOut();

            // Retrieve project along with tasks & resources
            context.Load(draft, p => p.StartDate,                                                         
                                p => p.Description);                                                      
            context.Load(draft.Tasks, dt => dt.Where(t => t.Name == taskName));                           
            context.Load(draft.Assignments, da => da.Where(a => a.Task.Name == taskName &&                
                                                                a.Resource.Name == localResourceName));   
            context.Load(draft.ProjectResources, dp => dp.Where(r => r.Name == localResourceName));       
            context.ExecuteQuery();

            // Make sure the data on server is right
            if (draft.Tasks.Count !=1 || draft.Assignments.Count != 1 || draft.ProjectResources.Count != 1)
            {
                Console.WriteLine("Failed to retrieve expected data, make sure you set up server data right. Press any key to continue....");
                Console.ReadLine();
                return;
            }

            // Since we already filetered and validated that the TaskCollection, ProjectResourceCollection and AssignmentCollection
            // contains just one filtered item each, we just get the first one.
            csom.DraftTask task = draft.Tasks.First();
            csom.DraftProjectResource resource = draft.ProjectResources.First();
            csom.DraftAssignment assignment = draft.Assignments.First();

            // Update the project description
            draft.Description += "(description updated)";

            // Update task duration and start date
            task.Duration = "10d";
            task.Start = draft.StartDate.AddDays(3);
            draft.Update();         // Save updates so far to ensure the task changes are applied before the assignment changes

            // Update resource standard rate
            resource.StandardRate = 100.0d;
            draft.Update();

            // Update assignment work percent complete
            assignment.PercentWorkComplete = 50;

            // Publish and check in the project
            csom.JobState jobState = context.WaitForQueue(draft.Publish(true), DEFAULTTIMEOUTSECONDS);
            JobStateLog(jobState, "Updating project");
        }
    }
}
