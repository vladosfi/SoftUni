using System;

namespace MilitaryElite
{
    public class InvalidMissionCompletionException : Exception
    {
        private const string EXC_MESSAGE = "You cannot complete alredady completed mission!";

        public InvalidMissionCompletionException()
            :base(EXC_MESSAGE)
        {
        }

        public InvalidMissionCompletionException(string message) : base(message)
        {
        }
    }
}
