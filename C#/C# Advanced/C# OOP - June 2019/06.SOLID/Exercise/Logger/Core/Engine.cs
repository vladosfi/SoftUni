using LoggerTask.Contracts;
using LoggerTask.Layouts;
using LoggerTask.Loggers;
using LoggerTask.Models.Appenders;
using LoggerTask.Models.Contracts;

namespace LoggerTask.Core
{
    public class Engine
    {
        public void Run()
        {
            ILayout simpleLayout = new SimpleLayout();
            IAppender consoleAppender = new ConsoleAppender(simpleLayout);
            ILogger logger = new Logger(consoleAppender);

            logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");
        }

    }
}
