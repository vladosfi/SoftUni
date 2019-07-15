using System;

namespace MilitaryElite
{
    public class IvalidStateException : Exception
    {
        private const string EXC_MESSAGE = "Invalid mission state!";

        public IvalidStateException()
            :base(EXC_MESSAGE)
        {
        }

        public IvalidStateException(string message) : base(message)
        {
        }
    }
}
