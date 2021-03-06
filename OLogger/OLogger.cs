﻿using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace OLog
{
    /// <summary>
    /// Main logical functions of the logger
    /// </summary>
    public class OLogger
    {
        private static readonly object _o = new object();
        private readonly string _path;

        /// <summary>
        /// Enabling this property will lead to the logging messages being written to the console aswell.
        /// </summary>
        public bool LogToConsoleEnabled
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes the logger and appends to the file under <paramref name="fileName"/>.
        /// If the files doesn't exist it will be created
        /// </summary>
        /// <param name="fileName">The path of the created LogFile</param>
        /// <param name="logToConsoleEnabled">Also write to the console, if enabled</param>
        public OLogger(string fileName, bool logToConsoleEnabled = false)
        {
            LogToConsoleEnabled = logToConsoleEnabled;
            _path = fileName;

            using (var stream = File.Open(fileName, FileMode.OpenOrCreate)) { }
        }

        /// <summary>
        /// Logs a message of type <seealso cref="LogMessageType.INFO"/>
        /// </summary>
        /// <param name="message">The error message to log</param>
        /// <param name="outgoingClass">The class from which the error accured</param>
        /// <returns></returns>
        public LogInformation Info(string message)
        {
            var frame = new StackFrame(1, true);
            var callerType = frame.GetMethod().DeclaringType.FullName;
            var callerLineNumber = frame.GetFileLineNumber();

            return LogTheMessage(message, callerType, callerLineNumber, LogMessageType.INFO);
        }

        /// <summary>
        /// Logs a message of type <seealso cref="LogMessageType.ERROR"/>
        /// </summary>
        /// <param name="message">The error message to log</param>
        /// <param name="outgoingClass">The class from which the error accured</param>
        /// <returns></returns>
        public LogInformation Error(string message)
        {
            var frame = new StackFrame(1, true);
            var callerType = frame.GetMethod().DeclaringType.FullName;
            var callerLineNumber = frame.GetFileLineNumber();

            return LogTheMessage(message, callerType, callerLineNumber, LogMessageType.ERROR);
        }

        /// <summary>
        /// Logs a message of type <seealso cref="LogMessageType.WARNING"/>
        /// </summary>
        /// <param name="message">The error message to log</param>
        /// <param name="outgoingClass">The class from which the error accured</param>
        /// <returns></returns>
        public LogInformation Warn(string message)
        {
            var frame = new StackFrame(1, true);
            var callerType = frame.GetMethod().DeclaringType.FullName;
            var callerLineNumber = frame.GetFileLineNumber();

            return LogTheMessage(message, callerType, callerLineNumber, LogMessageType.WARNING);
        }

        /// <summary>
        /// Logs the message using Thread Safety
        /// </summary>
        /// <param name="message"></param>
        /// <param name="loggedFromThisClassType"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private LogInformation LogTheMessage(string message, string callerType, int callerLineNumber, LogMessageType type)
        {
            lock (_o)
            {
                LogInformation logInformation = null;

                switch (type)
                {
                    case LogMessageType.WARNING:
                        logInformation = new LogInformation
                        {
                            Message = DateTime.Now.Date.ToString("dd-MM-yyyy") + " | " + DateTime.Now.ToString("hh:mm:ss") + " | " + "WARNING".PadRight(7)  + (" | " + callerType).PadRight(25) + " | " + ("Ln. " + callerLineNumber).PadRight(7) + " | " + message,
                            Type = LogMessageType.WARNING
                        };
                        break;

                    case LogMessageType.ERROR:
                        logInformation = new LogInformation
                        {
                            Message = DateTime.Now.Date.ToString("dd-MM-yyyy") + " | " + DateTime.Now.ToString("hh:mm:ss") + " | " + "ERROR".PadRight(7) + (" | " + callerType).PadRight(25) + " | " + ("Ln. " + callerLineNumber).PadRight(7) + " | " + message,
                            Type = LogMessageType.ERROR
                        };
                        break;

                    case LogMessageType.INFO:
                        logInformation = new LogInformation
                        {
                            Message = DateTime.Now.Date.ToString("dd-MM-yyyy") + " | " + DateTime.Now.ToString("hh:mm:ss") + " | " + "INFO".PadRight(7) + (" | " + callerType).PadRight(25) + " | " + ("Ln. " + callerLineNumber).PadRight(7) + " | " + message,
                            Type = LogMessageType.INFO
                        };
                        break;
                }

                File.AppendAllText(_path, logInformation.Message + Environment.NewLine);
                WriteToConsole(logInformation);

                return logInformation;
            }
        }

        /// <summary>
        /// Outputs the message to the console, with the specified foreground
        /// </summary>
        /// <param name="message"></param>
        public void WriteToConsole(LogInformation message)
        {
            if (!LogToConsoleEnabled)
            {
                return;
            }

            switch (message.Type)
            {
                case LogMessageType.INFO:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(message.Message);
                    Console.ResetColor();

                    Trace.Write("sdadasds");
                    break;

                case LogMessageType.ERROR:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(message.Message);
                    Console.ResetColor();
                    break;

                case LogMessageType.WARNING:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(message.Message);
                    Console.ResetColor();
                    break;

                default:
                    Console.WriteLine(message.Message);
                    break;
            }
        }
    }
}
