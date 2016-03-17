SP.SOD.executeOrDelayUntilScriptLoaded(initializePage, "PS.js");

var projContext;    //reference to the Project Context

/* Initial method called once PS.JS is ready to execute */
function initializePage() {
    //setup event handlers etc
    setupUI();

    //Get the Project context for this web
    projContext = PS.ProjectContext.get_current();

    var user = projContext.get_web().get_currentUser();
    projContext.load(user);

    projContext.executeQueryAsync(function () {
        $("#message").text(user.get_title());
    }, onRequestFailed);

    loadProjects();
}

/* General CSOM failure event handler */
function onRequestFailed(sender, args) {
    alert("Failed to execute: " + args.get_message());
};

var projects;       //reference to the list of published projects in PWA

/* Query CSOM and get the list of projects in PWA  */
function loadProjects() {    
    projects = projContext.get_projects();
    projContext.load(projects, 'Include(Name, Description, StartDate, Id, IsCheckedOut)');
    projContext.executeQueryAsync(displayProjects, onRequestFailed);
}

/*Display the projects in the drop downs and include the term checked out */
function displayProjects() {
    var sourceProjectList = $('#sourceProject');
    var targetProjectList = $('#targetProject');

    var sourceListOptions = [];
    var targetListOptions = [];

    //provide UI cues to select data
    sourceListOptions.push($('<option/>').attr({ 'value': '' }).text("Select Project..."));
    targetListOptions.push($('<option/>').attr({ 'value': '' }).text("Select Project..."));

    var pEnum = projects.getEnumerator();
    while (pEnum.moveNext()) {
        var p = pEnum.get_current();

        var proj_id = p.get_id();
        var proj_name = p.get_name();
        var checkedOut = p.get_isCheckedOut();

        var sourceOption = $('<option/>');
        sourceOption.attr({ 'value': proj_id }).text(proj_name);
        sourceListOptions.push(sourceOption);

        var targetOption = $('<option/>');
        if (checkedOut) {
            targetOption.attr({ 'value': proj_id }).text(proj_name + " [Checked Out]");
        } else {
            targetOption.attr({ 'value': proj_id }).text(proj_name);
        }
        targetListOptions.push(targetOption);
    }
    sourceProjectList.html(sourceListOptions);
    targetProjectList.html(targetListOptions);
    
}

var sourceTasks;    //Reference to the published tasks in the source project
var targetPublishedProject;  //Reference to the published version of the target project
var draftTasks;     //list of the draft tasks in the target project

/* UI glue */
function setupUI() {
    $(document).on('click', '#btnSubmit', function () {
        handleClick();
    });

    $(document).on('change', '#sourceProject', function () {
        $("#sourceTask").empty();
        var proj_id = $(this).val();
        if (proj_id != "") {
            loadSourceTasks(proj_id);
        }
    });

    $(document).on('change', '#targetProject', function () {
        $("#targetTask").empty();
        var proj_id = $(this).val();
        if (proj_id != "") {
            loadTargetTasks(proj_id);
        }
    });    
}

/* Loads the source task dropdown with the list of takes from the selected source project */
function loadSourceTasks(projectId) {
    //request the tasks for the 
    sourceTasks = projects.getById(projectId).get_tasks();

    //include the parent info as we will need to build a hierarchy of parent/child tasks
    projContext.load(sourceTasks, 'Include(Id, Name, IsSummary, Start, IsManual, Parent, Duration, Parent.Id, Parent.Name)');
    projContext.executeQueryAsync(function () {
        displayTasks($("#sourceTask"), sourceTasks, true)
    }, onRequestFailed
    );
}

/* Loads the target task dropdown with the list of takes from the selected target project */
function loadTargetTasks(projectId) {
    //get the target projects published version
    targetPublishedProject = projects.getById(projectId);
    projContext.load(targetPublishedProject);

    //get the draft version of the target project
    var targetDraftViewProject = targetPublishedProject.get_draft();

    //get the tasks from the draft version
    draftTasks = targetDraftViewProject.get_tasks();
    projContext.load(draftTasks, 'Include(Id, Name)');
    projContext.executeQueryAsync(function () {

        if (targetPublishedProject.get_isCheckedOut()) {
            $("#checkedOut").show();
            $("#btnSubmit").attr('disabled', 'disabled');
        } else {
            $("#checkedOut").hide();
            $("#btnSubmit").removeAttr('disabled');
        }

        displayTasks($("#targetTask"), draftTasks, false)
    }, onRequestFailed
   );
}

