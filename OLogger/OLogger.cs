using System;
using System.IO;

namespace OLog
{
    /// <summary>
    /// A Logger to save log messages to the specified file
    /// </summary>
    public class OLogger
    {
        private readonly string _path;

        /// <summary>
        /// Initializes the logger and appends to the file under <paramref name="path"/>.
        /// If the files doesn't exist it will be created
        /// </summary>
        /// <param name="path">The path of the created LogFile</param>
        public OLogger(string path)
        {
            _path = path;
        }

        /// <summary>
        /// Logs a message of type <seealso cref="LogMessageType.INFO"/>
        /// </summary>
        /// <param name="message">The error message to log</param>
        /// <param name="outgoingClass">The class from which the error accured</param>
        /// <returns></returns>
        public LogInformation Info(string message, Type outgoingClass)
        {
            var logInformation = new LogInformation
            {
                Message = DateTime.Now.ToString() + " INFO " + outgoingClass.FullName + " - " + message,
                Type = LogMessageType.INFO
            };

            File.AppendAllText(_path, logInformation.Message + Environment.NewLine);

            return logInformation;
        }

        /// <summary>
        /// Logs a message of type <seealso cref="LogMessageType.ERROR"/>
        /// </summary>
        /// <param name="message">The error message to log</param>
        /// <param name="outgoingClass">The class from which the error accured</param>
        /// <returns></returns>
        public LogInformation Error(string message, Type outgoingClass)
        {
            var logInformation = new LogInformation
            {
                Message = DateTime.Now.ToString() + " ERROR " + outgoingClass.FullName + " - " + message,
                Type = LogMessageType.ERROR
            };

            File.AppendAllText(_path, logInformation.Message + Environment.NewLine);

            return logInformation;
        }

        /// <summary>
        /// Logs a message of type <seealso cref="LogMessageType.WARNING"/>
        /// </summary>
        /// <param name="message">The error message to log</param>
        /// <param name="outgoingClass">The class from which the error accured</param>
        /// <returns></returns>
        public LogInformation Warning(string message, Type outgoingClass)
        {
            var logInformation = new LogInformation
            {
                Message = DateTime.Now.ToString() + " WARNING " + outgoingClass.FullName + " - " + message,
                Type = LogMessageType.WARNING
            };

            File.AppendAllText(_path, logInformation.Message + Environment.NewLine);

            return logInformation;
        }

        /// <summary>
        /// Logs a message of type <seealso cref="LogMessageType.FATAL"/>
        /// </summary>
        /// <param name="message">The error message to log</param>
        /// <param name="outgoingClass">The class from which the error accured</param>
        /// <returns></returns>
        public LogInformation Fatal(string message, Type outgoingClass)
        {
            var logInformation = new LogInformation
            {
                Message = DateTime.Now.ToString() + " FATAL " + outgoingClass.FullName + " - " + message,
                Type = LogMessageType.FATAL
            };

            File.AppendAllText(_path, logInformation.Message + Environment.NewLine);

            return logInformation;
        }

        /// <summary>
        /// Logs a message of type <seealso cref="LogMessageType.FINALINFO"/>
        /// </summary>
        /// <param name="message">The error message to log</param>
        /// <param name="outgoingClass">The class from which the error accured</param>
        /// <returns></returns>
        public LogInformation FinalInfo(string message, Type outgoingClass)
        {
            var logInformation = new LogInformation
            {
                Message = DateTime.Now.ToString() + " FINALINFO " + outgoingClass.FullName + " - " + message,
                Type = LogMessageType.FINALINFO
            };

            File.AppendAllText(_path, logInformation.Message + Environment.NewLine);

            return logInformation;
        }

        /// <summary>
        /// Logs a message of type <seealso cref="LogMessageType.CANCELINFO"/>
        /// </summary>
        /// <param name="message">The error message to log</param>
        /// <param name="outgoingClass">The class from which the error accured</param>
        /// <returns></returns>
        public LogInformation CancelInfo(string message, Type outgoingClass)
        {
            var logInformation = new LogInformation
            {
                Message = DateTime.Now.ToString() + " CANCELINFO " + outgoingClass.FullName + " - " + message,
                Type = LogMessageType.CANCELINFO
            };

            File.AppendAllText(_path, logInformation.Message + Environment.NewLine);

            return logInformation;
        }
    }
}