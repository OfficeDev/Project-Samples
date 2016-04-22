/*
 * Copyright (c) Microsoft Corporation. All rights reserved. Licensed under the MIT license.
 * See LICENSE in the project root for license information.
 */

using System.ComponentModel;
using System.Threading;

namespace ProjToolV2
{
    public class BackgroundExecutorBase : BackgroundWorker
    {
        private Thread _workerThread;

        public BackgroundExecutorBase()
        {
            WorkerReportsProgress = true;
        }

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            _workerThread = Thread.CurrentThread;
            try
            {
                base.OnDoWork(e);
            }
            catch (ThreadAbortException)
            {
                e.Cancel = true;
                Thread.ResetAbort();
            }
        }

        public void Abort()
        {
            if (_workerThread == null) return;
            _workerThread.Abort();
            _workerThread = null;
        }
    }
}