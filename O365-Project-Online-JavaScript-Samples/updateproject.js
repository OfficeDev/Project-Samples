/* Updates project, task, project resource and assignment intrinsic field */
function UpdateProject() {
	/* Store the entity names we're trying to update in some global variables*/
	/* This code assumes a project/task/resource with these names already exists */
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
				alert("Failed to update the project. The update job is in state " + job_state);
				break;
			default:
				alert("Unknown error, job is in state " + job_state);
		}
	}; 	
	
	// Initialize the current client context. 
	var context = PS.ProjectContext.get_current();

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
							assignment.get_resource().get_id().toString() == resource_id.toString()){
							var assignment_id = assignment.get_id();
						}
					}

					// Update project description
					draft_project.set_description('Changed by CSOM code on ' + (new Date()))

					// Update task duration
					var task = tasks.getByGuid(task_id);
					task.set_duration('10d');

					// Update resource standard rate
					var resource = resources.getByGuid(resource_id);
					resource.set_standardRate(100);

					// Update assignment work percent complete
					var assignment = assignments.getByGuid(assignment_id);
					assignment.set_percentWorkComplete(50);

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
