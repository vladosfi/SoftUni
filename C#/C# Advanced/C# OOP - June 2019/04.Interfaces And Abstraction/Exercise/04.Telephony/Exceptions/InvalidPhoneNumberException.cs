using System;

namespace Telephony
{
    public class InvalidPhoneNumberException : Exception
    {
        public const string EXCEPTION_MESSAGE = "Invalid number!";

        public InvalidPhoneNumberException()
            :base(EXCEPTION_MESSAGE)
        {
        }
    }
}
