/*
 * Copyright (c) Microsoft Corporation. All rights reserved. Licensed under the MIT license.
 * See LICENSE in the project root for license information.
 */

using ProjToolV2.Properties;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace ProjToolV2
{
    /// <summary>
    /// Class responsible to log filename, calling function and the line number
    /// </summary>
    public class SourceInfo
    {
        public string MethodName { get; internal set; }
        public int LineNumber { get; internal set; }

        public string FileName { get; internal set; }

        public SourceInfo([CallerFilePath] string filePath = "", [CallerMemberName] string methodName = "", [CallerLineNumber] int lineNumber = 0)
        {
            MethodName = methodName;
            LineNumber = lineNumber;
            FileName = Regex.Match(filePath, @"[^\\]+(?=\.cs$)").Value;
            if (MethodName.Contains(".ctor"))
            {
                MethodName = "Initialize";
            }
        }
    }

    public static class Log
    {
        private static string _assemblyDirectory = string.Empty;
        private static string _filePath = string.Empty;
        public static TraceSource TraceSource = new TraceSource("Logger");

        static Log()
        {
            Trace.Listeners.Clear();
            TraceSource.Listeners.Clear();
            TextWriterTraceListener textTraceListner = new TextWriterTraceListener(FilePath)
            {
                TraceOutputOptions = TraceOptions.None
            };
            TraceSource.Switch.Level = (SourceLevels)Enum.Parse(typeof(SourceLevels), Settings.Default.SourceLevel.ToString());
            Trace.Listeners.Add(textTraceListner);
            Trace.AutoFlush = true;
        }

        private static string AssemblyDirectory
        {
            get
            {
                if (_assemblyDirectory != string.Empty) return _assemblyDirectory;
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                _assemblyDirectory = Path.GetDirectoryName(path);
                if (_assemblyDirectory.StartsWith("\\"))
                {
                    _assemblyDirectory = Path.GetTempPath();
                }
                return _assemblyDirectory;
            }
        }

        public static string FilePath
        {
            get
            {
                if (_filePath != string.Empty) return _filePath;
                string baseName = Assembly.GetExecutingAssembly().GetName().Name;
                string logFile = $"{baseName}_{DateTime.Now.ToString("yyyy_MM_dd")}.log";
                _filePath = Path.Combine(AssemblyDirectory, logFile);
                return _filePath;
            }
        }

        private static void UpdateUiTextbox(TextBox textbox, string msg, params object[] args)
        {
            UpdateUiTextbox(null, textbox, msg, args);
        }

        private static void UpdateUiTextbox(BackgroundExecutorWithStatus bgws, TextBox textbox, string msg, params object[] args)
        {
            if (args.Length != 0)
            {
                msg = string.Format(msg, args);
            }
            if (bgws != null)
            {
                bgws.AnimateText = msg;
            }
            else
            {
                textbox.InvokeIfRequired(s =>
                {
                    s.Text += Environment.NewLine + msg;
                });
            }
        }

        public static void WriteVerbose(SourceInfo logSourceInfo, TextBox textbox, string msg, params object[] args)
        {
            LogInternal(logSourceInfo, TraceEventType.Verbose, msg, args);
            UpdateUiTextbox(textbox, msg, args);
        }

        public static void WriteWarning(SourceInfo logSourceInfo, TextBox textbox, string msg, params object[] args)
        {
            LogInternal(logSourceInfo, TraceEventType.Warning, msg, args);
            UpdateUiTextbox(textbox, msg, args);
        }

        public static void WriteError(SourceInfo logSourceInfo, TextBox textbox, string msg, params object[] args)
        {
            LogInternal(logSourceInfo, TraceEventType.Error, msg, args);
            UpdateUiTextbox(textbox, msg, args);
        }

        public static void WriteCritical(SourceInfo logSourceInfo, TextBox textbox, string msg, params object[] args)
        {
            LogInternal(logSourceInfo, TraceEventType.Critical, msg, args);
            UpdateUiTextbox(textbox, msg, args);
        }

        public static void WriteInformation(SourceInfo logSourceInfo, TextBox textbox, string msg, params object[] args)
        {
            LogInternal(logSourceInfo, TraceEventType.Information, msg, args);
            UpdateUiTextbox(textbox, msg, args);
        }

        public static void WriteVerbose(SourceInfo logSourceInfo, TextBox textbox, BackgroundExecutorWithStatus bgws, string msg, params object[] args)
        {
            LogInternal(logSourceInfo, TraceEventType.Verbose, msg, args);
            UpdateUiTextbox(bgws, textbox, msg, args);
        }

        public static void WriteWarning(SourceInfo logSourceInfo, TextBox textbox, BackgroundExecutorWithStatus bgws, string msg, params object[] args)
        {
            LogInternal(logSourceInfo, TraceEventType.Warning, msg, args);
            UpdateUiTextbox(bgws, textbox, msg, args);
        }

        public static void WriteError(SourceInfo logSourceInfo, TextBox textbox, BackgroundExecutorWithStatus bgws, string msg, params object[] args)
        {
            LogInternal(logSourceInfo, TraceEventType.Error, msg, args);
            UpdateUiTextbox(bgws, textbox, msg, args);
        }

        public static void WriteCritical(SourceInfo logSourceInfo, TextBox textbox, BackgroundExecutorWithStatus bgws, string msg, params object[] args)
        {
            LogInternal(logSourceInfo, TraceEventType.Critical, msg, args);
            UpdateUiTextbox(bgws, textbox, msg, args);
        }

        public static void WriteInformation(SourceInfo logSourceInfo, TextBox textbox, BackgroundExecutorWithStatus bgws, string msg, params object[] args)
        {
            LogInternal(logSourceInfo, TraceEventType.Information, msg, args);
            UpdateUiTextbox(bgws, textbox, msg, args);
        }

        public static void WriteVerbose(SourceInfo logSourceInfo, string msg, params object[] args)
        {
            LogInternal(logSourceInfo, TraceEventType.Verbose, msg, args);
        }

        public static void WriteWarning(SourceInfo logSourceInfo, string msg, params object[] args)
        {
            LogInternal(logSourceInfo, TraceEventType.Warning, msg, args);
        }

        public static void WriteError(SourceInfo logSourceInfo, string msg, params object[] args)
        {
            LogInternal(logSourceInfo, TraceEventType.Error, msg, args);
        }

        public static void WriteCritical(SourceInfo logSourceInfo, string msg, params object[] args)
        {
            LogInternal(logSourceInfo, TraceEventType.Critical, msg, args);
        }

        public static void WriteInformation(SourceInfo logSourceInfo, string msg, params object[] args)
        {
            LogInternal(logSourceInfo, TraceEventType.Information, msg, args);
        }

        private static void LogInternal(SourceInfo logSourceInfo, TraceEventType traceType, string msg, params object[] args)
        {
            if (!TraceSource.Switch.ShouldTrace(traceType)) return;
            if (args.Length != 0)
            {
                msg = string.Format(msg, args);
            }
            string methodName = logSourceInfo.MethodName;
            int lineNumber = logSourceInfo.LineNumber;
            string fileName = logSourceInfo.FileName;
            string background = Thread.CurrentThread.IsBackground ? "Background Thread" : "UI Thread";
            string thread = $"(T{Thread.CurrentThread.ManagedThreadId:x4})";
            string logInfo = string.Format(CultureInfo.InstalledUICulture, "{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}",
                DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"),
                background,
                thread,
                fileName,
                methodName,
                lineNumber,
                traceType,
                msg);
            Trace.WriteLine(logInfo);
        }
    }
}