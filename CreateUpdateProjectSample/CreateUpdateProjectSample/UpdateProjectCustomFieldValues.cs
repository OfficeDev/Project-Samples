using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.SharePoint.Client;
using csom = Microsoft.ProjectServer.Client;

namespace CreateUpdateProjectSample
{
    partial class CreateUpdateProjectSample
    {

        /// <summary>
        /// Read and Update Project/Task/Resource custom field values,
        /// this method need a project named "New Project" with a task "New task" and assign to a local resource named "New local resource" already created.
        /// Basically please run CreateProjectWithTaskAndAssignment() before running this to avoid exceptions
        /// </summary>
        public static void UpdateCustomFieldValues()
        {
            // Load csom context
            context = GetContext(pwaInstanceUrl);

            // Create custom field values before read it.
            CreateCustomFields();

            // Retrive publish project named "New Project"
            // if you know the Guid of project, you can just call context.Projects.GetByGuid()
            csom.PublishedProject project = GetProjectByName(projectName, context);
            if (project == null)
            {
                Console.WriteLine("Failed to retrieve expected data, make sure you set up server data right. Press any key to continue....");
                return;
            }
            csom.DraftProject draft = project.CheckOut();

            // Retrieve project along with tasks & assignments & resources
            context.Load(draft.Tasks, dt => dt.Where(t => t.Name == taskName));
            context.Load(draft.Assignments, da => da.Where(a => a.Task.Name == taskName &&
                                                                a.Resource.Name == localResourceName));
            context.Load(draft.ProjectResources, dp => dp.Where(r => r.Name == localResourceName));
            context.ExecuteQuery();

            // Make sure the data on server is right
            if (draft.Tasks.Count != 1 || draft.Assignments.Count != 1 || draft.ProjectResources.Count != 1)
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

            // Retrieve custom field by name
            context.Load(context.CustomFields);
            context.ExecuteQuery();
            csom.CustomField projCF = context.CustomFields.FirstOrDefault(cf => cf.Name == projectCFName);
            csom.CustomField taskCF = context.CustomFields.FirstOrDefault(cf => cf.Name == taskCFName);
            csom.CustomField resCF = context.CustomFields.FirstOrDefault(cf => cf.Name == resourceCFName);

            // Get random lookup table entry
            csom.LookupEntry taskLookUpEntry = GetRandomLookupEntries(taskCF);

            // Change project custom field value
            draft[projCF.InternalName] = "Project custom field value";

            // Change task custom field value
            /*
              --------------------------Important!---------------------------
              if it is a lookup table customfield, need to be set as an array
            */
            task[taskCF.InternalName] = new[] { taskLookUpEntry.InternalName };

            // Change resource and assignment custom field value
            resource[resCF.InternalName] = "Resource custom field value";
            assignment[resCF.InternalName] = "Assignment custom field value";

            // Update project and check in
            draft.Update();
            csom.JobState jobState = context.WaitForQueue(draft.Publish(true), DEFAULTTIMEOUTSECONDS);
            JobStateLog(jobState, "Updating project customfield values");
        }

        /// <summary>
        /// Create Project/Task/Resource custom fields. Field type will be TEXT.
        /// </summary>
        private static void CreateCustomFields()
        {
            context.Load(context.EntityTypes.ProjectEntity);
            context.Load(context.EntityTypes.TaskEntity);
            context.Load(context.EntityTypes.ResourceEntity);
            context.ExecuteQuery();

            // Create a simple lookup table with 3 values one/two/three
            csom.LookupTable lookupTB = CreateSimpleLookupTable();

            // Create a project custom field with field type TEXT
            csom.CustomField projCF = context.CustomFields.Add(new csom.CustomFieldCreationInformation() {
                EntityType = context.EntityTypes.ProjectEntity,
                FieldType = csom.CustomFieldType.TEXT,
                Name = projectCFName,
                LookupTable = null
            });

            // Create a task custom field with field type TEXT, and with the lookup table just created
            csom.CustomField taskCF = context.CustomFields.Add(new csom.CustomFieldCreationInformation() {
                EntityType = context.EntityTypes.TaskEntity,
                FieldType = csom.CustomFieldType.TEXT,
                Name = taskCFName,
                LookupTable = lookupTB
            });

            // Create a resource custom field with field type TEXT
            csom.CustomField resourceCF = context.CustomFields.Add(new csom.CustomFieldCreationInformation() {
                EntityType = context.EntityTypes.ResourceEntity,
                FieldType = csom.CustomFieldType.TEXT,
                Name = resourceCFName,
            });

            context.CustomFields.Update();
            context.ExecuteQuery();
        }

        /// <summary>
        /// Create a simple lookup table with 3 text value choose (one/two/three)
        /// </summary>
        /// <returns></returns>
        private static csom.LookupTable CreateSimpleLookupTable()
        {
            string[] lookupValues = new string[] { "one", "two", "three" };
            csom.LookupTable lookupTable = context.LookupTables.Add(new csom.LookupTableCreationInformation()
            {
                Name = "Simple lookup table",
                SortOrder = csom.LookupTableSortOrder.Ascending,
                Entries = lookupValues.Select((val, i) =>
                          new csom.LookupEntryCreationInformation()
                          {
                              Value = new csom.LookupEntryValue() { TextValue = val },
                              SortIndex = i
                          }).ToArray(),
                Masks = new csom.LookupMask[] { new csom.LookupMask()
                                                {
                                                    MaskType = csom.LookupTableMaskSequence.CHARACTERS,
                                                    Length = 0,
                                                    Separator = "."
                                                 }
                                               }
            });

            context.LookupTables.Update();
            context.ExecuteQuery();

            return lookupTable;
        }

        private static csom.LookupEntry GetRandomLookupEntries(csom.CustomField cf)
        {
            context.Load(cf, c => c, c => c.LookupEntries);
            context.ExecuteQuery();
            try
            {
                Random r = new Random();
                int index = r.Next(0, cf.LookupEntries.Count);
                csom.LookupEntry lookUpEntry = cf.LookupEntries[index];
                context.Load(lookUpEntry);
                context.ExecuteQuery();
                return lookUpEntry;
            }
            catch (CollectionNotInitializedException ex)
            {
                return null;
            }      
        }
    }
}

