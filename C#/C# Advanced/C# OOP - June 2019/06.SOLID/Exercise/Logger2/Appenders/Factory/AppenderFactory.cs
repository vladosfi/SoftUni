using Logger2.Factory.Contracts;
using Logger2.Layouts.Contracts;
using Logger2.Loggers;
using System;

namespace Logger2.Appenders.Factory
{
    public class AppenderFactory : IAppenderFactory
    {
        public IAppender Create(string type, ILayout layout)
        {
            if (type == "ConsoleAppender")
            {
                return new ConsoleAppender(layout);
            }
            else if (type == "FileAppender")
            {
                return  new FileAppender(layout, new LogFile());
            }
            else
            {
                throw new ArgumentException("Invalid appender type!");
            }
        }
    }
}
