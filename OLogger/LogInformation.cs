namespace OLog
{
    /// <summary>
    /// Represents a single log message that is being logged
    /// </summary>
    public class LogInformation
    {
        public string Message
        {
            get;
            set;
        }

        public LogMessageType Type
        {
            get;
            set;
        }
    }
}
