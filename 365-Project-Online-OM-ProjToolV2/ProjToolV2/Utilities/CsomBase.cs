/*
 * Copyright (c) Microsoft Corporation. All rights reserved. Licensed under the MIT license.
 * See LICENSE in the project root for license information.
 */

using Microsoft.ProjectServer.Client;
using Microsoft.SharePoint.Client;

namespace ProjToolV2
{
    /// <summary>
    /// Static class to cache some of the client object values
    /// </summary>
    internal static class CsomBase
    {
        private static EnterpriseResource _currentResource;
        private static bool _currentResourceIsAssignable;

        public static EnterpriseResource CurrentResource
        {
            get { return _currentResource ?? (_currentResource = CsomHelper.LoadMe()); }
            set
            {
                _currentResource = value;
            }
        }

        public static User CurrentUser { get; set; }

        public static bool CurrentResourceIsAssignable
        {
            get
            {
                //If the current resource is not of type work, we dont cache the value.
                if (!_currentResourceIsAssignable)
                {
                    _currentResourceIsAssignable = CsomHelper.CheckCurrentResourceIsAssignable();
                }
                return _currentResourceIsAssignable;
            }
            set
            {
                _currentResourceIsAssignable = value;
            }
        }

        public static void ClearCsomObjects()
        {
            Log.WriteVerbose(new SourceInfo(), "Clearing all csom related static objects.");
            CsomHelper.ProjContext = null;
            CurrentUser = null;
            _currentResource = null;
            _currentResourceIsAssignable = false;
        }
    }
}