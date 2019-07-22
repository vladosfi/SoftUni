using System;
using System.IO;
using System.Linq;
using System.Globalization;

using LoggerTask.Models.Contracts;
using LoggerTask.Models.Enumerations;
using LoggerTask.Models.IOManagement;

namespace LoggerTask.Models.Files
{
    public class LogFile : IFile
    {
        private const string currentDirectory = "\\logs\\";
        private const string currentFile = "log.txt";
        private const string dateFormat = "M/dd/yyyy H:mm:ss tt";


        private readonly string currentPath;
        private readonly IIOManager IOManager;

        public LogFile()
        {
            this.IOManager = new IOManager(currentDirectory, currentFile);
            this.currentPath = this.IOManager.GetCurrnetPath();
            this.IOManager.EnsuereDiretoryAndFileExist();
            this.Path = currentPath + currentDirectory + currentFile;
        }

        public string Path { get; private set}

        public ulong Size => GetFileSize();

        private ulong GetFileSize()
        {
            string text = File.ReadAllText(this.Path);

            ulong size = (ulong)text
                .ToCharArray()
                .Where(c => char.IsLetter(c))
                .Sum(c => c);

            return size;
        }

        public string Write(ILayout layout, IError error)
        {
            string format = layout.Format;

            DateTime dateTime = error.DateTyme;
            string message = error.Message;
            Level level = error.Level;

            string formatedMessage = string.Format(format, 
                dateTime.ToString(dateFormat,CultureInfo.InvariantCulture)
                , level.ToString()
                , message);

            return formatedMessage;
        }
    }
}
