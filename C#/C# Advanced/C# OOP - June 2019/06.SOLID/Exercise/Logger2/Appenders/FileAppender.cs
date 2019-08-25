using Logger2.Layouts.Contracts;
using Logger2.Loggers.Contracts;
using Logger2.Loggers.Enums;
using System;
using System.IO;

namespace Logger2.Appenders
{
    public class FileAppender : IAppender
    {
        private const string Path = @"..\..\..\log.txt";
        private readonly ILayout layout;
        private readonly ILogFile logFile;

        public FileAppender(ILayout layout, ILogFile logFile)
        {
            this.layout = layout;
            this.logFile = logFile;
        }

        public ReportLevel ReportLevel { get; set; }

        public void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (this.ReportLevel <= reportLevel)
            {
                string content = string.Format(this.layout.Format, dateTime, reportLevel, message) + Environment.NewLine;

                File.AppendAllText(Path, content);
            }
        }
    }
}
