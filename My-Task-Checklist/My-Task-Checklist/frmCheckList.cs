using Microsoft.ProjectServer.Client;
using Microsoft.SharePoint.Client;
using MSDN.Samples.ClaimsAuth;
using System;

using System.Linq;
using System.Windows.Forms;

namespace MyTaskCheckList
{


    public partial class frmMyCheckList : System.Windows.Forms.Form
    {
        private ProjectContext projContext;
        private EnterpriseResource self;

        public frmMyCheckList()
        {
            InitializeComponent();
        }

        private void chkAssignments_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            Assignment assignment = (Assignment)chkAssignments.Items[e.Index];

            if (e.NewValue == CheckState.Checked)
            {
                assignment.Done = true;
            }
            else
            {
                assignment.Done = false;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            try
            {
                Cursor = Cursors.WaitCursor;

                Assignment assignment;

                // Loop through each assignment and update % complete
                for (int j = 0; j < chkAssignments.Items.Count; j++)
                {
                    assignment = (Assignment)chkAssignments.Items[j];

                    if (assignment.Dirty)
                    {
                        if (assignment.Done)
                        {
                            self.Assignments.GetByGuid(assignment.ID).PercentComplete = 100;
                        }
                        else
                        {
                            self.Assignments.GetByGuid(assignment.ID).PercentComplete = 0;
                        }
                    }
                }


                // Update the assignments and submit the status updates.
                self.Assignments.Update();

                self.Assignments.SubmitAllStatusUpdates("");
                projContext.ExecuteQuery();




                Cursor = Cursors.Arrow;


                // Loop through each assignment and update % complete
                for (int j = 0; j < chkAssignments.Items.Count; j++)
                {
                    assignment = (Assignment)chkAssignments.Items[j];
                    assignment.Dirty = false;

                }


                MessageBox.Show(this, "Your updates have been submitted.", "Changes submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ClientRequestException cre)
            {
                Cursor = Cursors.Arrow;
                string msg = string.Format("Error: \n\n{1}", cre.GetBaseException().ToString());
                throw new ArgumentException(msg);
            }

            catch (Exception ex)
            {
                Cursor = Cursors.Arrow;
                string msg = string.Format("Error: \n\n{1}", ex.ToString());
                throw new ArgumentException(msg);
            }



        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectToPWA();
                if (projContext != null)
                {
                    LoadAssignments();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ConnectToPWA()
        {

            projContext = ClaimClientContext.GetAuthenticatedContext<ProjectContext>(txtPWASite.Text);
        }

        private void LoadAssignments()
        {
            try
            {
                // Get the user name  and their assignments
                self = EnterpriseResource.GetSelf(projContext);
                projContext.Load(self, r => r.Name, r => r.Assignments.IncludeWithDefaultProperties(assignment => assignment.Project));
                projContext.ExecuteQuery();

                lblUserName.Text = String.Format("Welcome {0}", self.Name);
                // Get the assignments and Project Name for the resource
                

                string name;
                Guid id;

                // Add each assignment to the list checkbox
                for (int j = 0; j < self.Assignments.Count; j++)
                {
                    name = self.Assignments.ElementAt(j).Project.Name + ": " + self.Assignments.ElementAt(j).Name;
                    id = self.Assignments.ElementAt(j).Id;

                    Assignment assignment;
                    if (self.Assignments.ElementAt(j).PercentComplete < 100)
                    {
                        assignment = new Assignment(name, id, false);
                        chkAssignments.Items.Add(assignment);
                    }
                    else
                    {
                        assignment = new Assignment(name, id, true);
                        chkAssignments.Items.Add(assignment, true);
                    }

                    assignment.Dirty = false;
                }

            }
            catch (ClientRequestException cre)
            {
                string msg = string.Format("Error: \n\n{1}", cre.GetBaseException().ToString());
                throw new ArgumentException(msg);
            }

            catch (Exception ex)
            {

                string msg = string.Format("Error: \n\n{1}", ex.ToString());
                throw new ArgumentException(msg);
            }

        }

    }
}
