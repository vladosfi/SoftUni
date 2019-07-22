using System;
using System.Globalization;

using LoggerTask.Models.Contracts;
using LoggerTask.Models.Enumerations;

namespace LoggerTask.Models.Appenders
{
    public class ConsoleAppender : IAppender
    {
        private const string dateFormat = "M/dd/yyyy H:mm:ss tt";

        private int messagesAppended;

        private ConsoleAppender()
        {
            this.messagesAppended = 0;
        }

        public ConsoleAppender(ILayout layout, Level level)
            :this()
        {
            this.Layout = layout;
            this.Level = level;
        }

        public ILayout Layout { get; private set; }

        public Level Level { get; private set; }

        public void Append(IError error)
        {
            string format = this.Layout.Format;

            DateTime dateTime = error.DateTyme;
            Level level = error.Level;
            string message = error.Message;

            string formatedMessage = string.Format(format,
                dateTime.ToString(dateFormat, CultureInfo.InvariantCulture),
                level.ToString(),
                message);


            Console.WriteLine(formatedMessage);
            messagesAppended++;
        }
    }
}
