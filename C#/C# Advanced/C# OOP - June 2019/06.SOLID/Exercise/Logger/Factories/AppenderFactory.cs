using System;

using LoggerTask.Exceptions;
using LoggerTask.Models.Appenders;
using LoggerTask.Models.Contracts;
using LoggerTask.Models.Enumerations;
using LoggerTask.Models.Files;

namespace LoggerTask.Factories
{
    public class AppenderFactory
    {
        private readonly LayoutFactory layoutFactory;

        public AppenderFactory()
        {
            this.layoutFactory = new LayoutFactory();
        }

        public IAppender GetAppender(string appenderType, string layoutType, string levelString)
        {

            bool hasParsed = Enum.TryParse<Level>(levelString, out Level level);

            if (!hasParsed)
            {
                throw new IvalidLevelTypeException();
            }

            ILayout layout = this.layoutFactory.GetLayout(layoutType);

            IAppender appender;

            if (appenderType == "ConsoleAppender")
            {
                appender = new ConsoleAppender(layout, level);
            }
            else if (appenderType == "FileAppender")
            {
                IFile file = new LogFile();
                appender = new FileAppender(layout, level, file);
            }
            else
            {
                throw new InvalidAppenderTypeException();
            }

            return appender;
        }
    }
}
