using Logger2.Layouts.Contracts;
using Logger2.Loggers.Enums;

namespace Logger2.Appenders
{
    public abstract class Appender : IAppender
    {
        protected Appender(ILayout layout)
        {
            this.Layout = layout;
        }

        public ReportLevel ReportLevel { get; set; }

        protected int Count { get; set; }

        protected ILayout Layout { get; }

        public abstract void Append(string dateTime, ReportLevel reportLevel, string message);

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, " +
                    $"Layout type: {this.Layout.GetType().Name}, " +
                    $"Report level: {this.ReportLevel}, " +
                    $"Messages appended: {this.Count}";
        }
    }
}
