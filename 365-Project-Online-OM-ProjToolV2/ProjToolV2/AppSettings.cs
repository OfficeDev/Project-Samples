/*
 * Copyright (c) Microsoft Corporation. All rights reserved. Licensed under the MIT license.
 * See LICENSE in the project root for license information.
 */

using ProjToolV2.Properties;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ProjToolV2
{
    public partial class AppSettings : BaseForm
    {
        public AppSettings()
        {
            InitializeComponent();
            Icon = Resources.Project;
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            LB_LogLevel.DataSource = Enum.GetNames(typeof(SourceLevels));
            LB_LogLevel.SelectedItem = Settings.Default.SourceLevel.ToString();
            LB_LogLevel.SelectedIndexChanged += LB_LogLevel_SelectedIndexChanged;
            CB_WaitForQueue.Checked = Settings.Default.WaitForQueue;
            CB_LoadAllProperties.Checked = Settings.Default.LoadAllProperties;

            LL_LogFolderLocation.Text = Path.GetDirectoryName(Log.FilePath);
            LL_LogFolderLocation.LinkClicked += LL_LogFolderLocation_LinkClicked;
            if (File.Exists(Log.FilePath))
            {
                LL_LogFileLocation.Text = Log.FilePath;
                LL_LogFileLocation.LinkClicked += LL_LogFileLocation_LinkClicked;
            }
            else
            {
                LL_LogFileLocation.Text = "Log File does not Exist";
            }
        }

        private static void LL_LogFileLocation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (File.Exists(Log.FilePath))
            {
                Process.Start(Log.FilePath);
            }
        }

        private static void LL_LogFolderLocation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(Path.GetDirectoryName(Log.FilePath));
        }

        private void CB_WaitForQueue_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.WaitForQueue = CB_WaitForQueue.Checked;
            Settings.Default.Save();
        }

        private void CB_LoadAllProperties_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.LoadAllProperties = CB_LoadAllProperties.Checked;
            Settings.Default.Save();
        }

        private void LB_LogLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default.SourceLevel = (SourceLevels)Enum.Parse(typeof(SourceLevels), LB_LogLevel.SelectedValue.ToString());
            Log.TraceSource.Switch.Level = Settings.Default.SourceLevel;
            Settings.Default.Save();
        }
    }
}