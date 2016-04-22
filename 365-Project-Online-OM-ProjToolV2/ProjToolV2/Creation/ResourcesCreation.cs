/*
 * Copyright (c) Microsoft Corporation. All rights reserved. Licensed under the MIT license.
 * See LICENSE in the project root for license information.
 */

using Microsoft.ProjectServer.Client;
using ProjToolV2.Properties;
using System;

namespace ProjToolV2
{
    public partial class ResourcesCreation : BaseForm
    {
        private BackgroundExecutorWithStatus _backgroundExecutorWithStatus;

        public ResourcesCreation()
        {
            InitializeComponent();
            Icon = Resources.Project;
        }

        private void BTN_Create_Click(object sender, EventArgs e)
        {
            _backgroundExecutorWithStatus = new BackgroundExecutorWithStatus(TB_Status, "Creating Enterprise Resources");
            _backgroundExecutorWithStatus.ExecuteWorker(CreateResources);
        }

        private void CreateResources()
        {
            EnterpriseResourceType selectedEnterpriseResourceType = EnterpriseResourceType.Work;
            cbxResType.InvokeIfRequired(s => selectedEnterpriseResourceType = (EnterpriseResourceType)cbxResType.SelectedValue);
            for (int resourceCount = 1; resourceCount <= numResources.Value; resourceCount++)
            {
                EnterpriseResourceCreationInformation erCi = new EnterpriseResourceCreationInformation
                {
                    Name = txtResourceName.Text + resourceCount,
                    IsInactive = CB_Inactive.Checked,
                    IsGeneric = CB_Generic.Checked,
                    IsBudget = CB_Budget.Checked,
                    ResourceType = selectedEnterpriseResourceType
                };
                Log.WriteVerbose(new SourceInfo(), TB_Status, "Creating Resource with name {0}", erCi.Name);
                ProjContext.EnterpriseResources.Add(erCi);
            }
            ProjContext.EnterpriseResources.Update();
            ProjContext.ExecuteQuery();
        }

        private void ResourcesCreation_Load(object sender, EventArgs e)
        {
            cbxResType.DataSource = Enum.GetValues(typeof(EnterpriseResourceType));
            cbxResType.SelectedItem = EnterpriseResourceType.Work;
        }

        private void BTN_Back_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void BTN_Cancel_Click(object sender, EventArgs e)
        {
            _backgroundExecutorWithStatus?.Cancel();
        }
    }
}