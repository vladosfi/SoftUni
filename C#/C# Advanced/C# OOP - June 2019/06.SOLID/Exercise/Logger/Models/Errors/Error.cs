using System;

using LoggerTask.Models.Contracts;
using LoggerTask.Models.Enumerations;

namespace LoggerTask.Models.Errors
{
    public class Error : IError
    {
        public Error(DateTime dateTime, string message, Level level = Level.INFO)
        {
            this.DateTyme = dateTime;
            this.Message = message;
            this.Level = level;
        }

        public DateTime DateTyme { get; }

        public string Message { get; }

        public Level Level { get; }
    }
}
