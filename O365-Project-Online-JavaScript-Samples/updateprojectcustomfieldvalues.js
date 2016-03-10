/* Updates project, task, project resource and assignment custom field values */
function UpdateCustomFieldsValuesProject() {

	/* Store the entity names we're trying to update in some global variables.*/
	/* This code requires a project/task/resource with these names */
	var project_name = 'new project';
	var resource_name = 'new resource';
	var task_name = 'new task';

	/* Callback for success/failure */
	function WaitForQueueCallback(job_state) {
		switch (job_state) {
			case PS.JobState.success:
				alert("Successfully updated the project with name '" + project_name + "'.");
				break;
			case PS.JobState.readyForProcessing:
			case PS.JobState.processing:
			case PS.JobState.processingDeferred:
				alert("Updating the project with name '" + project_name + "' is taking longer than usual.");
				break;
			case PS.JobState.failed:
			case PS.JobState.failedNotBlocking:
			case PS.JobState.correlationBlocked:
				alert("Failed to update the project with name '" + project_name + "'." + ". The creation job is in state " + job_state);
				break;
			default:
				alert("Unknown error, job is in state " + job_state);
		}
	};

	// Callback for request failure
	function OnRequestFailed(sender, args) {
		alert("Failed to retrieve project. " + args.get_message());
	};

	// Retrieves an element id based on name from a collection
	function GetIdByName (collection, objectName) {
		var collection_enumerator = collection.getEnumerator();
		while (collection_enumerator.moveNext()) {
			if (collection_enumerator.get_current().get_name() == objectName) {
				return collection_enumerator.get_current().get_id();
			}
		}
	}

	// Returns a random lookup table entry as an array with a single element
	function GetRandomLookupTableValue(lookup_table_entries){
		if (lookup_table_entries === null || lookup_table_entries.get_count() == 0){
			throw "InvalidLookupTableEntries";
		}
		else {
			var index = Math.floor(Math.random() * lookup_table_entries.get_count());
			return new Array(lookup_table_entries.itemAt(index).get_id().toString())
		}
	}
    
    // Initialize the current client context. 
	var context = PS.ProjectContext.get_current();

	/* Setup the values for the custom fields */
	/* This code requires some project/task/resource custom fields of type text with the following UIDs */
	var project_custom_field_name = 'Project custom field'; 
	var resource_custom_field_name = 'Resource custom field'; 
	var task_custom_field_name = 'Task custom field';
    
    // Retrieve custom fields and lookup table definitions
    var custom_fields = context.get_customFields();
    var project_custom_field = custom_fields.getByGuid(GetIdByName(custom_fields, project_custom_field_name));
    var resource_custom_field = custom_fields.getByGuid(GetIdByName(custom_fields, resource_custom_field_name));
    var task_custom_field = custom_fields.getByGuid(GetIdByName(custom_fields, task_custom_field_name));

    var project_lookup_table_entries = project_custom_field.get_lookupEntries();
    var task_lookup_table_entries = task_custom_field.get_lookupEntries();
    var resource_lookup_table_entries = resource_custom_field.get_lookupEntries();

	context.load(project_custom_field);
	context.load(resource_custom_field);
	context.load(task_custom_field);
	context.load(project_lookup_table_entries);
	context.load(task_lookup_table_entries);
	context.load(resource_lookup_table_entries);

	// Retrieve all projects and lookup the published project by name
	var project_list = context.get_projects();
	context.load(project_list, 'Include(Name, Id)');
	context.executeQueryAsync(
		function () {
			// Load the draft project by name along with tasks, team and assignments
			var project_id = GetIdByName(project_list, project_name);
			var published_project = project_list.getByGuid(project_id);
			var draft_project = published_project.checkOut();

			var tasks = draft_project.get_tasks();
			var resources = draft_project.get_projectResources();
			var assignments = draft_project.get_assignments();

			context.load(tasks, 'Include(Id, Name)');
			context.load(resources, 'Include(Id, Name)');
			context.load(assignments, 'Include(Id, Task, Resource)');

			// Load the project along with tasks, resources and assignments
			context.executeQueryAsync(
				function () {
					var task_id = GetIdByName(tasks, task_name);
					var resource_id = GetIdByName(resources, resource_name);

					// No name for assignment, lookup by task/resource
					var assignments_enumerator = assignments.getEnumerator();
					while (assignments_enumerator.moveNext()) {
						var assignment = assignments_enumerator.get_current();
						if (assignment.get_task().get_id().toString() == task_id.toString() &&
							assignment.get_resource().get_id().toString() == resource_id.toString()) {
							var assignment_id = assignment.get_id();
						}
					}

					try {
						// Pick a random lookup table value
						draft_project.set_item(project_custom_field.get_internalName(), GetRandomLookupTableValue(project_lookup_table_entries));
					}
					catch(ex) {
						// Set a text value
						draft_project.set_item(project_custom_field.get_internalName(), "project custom field value");
					}

					// Update task custom field value
					var task = tasks.getByGuid(task_id);
					try {
						// Pick a random lookup table value
						task.set_item(task_custom_field.get_internalName(), GetRandomLookupTableValue(task_lookup_table_entries));
					}
					catch (ex) {
						// Set a text value
						task.set_item(task_custom_field.get_internalName(), "task custom field value");
					}

					// Update resource and assignment custom field value(s)
					var resource = resources.getByGuid(resource_id);
					var assignment = assignments.getByGuid(assignment_id);
					try {
						// Pick a random lookup table value
						resource.set_item(resource_custom_field.get_internalName(), GetRandomLookupTableValue(resource_lookup_table_entries));
						assignment.set_item(resource_custom_field.get_internalName(), GetRandomLookupTableValue(resource_lookup_table_entries));
					}
					catch (ex) {
						// Set a text value
						resource.set_item(resource_custom_field.get_internalName(), "resource custom field value");
						assignment.set_item(resource_custom_field.get_internalName(), "assignment custom field value");
					}

					// Send the update request and check in the project
					draft_project.update();
					var queue_job = draft_project.checkIn(false);
					context.waitForQueueAsync(queue_job, 60, WaitForQueueCallback);
				},
				OnRequestFailed
			);
		},
		OnRequestFailed
	);
}