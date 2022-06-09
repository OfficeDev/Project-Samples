# Copy Work Packages

The Copy Work Packages sample code demonstrates how to query for projects and tasks and create tasks using JSOM (CSOM).  

## Scenario
I have a common set of well-defined tasks (work packages) that I would like to re-use in many of my projects.  I want to be able to easily select the work package and choose the project/task to copy the work package under.

## Setup 

1.	Create one or more projects that have a set of tasks that you would like to re-use.
2.	Create a summary task to group the set and give it a meaningful description.  
3.	Publish the project.

### Using the app

1.	Choose the (source) project containing the work package you are looking for.
2.	Choose the work package (summary task).
3.	Choose the (target) project you want to copy the work package to.
4.	Choose a parent task where the work package will be copied to.
5.	Click Submit.


### Prerequisites/Deployment
To use this code sample, you need the following:
* Project Server 2013 or Project Online (with subscription)
* Visual Studio 2013 or later 
* App for SharePoint project type
* Update the project site Url (Project Property) to match the site you are testing against.
* If you are not using a Developer site collection, you may need to enable [Side Loading](https://blogs.msdn.microsoft.com/officeapps/2013/12/10/enable-app-sideloading-in-your-non-developer-site-collection/)



## How the sample affects your tenant data
This sample runs CSOM methods that read project and read/create task data. Tenant data will be affected.

## Additional resources
* [PS namespace (ps.js)](https://msdn.microsoft.com/en-us/library/office/jj669820.aspx)
* [Client-side object model (CSOM) for Project 2013](https://msdn.microsoft.com/en-us/library/office/jj163123.aspx)
* [SharePoint and Project Online SDK](https://www.nuget.org/packages/Microsoft.SharePointOnline.CSOM)

## Copyright
Copyright (c) 2016 Microsoft. All rights reserved.
