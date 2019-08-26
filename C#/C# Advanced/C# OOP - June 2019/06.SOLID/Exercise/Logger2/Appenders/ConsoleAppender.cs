using System;
using Logger2.Layouts.Contracts;
using Logger2.Loggers.Enums;

namespace Logger2.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            :base (layout)
        {
        }
        
        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (this.ReportLevel <= reportLevel)
            {
                Console.WriteLine(string.Format(this.Layout.Format, dateTime, reportLevel, message));
                this.Count++;
            }
        }
    }
}
