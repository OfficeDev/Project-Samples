# Creates a Project using ReST API
param
(
    # SharepointOnline project site collection URL
    $SiteUrl = $(throw "SiteUrl parameter is required")
)
# Load ReST helper methods
. .\ReST.ps1

# Set up the request authentication
Set-SPOAuthenticationTicket $siteUrl
Set-DigestValue $siteUrl

# Project parameters as JSON payload
$projectid = [Guid]::NewGuid()
$body = "{
	'parameters': {
		'Id': '$projectid',
		'Name': 'Project_$projectid',
		'Description': 'Created from PowerShell using REST API'
	}
}"

# ReST request to create a project
Post-ReSTRequest $SiteUrl "ProjectServer/Projects/Add" $body

# ReST request to check out the project
Post-ReSTRequest $SiteUrl "ProjectServer/Projects('$projectid')/checkOut" $null

# Task parameters as JSON payload
$taskid = [Guid]::NewGuid()
$body = "{
	'parameters': {
		'Id': '$taskid',
		'Name': 'Task_$taskid',
		'Notes': 'Created from PowerShell using REST API',
		'Start': '2016-01-04T08:00:00',
		'Duration': '5d'        
	}
}"

# ReST request to create a task
Post-ReSTRequest $SiteUrl "ProjectServer/Projects('$projectid')/Tasks/Add" $body

# Resource parameters as JSON payload
$resourceid = [Guid]::NewGuid()
$body = "{
	'parameters': {
		'Id': '$resourceid',
		'Name': 'Resource_$resourceid'
	}
}"

# ReST request to create a local resource
Post-ReSTRequest $SiteUrl "ProjectServer/Projects('$projectid')/Draft/ProjectResources/Add" $body

# Enterprise resource parameters as JSON payload
$enterprise_resourceid = [Guid]::NewGuid()
$body = "{
	'parameters': {
		'Id': '$enterprise_resourceid',
		'Name': 'EnterpriseResource_$enterprise_resourceid'
	}
}"

# ReST request to create an enterprise resource
Post-ReSTRequest $SiteUrl "ProjectServer/EnterpriseResources/Add" $body

# ReST request to add an enterprise resource to the project team
Post-ReSTRequest $SiteUrl "ProjectServer/Projects('$projectid')/Draft/ProjectResources/AddEnterpriseResourceById('$enterprise_resourceid')"

# Assignment parameters as JSON payload
$body = "{
	'parameters': {
		'ResourceId': '$resourceid',
		'TaskId': '$taskid',
		'Notes': 'Created from PowerShell using REST API'
	}
}"

# ReST request to create an assignment for the local resource
Post-ReSTRequest $SiteUrl "ProjectServer/Projects('$projectid')/Draft/Assignments/Add" $body

# Assignment parameters as JSON payload
$body = "{
	'parameters': {
		'ResourceId': '$enterprise_resourceid',
		'TaskId': '$taskid',
		'Notes': 'Created from PowerShell using REST API'
	}
}"

# ReST request to create an assignment for the enterprise resource
Post-ReSTRequest $SiteUrl "ProjectServer/Projects('$projectid')/Draft/Assignments/Add" $body

# ReST request to publish and check-in the project
Post-ReSTRequest $SiteUrl "ProjectServer/Projects('$projectid')/Draft/publish(true)" $null
