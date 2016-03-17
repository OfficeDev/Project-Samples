/* Creates a new project with one resource, one task and one assignment */
function CreateProject() {
	/* Store the entity names we're trying to create in some global variables */
	var project_name = 'new project';
	var resource_name = 'new resource';
	var task_name = 'new task';

	/* Callback for success/failure */
	function WaitForQueueCallback(job_state) {
		switch (job_state) {
			case PS.JobState.success:
				alert("Successfully created a new project with name '" + project_name + "'.");
				break;
			case PS.JobState.readyForProcessing:
			case PS.JobState.processing:
			case PS.JobState.processingDeferred:
				alert("Creating the new project with name '" + project_name + "' is taking longer than usual.");
				break;
			case PS.JobState.failed:
			case PS.JobState.failedNotBlocking:
			case PS.JobState.correlationBlocked:
				alert("Failed to create a new project. The creation job is in state " + job_state);
				break;
			default:
				alert("Unknown error, job is in state " + job_state);
		}
	}

	// Function to generate GUIDs (https://stackoverflow.com/questions/105034/create-guid-uuid-in-javascript/2117523)
	function NewGuid() {
		return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
			var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
			return v.toString(16);
		})
	}
	
	// Initializes the current client context. 
	var context = PS.ProjectContext.get_current();

	// Creates the new project
	var new_project = new PS.ProjectCreationInformation();
	new_project.set_name(project_name);
	new_project.set_start('01/01/2015');

	var project_list = context.get_projects();
	var project = project_list.add(new_project).get_draft();

	// Creates a new local resource
	var new_resource_id = NewGuid();
	var new_resource = new PS.ProjectResourceCreationInformation();
	new_resource.set_name(resource_name);
	new_resource.set_id(new_resource_id);

	var project_resources_list = project.get_projectResources();
	var project_resource = project_resources_list.add(new_resource);

	// Creates a new task in the project
	var new_task_id = NewGuid();
	var new_task = new PS.TaskCreationInformation();
	new_task.set_name(task_name);
	new_task.set_duration('5d');
	new_task.set_id(new_task_id);

	var task_list = project.get_tasks();
	task_list.add(new_task);

	// Creates an assignment for the new task and resource
	var new_assignment = new PS.AssignmentCreationInformation();
	new_assignment.set_resourceId(new_resource_id);
	new_assignment.set_taskId(new_task_id);

	var assignment_list = project.get_assignments();
	assignment_list.add(new_assignment);

	// Sends the request for project creation and publishing
	var queue_job = project_list.update();

	context.waitForQueueAsync(queue_job, 60, WaitForQueueCallback);
}