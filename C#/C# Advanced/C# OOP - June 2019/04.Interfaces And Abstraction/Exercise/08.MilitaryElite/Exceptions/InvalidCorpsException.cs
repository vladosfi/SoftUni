using System;

namespace MilitaryElite
{
    public class InvalidCorpsException: Exception
    {
        private const string EXC_MESSAGE = "INVALID CORPS!";

        public InvalidCorpsException()
            :base(EXC_MESSAGE)
        {
        }

        public InvalidCorpsException(string message) : base(message)
        {
        }
    }
}
