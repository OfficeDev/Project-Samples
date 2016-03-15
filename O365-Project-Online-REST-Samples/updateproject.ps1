# Updates a Project using ReST API
param
(
    # SharepointOnline project site collection URL
    $SiteUrl = $(throw "SiteUrl parameter is required"),
    $projectId = $(throw "projectId parameter is required"),
    $taskId,
    $resourceId,
	$assignmentId
)
# Load ReST helper methods
. .\ReST.ps1

# Set up the request authentication
Set-SPOAuthenticationTicket $siteUrl
Set-DigestValue $siteUrl

# ReST request to check out the project
Post-ReSTRequest $SiteUrl "ProjectServer/Projects('$projectid')/checkOut" $null

# ReST request to update the project description
$body = "{'Description':'Updated from PowerShell using REST API'}"
Patch-ReSTRequest $SiteUrl "ProjectServer/Projects('$projectid')/Draft" $body

# ReST request to update the task duration and start date
if (-not [String]::IsNullOrEmpty($taskId))
{
	$body = "{'Duration':'10d','Start':'2016-01-06T08:00:00'}"
	Patch-ReSTRequest $SiteUrl "ProjectServer/Projects('$projectid')/Draft/Tasks('$taskId')" $body
}

# ReST request to update the resource rate
if (-not [String]::IsNullOrEmpty($resourceId))
{
	$body = "{'StandardRate':'100'}"
	Patch-ReSTRequest $SiteUrl "ProjectServer/Projects('$projectid')/Draft/ProjectResources('$resourceId')" $body
}

# ReST request to update the assignment completion and work
if (-not [String]::IsNullOrEmpty($assignmentId))
{
	$body = "{'PercentWorkComplete':'50','ActualWork':'10h'}"
	Patch-ReSTRequest $SiteUrl "ProjectServer/Projects('$projectid')/Draft/Assignments('$assignmentId')" $body
}

# ReST request to publish and check-in the project
Post-ReSTRequest $SiteUrl "ProjectServer/Projects('$projectid')/Draft/publish(true)" $null

