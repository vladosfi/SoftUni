using Logger2.Layouts.Contracts;
using Logger2.Loggers.Contracts;
using Logger2.Loggers.Enums;
using System;
using System.IO;

namespace Logger2.Appenders
{
    public class FileAppender : Appender
    {
        private const string Path = @"..\..\..\log.txt";

        public FileAppender(ILayout layout, ILogFile logFile)
            :base(layout)
        {
            this.LogFile = logFile;
        }

        public ILogFile LogFile { get; set; }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (this.ReportLevel <= reportLevel)
            {
                string content = string.Format(this.Layout.Format, dateTime, reportLevel, message) + Environment.NewLine;

                File.AppendAllText(Path, content);
                this.LogFile.Write(content);
                this.Count++;
            }
        }

        public override string ToString()
        {
            return base.ToString() + ", File size: " + this.LogFile.Size;
        }
    }
}
