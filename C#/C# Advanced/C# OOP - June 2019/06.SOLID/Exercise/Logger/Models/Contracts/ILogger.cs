using LoggerTask.Models.Contracts;
using System.Collections.Generic;

namespace LoggerTask.Contracts
{
    public interface ILogger
    {
        IReadOnlyCollection<IAppender> Appenders { get; }

        void Log(IError error);
    }
}
