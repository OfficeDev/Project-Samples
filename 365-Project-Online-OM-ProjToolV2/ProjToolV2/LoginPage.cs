/*
 * Copyright (c) Microsoft Corporation. All rights reserved. Licensed under the MIT license.
 * See LICENSE in the project root for license information.
 */

using Microsoft.ProjectServer.Client;
using Microsoft.SharePoint.Client;
using ProjToolV2.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Security;
using System.Windows.Forms;
using Resources = ProjToolV2.Properties.Resources;

namespace ProjToolV2
{
    public partial class LoginPage : BaseForm
    {
        private BackgroundExecutorWithStatus _bge;

        public LoginPage()
        {
            Icon = Resources.Project;
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            Settings.Default.Url = TB_Url.Text;
            Settings.Default.UserName = TB_UserName.Text;
            Settings.Default.WindowsAuthenticationMode = RB_Windows.Checked;
            Settings.Default.ProjectOnLine = CB_Online.Checked;
            Settings.Default.Save();

            _bge = new BackgroundExecutorWithStatus(LBL_Status, "Authenticating");
            _bge.ExecuteWorker(LoginProjectServer);
        }

        private void LoginProjectServer()
        {
            Log.WriteVerbose(new SourceInfo(), "Logging into project server on url:{0}", TB_Url.Text);
            ProjContext = new ProjectContext(TB_Url.Text);
            Log.WriteVerbose(new SourceInfo(), "Authenticating against {0} pwa instance", CB_Online.Checked ? "Online" : "OnPerm");

            if (CB_Online.Checked && RB_Forms.Checked)
            {
                //case online with user credential
                SecureString secpassword = new SecureString();
                foreach (char c in TB_Password.Text) secpassword.AppendChar(c);
                ProjContext.Credentials = new SharePointOnlineCredentials(TB_UserName.Text, secpassword);
            }
            else if (!CB_Online.Checked && RB_Forms.Checked)
            {
                //case onprem with user credential
                ProjContext.AuthenticationMode = ClientAuthenticationMode.FormsAuthentication;
                FormsAuthenticationLoginInfo formsAuthInfo = new FormsAuthenticationLoginInfo(TB_UserName.Text, TB_Password.Text);
                ProjContext.FormsAuthenticationLoginInfo = formsAuthInfo;
            }
            else
            {
                //Default case - Windows Auth
                ProjContext.Credentials = CredentialCache.DefaultCredentials;
            }
            CsomHelper.ProjContext = ProjContext;
            CsomBase.CurrentResource = CsomHelper.LoadMe();
            CsomBase.CurrentUser = CsomBase.CurrentResource.User;
            if (_bge.TaskCancelled || _bge.ActionTask.IsFaulted)
            {
                return;
            }
            Log.WriteVerbose(new SourceInfo(), "Login on url:{0} for user:{1}", TB_Url.Text, CsomBase.CurrentUser.Title);
            DialogResult = DialogResult.OK;
        }

        private void BTN_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
            Log.WriteVerbose(new SourceInfo(), "Loading Login form...");
            if (Settings.Default.Url == string.Empty)
            {
                Log.WriteVerbose(new SourceInfo(), "No server url found from saved settings. Setting the server url to be local server.");
                TB_Url.Text = "http://" + Environment.MachineName + "/pwa";
            }
            else
            {
                Log.WriteVerbose(new SourceInfo(), "Loading server url from saved settings.");
                TB_Url.Text = Settings.Default.Url;
            }
            CB_Online.Checked = Settings.Default.ProjectOnLine;
            RB_Windows.Checked = Settings.Default.WindowsAuthenticationMode;
            RB_Forms.Checked = !Settings.Default.WindowsAuthenticationMode;
        }

        private void LoginPage_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void BTN_Cancel_Click(object sender, EventArgs e)
        {
            _bge?.Cancel();
        }

        private void RB_Forms_CheckedChanged(object sender, EventArgs e)
        {
            TB_UserName.Enabled = RB_Forms.Checked;
            TB_Password.Enabled = RB_Forms.Checked;
        }

        private bool _mouseDown;
        private Point _lastLocation;

        private void LBL_Title_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseDown = true;
            _lastLocation = e.Location;
        }

        private void LBL_Title_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_mouseDown) return;
            Location = new Point(
                Location.X - _lastLocation.X + e.X, Location.Y - _lastLocation.Y + e.Y);

            Update();
        }

        private void LBL_Title_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseDown = false;
        }

        private void RB_Windows_CheckedChanged(object sender, EventArgs e)
        {
            TB_UserName.Enabled = RB_Forms.Checked;
            TB_Password.Enabled = RB_Forms.Checked;
        }
    }
}