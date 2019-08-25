using System;
using Logger2.Layouts.Contracts;
using Logger2.Loggers.Enums;

namespace Logger2.Appenders
{
    public class ConsoleAppender : IAppender
    {
        private ILayout layout;

        public ConsoleAppender(ILayout layout)
        {
            this.layout = layout;
        }

        public ReportLevel ReportLevel { get; set; }

        public void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (this.ReportLevel <= reportLevel)
            {
                Console.WriteLine(string.Format(layout.Format, dateTime, reportLevel, message));
            }   
        }
    }
}
