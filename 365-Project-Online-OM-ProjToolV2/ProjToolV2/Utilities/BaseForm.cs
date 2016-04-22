/*
 * Copyright (c) Microsoft Corporation. All rights reserved. Licensed under the MIT license.
 * See LICENSE in the project root for license information.
 */

using Microsoft.ProjectServer.Client;
using System;
using System.Windows.Forms;
using Task = System.Threading.Tasks.Task;

namespace ProjToolV2
{
    public class BaseForm : Form
    {
        internal static ProjectContext ProjContext { get; set; }

        public enum ServerObjectType
        {
            Project,
            Resource,
            Calendar,
            CustomField,
            LookupTable
        }

        public BaseForm()
        {
            Opacity = 0;
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            if (Visible)
            {
                FadeIn();
            }
            else
            {
                FadeOut();
            }
            base.OnVisibleChanged(e);
        }

        private async void FadeIn(int interval = 50)
        {
            while (Opacity < 1.0)
            {
                await Task.Delay(interval);
                Opacity += 0.05;
            }
            Opacity = 1;
        }

        private async void FadeOut(int interval = 50)
        {
            while (Opacity > 0.0)
            {
                await Task.Delay(interval);
                Opacity -= 0.05;
            }
            Opacity = 0;
        }
    }
}