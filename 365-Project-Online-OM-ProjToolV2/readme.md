# Project CSOM Tool (ProjToolV2)
This Project Online tool demonstrates how to use project server CSOM methods. It uses CSOM queries to create, read, update, or delete project server data.

## Prerequisites 
To use ProjToolV2, you need the following:
 - An Office 365 tenant with a Project license or a local project server Instance.
 - The SharePoint and Project libraries for [CSOM](https://www.nuget.org/packages/Microsoft.SharePointOnline.CSOM)

## Modules 
 1. Delete Objects (Provides ability to bulk delete objects from a project server instance )
     - Delete Enterprise Projects.
     - Delete Enterprise Resources.
     - Delete Enterprise Calendars.
     - Delete Enterprise Custom Fields.
     - Delete Enterprise Lookup Tables.
     - UI supports sorting objects.
 
 2. CheckIn/Out
      - Ability to force checkin/checkout projects.
      - Ablity to force checkin enterprise resources.
      - UI supports sorting objects.

 3. Publish
      - Full publish multiple projects with a single click.
      - UI supports sorting objects.
      
 4. Create (Provides ability to create bulk objects in a project server instance.)
      - Enterprise Projects
	  - Enterprise Resources
      - Custom Fields
      - Lookup Tables
 
 5. Update 
      Update enterprise Projects - Provides ability to select a project and update its properties.

## Settings

  - Load all properties settings throttle whether to load all project properties or just the default project properties on Update Project module.
  - Throttles the logging level, but defaults only exceptions are logged.
  - When operations goes thru queue, "Wait for Queue Jobs" settings determines whether to return immediatly of wait until the job is complete.

## Copyright
Copyright (c) 2016 Microsoft. All rights reserved.
