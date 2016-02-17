using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

using Microsoft.SharePoint.Client;
using csom = Microsoft.ProjectServer.Client;

namespace CreateUpdateProjectSample
{
    partial class CreateUpdateProjectSample
    {
        public static string pwaInstanceUrl = "http://localhost/pwa/";         // your pwa url
        private static csom.ProjectContext context;
        const int DEFAULTTIMEOUTSECONDS = 300;

        private static string projectName = "New Project";
        private static string localResourceName = "New Local Resource";
        private static string taskName = "New Task";

        private static string projectCFName = "Project custom field";
        private static string resourceCFName = "Resource custom field";
        private static string taskCFName = "Task custom field";

        static void Main(string[] args)
        {
            CreateProjectWithTaskAndAssignment();
            ReadAndUpdateProject();
            UpdateCustomFieldValues();
        }

        #region Utility functions
        /// <summary>
        /// Log to Console the job state for queued jobs
        /// </summary>
        /// <param name="jobState">csom jobstate</param>
        /// <param name="jobDescription">job description</param>
        private static void JobStateLog(csom.JobState jobState, string jobDescription)
        {
            switch (jobState)
            {
                case csom.JobState.Success:
                    Console.WriteLine(jobDescription + " is successfully done.");
                    break;
                case csom.JobState.ReadyForProcessing:
                case csom.JobState.Processing:
                case csom.JobState.ProcessingDeferred:
                    Console.WriteLine(jobDescription + " is taking longer than usual.");
                    break;
                case csom.JobState.Failed:
                case csom.JobState.FailedNotBlocking:
                case csom.JobState.CorrelationBlocked:
                    Console.WriteLine(jobDescription + " failed. The job is in state: " + jobState);
                    break;
                default:
                    Console.WriteLine("Unkown error, job is in state " + jobState);
                    break;
            }
        }

        /// <summary>
        /// Get Publish project by name
        /// </summary>
        /// <param name="name">the name of the project</param>
        /// <param name="context">csom context</param>
        /// <returns></returns>
        private static csom.PublishedProject GetProjectByName(string name, csom.ProjectContext context)
        {
            IEnumerable<csom.PublishedProject> projs = context.LoadQuery(context.Projects.Where(p => p.Name == name));
            context.ExecuteQuery();

            if (!projs.Any())       // no project found
            { 
                return null;
            }
            return projs.FirstOrDefault();
        }

        /// <summary>
        /// Get csom ProjectContext by letting user type in username and password
        /// </summary>
        /// <param name="url">pwa website url string</param>
        /// <returns></returns>
        private static csom.ProjectContext GetContext(string url)
        {
            csom.ProjectContext context = new csom.ProjectContext(url);
            string userName, passWord;

            Console.WriteLine("Please enter your username for PWA");
            userName = Console.ReadLine();
            Console.WriteLine("Please enter your password for PWA");
            passWord = Console.ReadLine();

            NetworkCredential netcred = new NetworkCredential(userName, passWord);
            SharePointOnlineCredentials orgIDCredential = new SharePointOnlineCredentials(netcred.UserName, netcred.SecurePassword);
            context.Credentials = orgIDCredential;

            return context;
        }

        #endregion
    }
}
