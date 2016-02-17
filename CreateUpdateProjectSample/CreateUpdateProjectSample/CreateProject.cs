using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using csom = Microsoft.ProjectServer.Client;

namespace CreateUpdateProjectSample
{
    partial class CreateUpdateProjectSample
    {
        

        /// <summary>
        /// Create a new project with one local resource, one enterprise resource, one task and one assignment
        /// </summary>
        public static void CreateProjectWithTaskAndAssignment()
        {
            //
            // Load csom context
            context = GetContext(pwaInstanceUrl);

            //
            // Create a project
            csom.PublishedProject project = context.Projects.Add(new csom.ProjectCreationInformation()
            {
                Name = projectName,
                Start = DateTime.Today,
                Description = "Created project from C# library"
            });
            csom.JobState jobState = context.WaitForQueue(context.Projects.Update(), DEFAULTTIMEOUTSECONDS);
            JobStateLog(jobState, "Creating project");

            //
            // Create a task in project
            context.Load(project, p => p, 
                                  p => p.StartDate);    //load startdate of project 
            context.ExecuteQuery();

            csom.DraftProject draft = project.CheckOut();
            Guid taskId = Guid.NewGuid();
            csom.Task task = draft.Tasks.Add(new csom.TaskCreationInformation()
            {
                Id = taskId,
                Name = taskName,
                IsManual = false,   
                Start = project.StartDate.AddDays(1),
                Duration = "5d"
            });

            draft.Update();

            //
            // Create a local resource and assign the task to him
            Guid resourceId = Guid.NewGuid();
            csom.ProjectResource resource = draft.ProjectResources.Add(new csom.ProjectResourceCreationInformation()
            {
                Id = resourceId,
                Name = localResourceName
            });

            draft.Update();

            csom.DraftAssignment assignment = draft.Assignments.Add(new csom.AssignmentCreationInformation()
            {
                ResourceId = resourceId,
                TaskId = taskId
            });

            draft.Update();
            jobState = context.WaitForQueue(draft.Publish(true), DEFAULTTIMEOUTSECONDS);    // draft.Publish(true) means publish and check in
            JobStateLog(jobState, "Creating task and assgin to a local resource");
        }
    }
}
