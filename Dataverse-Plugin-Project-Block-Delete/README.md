# Dataverse Plugin to Block Project Deletion
In Project for the Web, any user that has a project shared with them can delete the entire project, without being able to revert the deletion if this was done by accident. Teammates can also delete shared projects without having a project license when using Project Power Apps. 

To limit this from happening, you can use Dataverse plug-ins to disable the delete operation on projects for a user based on any Dataverse condition that you determine. In the plug-in in this example, we will be removing the delete permission from a user that is not in a specific Team in Dataverse. Dataverse Teams can be backed by a M365 Group or created manually. 


## Scenario
As a Dataverse Admin, I want to limit who has permissions to delete projects in Project Power Apps and Project for the Web


## Prerequisites
To use this code sample, you need the Official Dataverse plug-in pre-requisites, which you can find [here](https://docs.microsoft.com/en-us/powerapps/developer/data-platform/tutorial-write-plug-in#prerequisites).

## How to use this solution
Please visit the Official documentation to [Write a Dataverse Plug-in](https://docs.microsoft.com/en-us/powerapps/developer/data-platform/tutorial-write-plug-in#prerequisites) for latest updates. A step-by step to use this sample plug-in is provided below for convenience.

**IMPORTANT:** In the code where marked TODO, you need to manually enter the Team Id give delete privileges to. You can find these in PowerApps Data Explorer.

1. **Sign the Assembly**: Right click the project in your Solution Explorer and press *Properties*. Go to the *Signing* tab, check Sign the assembly, Choose *<New…>* from the dropdown options and name your signature. Password is optional.
2. Build your solution by right clicking the project in your Solution Explorer and pressing *Build*.
3.	Launch the Plugin Registration Tool (installed in Prerequisites)
4.	Press the *Create New Connection* button at the top left and enter the account from which you want to register the plugin to Dataverse. 
5.	Register a new assembly.
6.	Load the assembly from the .dll previously built, which is stored in your project’s Debug folder.
7.	Press Register Selected Plugins.
8.	Find your Plugin Assembly in the list of Registered Plugins and right click to Register a new Step.
9.	Register the Pre-Validation Step that the Plug-in runs when a Delete operation is executed on a Project (msdyn_project) Entity.
10.	We’re done! You can now test manually in Project Power Apps and Project for the Web to verify functionality.

### Prerequisites

## Additional resources
* [Project Blog Post](https://msdn.microsoft.com/en-us/library/office/jj163123.aspx) on how to write this plug-in from scratch, with photos.
* [Official Dataverse Plug-In Documentation](https://docs.microsoft.com/en-us/powerapps/developer/data-platform/plug-ins)
## Copyright
Copyright (c) 2016 Microsoft. All rights reserved.
