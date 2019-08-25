using Logger2.Appenders;
using Logger2.Layouts;
using Logger2.Layouts.Contracts;
using Logger2.Loggers;
using Logger2.Loggers.Contracts;
using Logger2.Loggers.Enums;

namespace Logger2
{
    class Startup
    {
        static void Main()
        {
            ILayout simpleLayout = new SimpleLayout();
            IAppender consoleAppender = new ConsoleAppender(simpleLayout);

            consoleAppender.ReportLevel = ReportLevel.Error;

            IAppender fileAppender = new FileAppender(simpleLayout, new LogFile());
            fileAppender.ReportLevel = ReportLevel.Error;

            ILogger logger = new Logger(consoleAppender, fileAppender);

            logger.Info("3/31/2015 5:33:07 PM", "Everything seems fine");
            logger.Warning("3/31/2015 5:33:07 PM", "Warning: ping is too high - disconnect imminent");
            logger.Error("3/31/2015 5:33:07 PM", "Error parsing request");
            logger.Critical("3/31/2015 5:33:07 PM", "No connection string found in App.config");
            logger.Fatal("3/31/2015 5:33:07 PM", "mscorlib.dll does not respond");


        }
    }
}
