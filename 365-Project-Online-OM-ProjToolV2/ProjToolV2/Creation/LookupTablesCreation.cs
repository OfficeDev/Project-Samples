/*
 * Copyright (c) Microsoft Corporation. All rights reserved. Licensed under the MIT license.
 * See LICENSE in the project root for license information.
 */

using Microsoft.ProjectServer.Client;
using ProjToolV2.Properties;
using System;
using System.Collections.Generic;

namespace ProjToolV2
{
    public partial class LookupTablesCreation : BaseForm
    {
        private BackgroundExecutorWithStatus _backgroundExecutorWithStatus;

        public LookupTablesCreation()
        {
            InitializeComponent();
            Icon = Resources.Project;
        }

        private void LookupTablesCreation_Load(object sender, EventArgs e)
        {
            CB_Sort.DataSource = Enum.GetValues(typeof(LookupTableSortOrder));
            CB_Sort.SelectedItem = LookupTableSortOrder.Ascending;
        }

        private void BTN_Create_Click(object sender, EventArgs e)
        {
            _backgroundExecutorWithStatus = new BackgroundExecutorWithStatus(TB_Status, "Creating Text LookupTables");
            _backgroundExecutorWithStatus.ExecuteWorker(CreateLookupTables);
        }

        private void CreateLookupTables()
        {
            for (int lookupTableCount = 1; lookupTableCount <= Convert.ToInt32(NUD_LTNumber.Value); lookupTableCount++)
            {
                List<LookupMask> masks = new List<LookupMask>();
                for (int levelCount = 0; levelCount <= Convert.ToInt32(NUD_Levels.Value); levelCount++)
                {
                    LookupMask lkm = new LookupMask
                    {
                        Length = 0,
                        MaskType = LookupTableMaskSequence.CHARACTERS,
                        Separator = "."
                    };
                    masks.Add(lkm);
                }

                List<LookupEntryCreationInformation> lookupEntry = new List<LookupEntryCreationInformation>();
                for (int levelCount = 1; levelCount <= Convert.ToInt32(NUD_Levels.Value); levelCount++)
                {
                    //creating the parent level
                    LookupEntryCreationInformation parentCi = new LookupEntryCreationInformation
                    {
                        Id = Guid.NewGuid(),
                        SortIndex = 0,
                        Value =
                            new LookupEntryValue { TextValue = RandomEx.RandomString(Convert.ToInt32(NUD_Length.Value)) }
                    };
                    lookupEntry.Add(parentCi);

                    //creating the child levels
                    for (int subLevel = 1; subLevel <= Convert.ToInt32(NUD_ValuePerLevel.Value); subLevel++)
                    {
                        LookupEntryCreationInformation childCi = new LookupEntryCreationInformation
                        {
                            Id = Guid.NewGuid(),
                            ParentId = parentCi.Id,
                            SortIndex = 0,
                            Value =
                                new LookupEntryValue
                                {
                                    TextValue = RandomEx.RandomString(Convert.ToInt32(NUD_Length.Value))
                                }
                        };
                        lookupEntry.Add(childCi);
                    }
                }

                LookupTableSortOrder lookupTableSortOrder = LookupTableSortOrder.Ascending;
                CB_Sort.InvokeIfRequired(cb => lookupTableSortOrder = (LookupTableSortOrder)cb.SelectedValue);

                LookupTableCreationInformation ltCi = new LookupTableCreationInformation
                {
                    Name = TB_Name.Text + lookupTableCount,
                    Masks = masks,
                    SortOrder = lookupTableSortOrder,
                    Entries = lookupEntry
                };
                Log.WriteVerbose(new SourceInfo(), TB_Status, "Creating lookup field with name {0}", ltCi.Name);
                ProjContext.LookupTables.Add(ltCi);
            }
            ProjContext.LookupTables.Update();
            ProjContext.ExecuteQuery();
        }

        private void BTN_Cancel_Click(object sender, EventArgs e)
        {
            _backgroundExecutorWithStatus?.Cancel();
        }

        private void BTN_Back_Click(object sender, EventArgs e)
        {
            Visible = false;
        }
    }
}