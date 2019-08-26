using System;
using System.Collections.Generic;
using Logger2.Appenders;
using Logger2.Appenders.Factory;
using Logger2.Core.Contracts;
using Logger2.Factory.Contracts;
using Logger2.Layouts.Contracts;
using Logger2.Loggers.Enums;

namespace Logger2.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly ICollection<IAppender> appenders;

        private IAppenderFactory appenderFactory;
        private ILayoutFactory layoutFactory;

        public CommandInterpreter()
        {
            this.appenders = new List<IAppender>();
            this.appenderFactory = new AppenderFactory();
            this.layoutFactory = new LayoutFactory();
        }

        public void AddAppender(string[] args)
        {
            string appenderType = args[0];
            string layoutType = args[1];
            ReportLevel reportLevel = ReportLevel.INFO;

            if (args.Length >= 3)
            {
                reportLevel = Enum.Parse<ReportLevel>(args[2]);
            }

            ILayout layout = this.layoutFactory.Create(layoutType);
            IAppender appender = this.appenderFactory.Create(appenderType, layout);
            appender.ReportLevel = reportLevel;

            this.appenders.Add(appender);
        }

        public void AddReport(string[] args)
        {
            string reportType = args[0];
            string dateTyme = args[1];
            string message = args[2];

            ReportLevel reportLevel = Enum.Parse<ReportLevel>(reportType);

            foreach (var appender in this.appenders)
            {
                appender.Append(dateTyme, reportLevel, message);
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine("Logger info");
            foreach (var appender in this.appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}

