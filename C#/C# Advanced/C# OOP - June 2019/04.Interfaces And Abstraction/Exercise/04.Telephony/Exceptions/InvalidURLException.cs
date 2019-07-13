using System;

namespace Telephony
{
    public class InvalidURLException : Exception
    {
        public const string EXCEPTION_MESSAGE = "Invalid URL!";

        public InvalidURLException()
            :base(EXCEPTION_MESSAGE)
        {

        }
    }
}
