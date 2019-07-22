using System;
using System.Runtime.Serialization;

namespace LoggerTask.Exceptions
{
    public class IvalidLevelTypeException : Exception
    {
        private const string EXC_MESSAGE = "Invalid Level Type";

        public IvalidLevelTypeException()
            :base(EXC_MESSAGE)
        {
        }

    }
}
