using System;

namespace LoggerTask.Exceptions
{
    public class InvalidAppenderTypeException : Exception
    {
        private const string EXC_MESSAGE = "Invalid Appender Type!";

        public InvalidAppenderTypeException()
            :base(EXC_MESSAGE)
        {
        }
    }
}