/* Displays the tasks in the drop downs.  Only displays the summary tasks if needed */
function displayTasks(ddl, tasks, includeSummaryOnly) {

    var ddlArray = [];

    ddlArray.push($('<option/>').attr({ 'value': '' }).text("Select Task..."));

    var pEnum = tasks.getEnumerator();
    while (pEnum.moveNext()) {
        var task = pEnum.get_current();
        var task_id = task.get_id();
        var task_name = task.get_name();

        //Display summary tasks for the source project since we are copying from there
        if (!includeSummaryOnly || (task.isPropertyAvailable("IsSummary") && task.get_isSummary())) {
            ddlArray.push($('<option/>').attr({ 'value': task_id }).text(task_name));            
        }
    }
    ddl.html(ddlArray);
}

/* Handle the Submit click event */
function handleClick() {
    if ($("#sourceTask").val() != "" && $("#targetTask").val() != "") {

        var taskTree = {};   //[taskid1] = task1 Object, [taskid2] = task2 Object
        var taskMap = {};   // [taskid] = [taskChildId,taskChildId2....]

        buildTaskTree(taskTree, taskMap);
        copyOverTasks(taskTree, taskMap);

    }
    return false;
}

/* Navigates over the list of tasks and creates both a id-> task object map and a hierarchy map of parent id -> list of children task ids */
function buildTaskTree(taskTree, taskMap) {
    var pEnum = sourceTasks.getEnumerator();
    while (pEnum.moveNext()) {
        var task = pEnum.get_current();
        var taskId = task.get_id();
        taskMap[taskId] = task;
        if (!(taskId in taskTree)) {
            taskTree[taskId] = [];
        }
        if (!task.get_parent().get_serverObjectIsNull()) {
            var taskParentId = task.get_parent().get_id();
            if (!(taskParentId in taskTree)) {
                taskTree[taskParentId] = [taskId];
            } else {
                taskTree[taskParentId].push(taskId);
            }
        }
    }
}

var projCheckedOut;  //holds a checked out draft copy of the project
var projectTasks;   //holds the draft tasks

/*iterates through the task tree from, visiting all the children of the source task and making a new task tree in the target project */
function copyOverTasks(taskTree, taskMap) {
    projCheckedOut = targetPublishedProject.checkOut();  //check out the target project
    projectTasks = projCheckedOut.get_tasks();  //get the list of tasks in the target project
    projContext.load(projectTasks, 'Include(Id, Name)');
    projContext.executeQueryAsync(
        function () {

            var sourceTaskId = $("#sourceTask").val();
            var parentTaskId = $("#targetTask").val();

            createChildTasks(taskTree, taskMap, projectTasks, parentTaskId, sourceTaskId);


            var job = projCheckedOut.update();  //save the tasks

            var queue_job = projCheckedOut.publish(true); //publish and check back in

            projContext.waitForQueueAsync(queue_job, 60, waitForQueueCallback);
        }, onRequestFailed);
}

/* Creates the immediate child tasks for the parent tasks.  Then recursively visits the child and creates grandchildren */
function createChildTasks(taskTree, taskMap, projectTasks, parentTaskId, sourceTaskId) {
    var sourceTasks = taskTree[sourceTaskId];

    for (var i = 0; i < sourceTasks.length; i++) {

        var sourceTask = taskMap[sourceTasks[i]];  //get the the source task

        var newTask = new PS.TaskCreationInformation();
        var newId = SP.Guid.newGuid();
        newTask.set_id(newId);
        newTask.set_name(sourceTask.get_name())
        newTask.set_isManual(sourceTask.get_isManual());
        newTask.set_duration(sourceTask.get_duration());
        newTask.set_start(sourceTask.get_start());
        newTask.set_parentId(parentTaskId);  //set the parent
        projectTasks.add(newTask);

        //visit any children of the curent task
        createChildTasks(taskTree, taskMap, projectTasks, newId, sourceTask.get_id());
    }
}

/* Callback for success/failure */
function waitForQueueCallback(job_state) {
    switch (job_state) {
        case PS.JobState.success:
            alert("Successfully updated the project with name '" + targetPublishedProject.get_name() + "'.");
            break;
        case PS.JobState.readyForProcessing:
        case PS.JobState.processing:
        case PS.JobState.processingDeferred:
            alert("Updating the project with name '" + targetPublishedProject.get_name() + "' is taking longer than usual.");
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

