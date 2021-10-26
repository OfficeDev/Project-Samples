using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System.ServiceModel;
using Microsoft.Xrm.Sdk.Messages;

namespace PluginTest.Plugins
{
    public class ProjectBlockDeletePlugin : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            // Obtain the tracing service
            ITracingService tracingService =
            (ITracingService)serviceProvider.GetService(typeof(ITracingService));

            // Obtain the execution context from the service provider.  
            IPluginExecutionContext context = (IPluginExecutionContext)
                serviceProvider.GetService(typeof(IPluginExecutionContext));

            // The InputParameters collection contains all the data passed in the message request.  
            if (context.InputParameters.Contains("Target") &&
                context.InputParameters["Target"] is EntityReference)
            {
                // Obtain the target entity from the input parameters.  
                EntityReference projectEntityRef = context.InputParameters["Target"] as EntityReference;

                // Obtain the organization service reference which you will need for  
                // web service calls.  
                IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
                IOrganizationService service = serviceFactory.CreateOrganizationService(context.InitiatingUserId);

                try
                {
                    // TODO: Manually set which team has Delete privileges
                    Guid TeamWithDeletePrivilegeId = new Guid("0f96b130-c72c-ec11-b6e5-000d3a59eeac");

                    // Create the queryExpression for the team entity query
                    QueryExpression query = new QueryExpression("team");
                    query.ColumnSet = new ColumnSet("teamid");

                    // Create a Relationship collection query for the user <-> team relationship
                    Relationship teamMembershipRelationship = new Relationship("teammembership_association");
                    RelationshipQueryCollection relationshipCollectionQuery = new RelationshipQueryCollection();
                    relationshipCollectionQuery.Add(teamMembershipRelationship, query);

                    // Create a service RetrieveRequest with the system user - the user who launches the plugin - and all the teams the user is related to.
                    RetrieveRequest request = new RetrieveRequest();
                    request.RelatedEntitiesQuery = relationshipCollectionQuery;
                    request.Target = new EntityReference("systemuser", context.InitiatingUserId);
                    request.ColumnSet = new ColumnSet(true);

                    // Execute the RetrieveRequest
                    RetrieveResponse userWithTeamRelationships = (RetrieveResponse)service.Execute(request);

                    // Loop through all teams that the user is related to find if they belong the team with delete permissions
                    bool userCanDelete = false;
                    foreach (Entity entity in userWithTeamRelationships.Entity.RelatedEntities[teamMembershipRelationship].Entities)
                    {
                        if ((Guid)entity.Attributes["teamid"] == TeamWithDeletePrivilegeId)
                        {
                            userCanDelete = true;
                            break;
                        };
                    }

                    // Throw an exception if the user doesn't have permission to delete - aborting the Delete Operation.
                    if (!userCanDelete)
                    {

                        // Optional: retrieve the team name with delete priviledge for error message,
                        string TeamWithDeletePrivilegeName = service.Retrieve("team", TeamWithDeletePrivilegeId, new ColumnSet("name")).Attributes["name"].ToString();

                        throw new InvalidPluginExecutionException("You do not have permission to delete projects. Delete permission is only granted to members of the \"" + TeamWithDeletePrivilegeName + "\" team.");
                    }

                }

                catch (FaultException<OrganizationServiceFault> ex)
                {
                    throw new InvalidPluginExecutionException("An error occurred in ProjectBlockDeletePlugin.", ex);
                }

                catch (Exception ex)
                {
                    tracingService.Trace("ProjectBlockDetelePlugin: {0}", ex.ToString());
                    throw;
                }
            }
        }
    }
}

