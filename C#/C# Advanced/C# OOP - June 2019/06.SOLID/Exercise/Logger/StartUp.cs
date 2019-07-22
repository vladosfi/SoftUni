using System;
using System.Collections.Generic;
using System.Linq;

using LoggerTask.Contracts;
using LoggerTask.Core;
using LoggerTask.Factories;
using LoggerTask.Loggers;
using LoggerTask.Models.Contracts;

namespace LoggerTask
{
    public class StartUp
    {
        static void Main()
        {
            int appendersCount = int.Parse(Console.ReadLine());

            ICollection<IAppender> appenders = new List<IAppender>();

            AppenderFactory appenderFactory = new AppenderFactory();

            ReadAppendersData(appendersCount, appenders, appenderFactory);

            ILogger logger = new Logger(appenders);

            Engine engin = new Engine(logger);
            engin.Run();
        }

        private static void ReadAppendersData(int appendersCount, ICollection<IAppender> appenders, AppenderFactory appenderFactory)
        {
            for (int i = 0; i < appendersCount; i++)
            {
                string[] appendersInfo = Console.ReadLine()
                    .Split()
                    .ToArray();

                string appenderType = appendersInfo[0];
                string layoutType = appendersInfo[1];
                string levelString = "INFO";

                if (appendersInfo.Length == 3)
                {
                    levelString = appendersInfo[2];
                }

                try
                {
                    IAppender appender = appenderFactory.GetAppender(appenderType, layoutType, levelString);
                    appenders.Add(appender);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
