using System;

namespace LoggerTask.Exceptions
{
    public class InvalidDateFolrmatException : Exception
    {
        private const string EXC_MESSAGE = "Invalid DateTime Format!";

        public InvalidDateFolrmatException()
            :base(EXC_MESSAGE)
        {
        }
    }
}
