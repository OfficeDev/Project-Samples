/*
 * Copyright (c) Microsoft Corporation. All rights reserved. Licensed under the MIT license.
 * See LICENSE in the project root for license information.
 */

using Microsoft.SharePoint.Client;
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjToolV2
{
    /// <summary>
    /// Class responsible to execute csom calls in a background thread without impacting UI
    /// </summary>
    public class BackgroundExecutorWithStatus
    {
        private readonly TextBox _statusControl;
        private int _numberOfDots;
        private readonly int _maxDots;
        public bool TaskCancelled { get; private set; }

        private readonly BackgroundExecutorBase _actionWorker;

        public Thread ActionTaskThread { get; private set; }

        public Task ActionTask { get; private set; }

        public string AnimateText { get; set; }

        public void Cancel()
        {
            if (ActionTaskThread != null)
            {
                AnimateText = $"Cancelling current query({AnimateText}).";
                Log.WriteError(new SourceInfo(), AnimateText);
                ActionTaskThread.Abort();
            }
            TaskCancelled = true;
        }

        public BackgroundExecutorWithStatus(TextBox control, string textToAnimate)
        {
            _statusControl = control;
            AnimateText = string.Empty;
            _maxDots = 4;
            AnimateText = textToAnimate;
            _statusControl.TextChanged += (sender, e) =>
            {
                _statusControl.InvokeIfRequired(tb =>
                {
                    tb.Focus();
                    tb.SelectionStart = tb.Text.Length;
                    tb.ScrollToCaret();
                });
            };
            Log.WriteVerbose(new SourceInfo(), "Initializing Background Worker.");
            _actionWorker = new BackgroundExecutorBase();
            _actionWorker.DoWork += actionWorker_DoWork;
            _actionWorker.ProgressChanged += actionWorker_ProgressChanged;
            _actionWorker.RunWorkerCompleted += actionWorker_RunWorkerCompleted;
        }

        private void actionWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Action functionToRun = (Action)e.Argument;

            ActionTask = Task.Factory.StartNew(() =>
            {
                int executionCount = 0;
                while (executionCount < 3)
                {
                    executionCount++;
                    try
                    {
                        Log.WriteVerbose(new SourceInfo(), "Started Background Worker action.");
                        ActionTaskThread = Thread.CurrentThread;
                        functionToRun();
                        break;
                    }
                    catch (ThreadAbortException)
                    {
                        TaskCancelled = true;
                        break;
                    }
                    catch (ClientRequestException cre)
                    {
                        if (cre.Message.Contains("The data is not available. The query may not have been executed."))
                        {
                            Log.WriteWarning(new SourceInfo(), "Exception Caught. Retrying... \r\nEx:{0}", cre.Message);
                            continue;
                        }
                        else
                        {
                            Log.WriteError(new SourceInfo(), "Exception Caught. \r\nEx:{0}", cre.Message);
                            break;
                        }
                    }
                }
                Log.WriteVerbose(new SourceInfo(), "Completed Background Worker action.");
            });

            while (!ActionTask.IsCompleted)
            {
                Thread.Sleep(500);
                BackgroundWorker statusWorker = (BackgroundWorker)sender;
                statusWorker.ReportProgress(0, AnimateText);
            }
        }

        private void actionWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string animate = string.Empty;
            if (e.UserState != null)
            {
                animate = e.UserState.ToString();
            }

            string automatedString = animate + new string('.', _numberOfDots);
            int lastLine = _statusControl.Lines.Length;
            if (lastLine < 2)
            {
                _statusControl.InvokeIfRequired(s =>
                {
                    _statusControl.Text = automatedString;
                });
            }
            else
            {
                if (_statusControl.Lines[lastLine - 1].Contains(animate))
                {
                    string trimmedText = _statusControl.Text.Remove(_statusControl.Text.LastIndexOf(animate, StringComparison.Ordinal));
                    _statusControl.InvokeIfRequired(s =>
                    {
                        _statusControl.Text = trimmedText + automatedString;
                    });
                }
                else
                {
                    _statusControl.InvokeIfRequired(s =>
                    {
                        _statusControl.Text += Environment.NewLine + automatedString;
                    });
                }
            }
            _numberOfDots = (_numberOfDots + 1) % (_maxDots + 1);
        }

        private void actionWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (TaskCancelled)
            {
                Log.WriteWarning(new SourceInfo(), _statusControl, "Query cancelled successfully.");
                return;
            }
            if (ActionTask.IsFaulted)
            {
                if (ActionTask.Exception != null)
                    foreach (
                        Exception ex in
                            ActionTask.Exception.InnerExceptions.Where(
                                ex => !(ex is ThreadAbortException) && !TaskCancelled))
                    {
                        if (ex is ServerException)
                        {
                            ServerException se = (ServerException)ex;
                            Log.WriteError(new SourceInfo(), _statusControl,
                                "Error Code:{0}, ErrorDetail:{1}, CorrelationId:{2}, ErrorType:{3}, ErrorValue:{4}.",
                                se.ServerErrorCode, se.ServerErrorDetails, se.ServerErrorTraceCorrelationId,
                                se.ServerErrorTypeName, se.ServerErrorValue);
                        }
                        else
                        {
                            Log.WriteError(new SourceInfo(), _statusControl, "Exception:{0}, Message:{1}",
                                ex.GetType().Name, ex.Message);
                        }
                    }
                Log.WriteWarning(new SourceInfo(), _statusControl, "Query executed with errors.");
            }
            else
            {
                Log.WriteVerbose(new SourceInfo(), _statusControl, "Query executed successfully.");
            }
        }

        public void ExecuteWorker(Action funcToRun)
        {
            TaskCancelled = false;
            _actionWorker.RunWorkerAsync(funcToRun);
        }
    }
}