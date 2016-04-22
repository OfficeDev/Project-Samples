/*
 * Copyright (c) Microsoft Corporation. All rights reserved. Licensed under the MIT license.
 * See LICENSE in the project root for license information.
 */

using Microsoft.ProjectServer.Client;
using ProjToolV2.Properties;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProjToolV2
{
    public partial class CustomFieldsCreation : BaseForm
    {
        private BackgroundExecutorWithStatus _backgroundExecutorWithStatus;

        public CustomFieldsCreation()
        {
            InitializeComponent();
            Icon = Resources.Project;
        }

        private void CustomFieldsCreation_Load(object sender, EventArgs e)
        {
            CB_Type.DataSource = Enum.GetValues(typeof(CustomFieldType));
            CB_Type.SelectedItem = CustomFieldType.TEXT;

            Dictionary<string, EntityType> entityType = new Dictionary<string, EntityType>
            {
                {"Task", ProjContext.EntityTypes.TaskEntity},
                {"Resource", ProjContext.EntityTypes.ResourceEntity},
                {"Project", ProjContext.EntityTypes.ProjectEntity}
            };
            CB_EntityType.DataSource = new BindingSource(entityType, null);
            CB_EntityType.DisplayMember = "Key";
            CB_EntityType.ValueMember = "Value";
            CB_EntityType.SelectedIndex = 2;

            _backgroundExecutorWithStatus = new BackgroundExecutorWithStatus(TB_Status, "Loading LookupTables");
            _backgroundExecutorWithStatus.ExecuteWorker(LoadLookupTables);
        }

        private void LoadLookupTables()
        {
            IEnumerable<LookupTable> lookupTables1 = ProjContext.LoadQuery(ProjContext.LookupTables);
            ProjContext.ExecuteQuery();
            Dictionary<string, LookupTable> lookupTables = new Dictionary<string, LookupTable> { { "Select", null } };
            foreach (LookupTable lt in lookupTables1)
            {
                lookupTables.Add(lt.Name, lt);
            }
            CB_LookupTable.InvokeIfRequired(cb =>
                   {
                       cb.DataSource = new BindingSource(lookupTables, null);
                       cb.DisplayMember = "Key";
                       cb.ValueMember = "Value";
                   });
        }

        private void BTN_Create_Click(object sender, EventArgs e)
        {
            BackgroundExecutorWithStatus bews = new BackgroundExecutorWithStatus(TB_Status, "Creating CustomFields");
            bews.ExecuteWorker(CreateCustomFields);
        }

        private void CreateCustomFields()
        {
            EntityType entityType = ProjContext.EntityTypes.ProjectEntity;
            CustomFieldType customFieldType = CustomFieldType.TEXT;
            LookupTable selectedLookupTable = null;
            bool allowMultiSelect = false;

            CB_EntityType.InvokeIfRequired(cb => entityType = cb.SelectedValue as EntityType);
            CB_Type.InvokeIfRequired(sb => customFieldType = (CustomFieldType)CB_Type.SelectedValue);
            CB_LookupTable.InvokeIfRequired(cb =>
                   {
                       if (cb.SelectedIndex <= 0) return;
                       selectedLookupTable = cb.SelectedValue as LookupTable;
                       if (CBX_AllowMultiSelect.Checked)
                           allowMultiSelect = true;
                   });
            for (int customFieldCount = 1; customFieldCount <= Convert.ToInt32(NUD_CFNumber.Value); customFieldCount++)
            {
                CustomFieldCreationInformation cfCi = new CustomFieldCreationInformation
                {
                    Name = TB_Name.Text + customFieldCount,
                    EntityType = entityType,
                    FieldType = customFieldType
                };
                Log.WriteVerbose(new SourceInfo(), TB_Status, "Creating custom field with name {0}", cfCi.Name);
                if (selectedLookupTable != null)
                {
                    cfCi.LookupTable = selectedLookupTable;
                    Log.WriteVerbose(new SourceInfo(), TB_Status, "Setting custom field to use lookup table {0}", selectedLookupTable.Name);
                }

                cfCi.LookupAllowMultiSelect = allowMultiSelect;
                ProjContext.CustomFields.Add(cfCi);
            }
            ProjContext.CustomFields.Update();
            ProjContext.ExecuteQuery();
        }

        private void BTN_Back_Click(object sender, EventArgs e)
        {
            _backgroundExecutorWithStatus?.Cancel();
        }

        private void BTN_Cancel_Click(object sender, EventArgs e)
        {
            Visible = false;
        }
    }
}