using System;

using LoggerTask.Models.Enumerations;

namespace LoggerTask.Models.Contracts
{
    public interface IError
    {
        DateTime DateTyme { get; }

        string Message { get; }

        Level Level { get; }
    }
}
