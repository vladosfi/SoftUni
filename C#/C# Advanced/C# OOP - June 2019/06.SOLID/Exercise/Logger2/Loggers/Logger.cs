using Logger2.Appenders;
using Logger2.Loggers.Contracts;
using Logger2.Loggers.Enums;

namespace Logger2.Loggers
{
    public class Logger : ILogger
    {
        private readonly IAppender consoleAppender;
        private readonly IAppender fileAppender;

        public Logger(IAppender consoleAppender)
        {
            this.consoleAppender = consoleAppender;
        }

        public Logger(IAppender consoleAppender, IAppender fileAppender)
            : this(consoleAppender)
        {
            this.fileAppender = fileAppender;
        }

        public void Warning(string dateTime, string criticalMessage)
        {
            this.Append(dateTime, ReportLevel.Info, criticalMessage);
        }

        public void Info(string dateTime, string infoMessage)
        {
            this.Append(dateTime, ReportLevel.Info, infoMessage);
        }

        public void Error(string dateTime, string errorMessage)
        {
            this.Append(dateTime, ReportLevel.Error, errorMessage);
        }

        public void Fatal(string dateTime, string fatalMessage)
        {
            this.Append(dateTime, ReportLevel.Fatal, fatalMessage);
        }

        public void Critical(string dateTime, string criticalMessage)
        {
            this.Append(dateTime, ReportLevel.Critical, criticalMessage);
        }


        private void Append(string dateTime, ReportLevel type, string message)
        {
            this.consoleAppender?.Append(dateTime, type, message);
            this.fileAppender?.Append(dateTime, type, message);
        }
    }
}
