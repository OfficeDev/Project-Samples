/*
 * Copyright (c) Microsoft Corporation. All rights reserved. Licensed under the MIT license.
 * See LICENSE in the project root for license information.
 */

using ProjToolV2.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ProjToolV2
{
    public partial class ServerMain : BaseForm
    {
        private readonly List<FlowLayoutPanel> _panelCache = new List<FlowLayoutPanel>();

        public ServerMain()
        {
            Icon = Resources.Project;
            InitializeComponent();
            Log.WriteVerbose(new SourceInfo(), "***** Application Started. *****");
        }

        private void BTN_Exit_Click(object sender, EventArgs e)
        {
            if (!ResetDisplayPanel())
            {
                Application.Exit();
            }
        }

        private void BTN_LoginAgain_Click(object sender, EventArgs e)
        {
            HandleLogin();
        }

        private bool HandleLogin()
        {
            bool loginSucess = false;
            LBL_MainText.Hide();
            foreach (Control ctrl in TLP_Main.Controls)
            {
                if (!(ctrl is FlowLayoutPanel) || ctrl.Tag == null || ctrl.Tag.ToString() != "DisplayForm") continue;
                FlowLayoutPanel flp = ctrl as FlowLayoutPanel;
                Log.WriteVerbose(new SourceInfo(), "Clearing Panel:{0} and its controls", flp.Name);
                flp.Controls.Clear();
                _panelCache.Remove(ctrl as FlowLayoutPanel);
                TLP_Main.Controls.Remove(ctrl);
            }

            CsomBase.ClearCsomObjects();
            ResetDisplayPanel();
            using (LoginPage lgf = new LoginPage())
            {
                lgf.StartPosition = FormStartPosition.CenterParent;
                DialogResult dr = lgf.ShowDialog(this);
                if (dr != DialogResult.Cancel)
                {
                    Log.WriteVerbose(new SourceInfo(), "Login successful. Displaying user properties on the main form header.");
                    TB_DisplayName.Text = CsomBase.CurrentUser.Title;
                    TB_UserName.Text = CsomBase.CurrentUser.LoginName;
                    TB_Email.Text = CsomBase.CurrentUser.Email;
                    TB_Url.Text = CsomBase.CurrentUser.Context.Url;
                    loginSucess = true;
                }
                else
                {
                    Log.WriteVerbose(new SourceInfo(), "Login failed.");
                }
            }
            return loginSucess;
        }

        private void BTN_ProjectCreate_Click(object sender, EventArgs e)
        {
            ProjectsCreation psc = new ProjectsCreation();
            AddDisplayPanel(psc, "Bulk Create Projects");
        }

        private void BTN_Resources_Click(object sender, EventArgs e)
        {
            ResourcesCreation rc = new ResourcesCreation();
            AddDisplayPanel(rc, "Bulk Create Resources");
        }

        private void BTN_CustomFields_Click(object sender, EventArgs e)
        {
            CustomFieldsCreation cfc = new CustomFieldsCreation();
            AddDisplayPanel(cfc, "Bulk Create Custom Fields");
        }

        private void BTN_LookupTables_Click(object sender, EventArgs e)
        {
            LookupTablesCreation ltc = new LookupTablesCreation();
            AddDisplayPanel(ltc, "Bulk Create Lookup Tables");
        }

        private void BTN_ServerObjectsDelete_Click(object sender, EventArgs e)
        {
            ServerObjectsDelete sod = new ServerObjectsDelete();
            AddDisplayPanel(sod, "Delete Enterprise Objects");
        }

        private void BTN_ProjectTeam_Click(object sender, EventArgs e)
        {
            ProjectTeamBuilder ptm = new ProjectTeamBuilder();
            AddDisplayPanel(ptm, "Add or Remove Resources from the Project");
        }

        private void BTN_CheckInCheckOut_Click(object sender, EventArgs e)
        {
            CheckInCheckOut cico = new CheckInCheckOut();
            AddDisplayPanel(cico, "Checkin/Checkout server objects");
        }

        private void BTN_Publish_Click(object sender, EventArgs e)
        {
            ProjectsPublish pp = new ProjectsPublish();
            AddDisplayPanel(pp, "Publish Projects");
        }

        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ServerMain());
        }

        private void ServerMain_Load(object sender, EventArgs e)
        {
            HandleLogin();
        }

        private void AddDisplayPanel(Form formToDisplay, string title)
        {
            ResetDisplayPanel();
            if (CsomBase.CurrentUser == null)
            {
                if (!HandleLogin())
                {
                    return;
                }
            }
            LBL_MainText.Text = title;
            LBL_MainText.Show();

            FlowLayoutPanel existingPanel = _panelCache.FirstOrDefault(p => p.Name == formToDisplay.Name);
            if (existingPanel != null)
            {
                existingPanel.Controls[0].Visible = true;
                existingPanel.Visible = true;
                Log.WriteVerbose(new SourceInfo(), "Found pre-loaded form:{0}", formToDisplay.Name);
            }
            else
            {
                Log.WriteVerbose(new SourceInfo(), "No existing form:{0}. Creating a new panel and loading the form.", formToDisplay.Name);
                existingPanel = new FlowLayoutPanel
                {
                    Name = formToDisplay.Name,
                    Dock = DockStyle.Fill,
                    Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top,
                    AutoSize = true
                };
                existingPanel.Resize += FlowLayoutPanel_Resize;
                existingPanel.Tag = "DisplayForm";
                formToDisplay.TopLevel = false;
                formToDisplay.StartPosition = FormStartPosition.Manual;
                formToDisplay.FormBorderStyle = FormBorderStyle.None;
                formToDisplay.Padding = new Padding(0, 0, 13, 8);
                TLP_Main.Controls.Add(existingPanel, 0, 2);
                formToDisplay.Show();
                existingPanel.Controls.Add(formToDisplay);
                FlowLayoutPanel_Resize(existingPanel, null);
                existingPanel.Focus();
                _panelCache.Add(existingPanel);
            }
        }

        private void FlowLayoutPanel_Resize(object sender, EventArgs e)
        {
            FlowLayoutPanel flp = sender as FlowLayoutPanel;
            if (flp.ClientSize == new Size(0, 0) || flp.Controls.Count <= 0) return;
            flp.SuspendLayout();
            TableLayoutPanelCellPosition pos = TLP_Main.GetCellPosition(flp);
            int width = TLP_Main.GetColumnWidths()[pos.Column];
            int height = TLP_Main.GetRowHeights()[pos.Row];
            Size size = new Size(width, height);
            flp.Controls[0].ClientSize = size;
            flp.ResumeLayout();
        }

        private bool ResetDisplayPanel()
        {
            bool controlVisible = false;
            foreach (Control ctrl in TLP_Main.Controls)
            {
                FlowLayoutPanel panel = ctrl as FlowLayoutPanel;
                if (panel != null && ctrl.Tag != null && ctrl.Tag.ToString() == "DisplayForm" && ctrl.Visible)
                {
                    ctrl.Visible = false;
                    TLP_Main.Refresh();
                    LBL_MainText.Text = "";
                    controlVisible = true;
                }
            }
            return controlVisible;
        }

        private void BTN_Owner_Click(object sender, EventArgs e)
        {
            ProjectOwner po = new ProjectOwner();
            AddDisplayPanel(po, "Change Project Ownership");
        }

        private void BTN_Settings_Click(object sender, EventArgs e)
        {
            AppSettings ast = new AppSettings();
            AddDisplayPanel(ast, "Settings");
        }

        private void BTN_Logs_Click(object sender, EventArgs e)
        {
            if (Log.FilePath != null && File.Exists(Log.FilePath))
            {
                Process.Start(Log.FilePath);
            }
        }

        private void BTN_Refresh_Click(object sender, EventArgs e)
        {
            FlowLayoutPanel flp = GetCurrentActivePanel();
            if (flp == null) return;
            Form newForm = (Control)Activator.CreateInstance(flp.Controls[0].GetType()) as Form;
            string currentTitle = LBL_MainText.Text;
            Log.WriteVerbose(new SourceInfo(), "Clearing Panel:{0} and its controls", flp.Name);
            flp.Controls.Clear();
            _panelCache.Remove(flp);
            TLP_Main.Controls.Remove(flp);
            ResetDisplayPanel();
            AddDisplayPanel(newForm, currentTitle);
        }

        private void BTN_PopOut_Click(object sender, EventArgs e)
        {
            FlowLayoutPanel flp = GetCurrentActivePanel();
            Form currentForm = flp?.Controls[0] as Form;
            if (currentForm == null) return;
            currentForm.Opacity = 0;
            currentForm.Visible = false;
            flp.Controls.Remove(currentForm);
            TLP_Main.Controls.Remove(flp);
            currentForm.FormBorderStyle = FormBorderStyle.Fixed3D;
            currentForm.ShowInTaskbar = false;
            currentForm.TopLevel = true;
            currentForm.WindowState = FormWindowState.Maximized;
            currentForm.Opacity = 1;
            currentForm.ShowDialog();
            currentForm.TopLevel = false;
            flp.Controls.Add(currentForm);
            currentForm.FormBorderStyle = FormBorderStyle.None;
            TLP_Main.Controls.Add(flp);
            currentForm.Visible = true;
        }

        private FlowLayoutPanel GetCurrentActivePanel()
        {
            return TLP_Main.Controls.Cast<Control>()
                .Where(
                    ctrl =>
                        ctrl is FlowLayoutPanel && ctrl.Tag != null && ctrl.Tag.ToString() == "DisplayForm" &&
                        ctrl.Visible)
                .Select(ctrl => ctrl as FlowLayoutPanel).FirstOrDefault();
        }

        private void ServerMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Log.WriteVerbose(new SourceInfo(), "***** Application Exited. *****");
        }

        private void BTN_ProjectUpdate_Click(object sender, EventArgs e)
        {
            ProjectUpdater pu = new ProjectUpdater();
            AddDisplayPanel(pu, "Read/Update Project.");
        }
    }
}