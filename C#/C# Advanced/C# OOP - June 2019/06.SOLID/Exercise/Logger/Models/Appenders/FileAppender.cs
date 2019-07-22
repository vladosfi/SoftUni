using LoggerTask.Models.Contracts;
using LoggerTask.Models.Enumerations;

namespace LoggerTask.Models.Appenders
{
    public class FileAppender : IAppender
    {
        private int messagesAppended;

        public FileAppender()
        {
            messagesAppended = 0;
        }

        public FileAppender(ILayout layout, Level level, IFile file)
            :this()
        {
            this.Layout = layout;
            this.Level = level;
            this.File = file;
        }

        public ILayout Layout { get; private set; }

        public Level Level { get; private set; }

        public IFile File { get; private set; }

        public void Append(IError error)
        {
            string formattedMessage = this.File.Write(this.Layout, error);

            System.IO.File.AppendAllText(this.File.Path, formattedMessage);

            this.messagesAppended++;
        }
    }
}
