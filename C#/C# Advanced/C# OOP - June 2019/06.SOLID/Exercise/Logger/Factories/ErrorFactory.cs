using System;
using System.Globalization;

using LoggerTask.Exceptions;
using LoggerTask.Models.Contracts;
using LoggerTask.Models.Enumerations;
using LoggerTask.Models.Errors;

namespace LoggerTask.Factories
{
    public class ErrorFactory
    {
        private const string dateFormat = "M/dd/yyyy H:mm:ss tt";

        public IError GetError(string dateString, string levelString, string message)
        {
            Level level;

            bool hasParsed = Enum.TryParse<Level>(levelString, out level);

            if (!hasParsed)
            {
                throw new IvalidLevelTypeException();
            }

            DateTime dateTime;

            try
            {
                dateTime = DateTime.ParseExact(dateString,
                    dateFormat,
                    CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                throw new InvalidDateFolrmatException();
            }

            return new Error(dateTime, message, level);
        } 
    }
}
