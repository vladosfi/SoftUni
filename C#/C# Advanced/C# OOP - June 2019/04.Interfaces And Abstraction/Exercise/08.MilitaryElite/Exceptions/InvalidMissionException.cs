using System;

namespace MilitaryElite
{
    public class InvalidMissionException : Exception
    {
        private const string EXC_MESSAGE = "Invalid mission!";

        public InvalidMissionException()
            :base(EXC_MESSAGE)
        {
        }

        public InvalidMissionException(string message) : base(message)
        {
        }
    }
}
