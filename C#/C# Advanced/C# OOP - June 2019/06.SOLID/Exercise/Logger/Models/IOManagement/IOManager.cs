using System.IO;

using LoggerTask.Models.Contracts;

namespace LoggerTask.Models.IOManagement
{
    public class IOManager : IIOManager
    {
        private readonly string currentPath;
        private readonly string currentDirectory;
        private readonly string currentFile;

        public IOManager()
        {
            this.currentPath = this.GetCurrnetPath();
        }

        public IOManager(string currentDirectory, string currentFile)
            :this ()
        {
            this.currentDirectory = currentDirectory;
            this.currentFile = currentFile;
        }

        public string CurrentDirectoryPath => this.currentPath + this.currentDirectory;

        public string CurrnetFilePath => this.CurrentDirectoryPath + this.currentFile;

        public string CurrentDirectory => throw new System.NotImplementedException();

        public void EnsuereDiretoryAndFileExist()
        {
            if (!Directory.Exists(this.CurrentDirectoryPath))
            {
                Directory.CreateDirectory(this.CurrentDirectoryPath);
            }

            File.WriteAllText(this.CurrnetFilePath, string.Empty);
        }

        public string GetCurrnetPath()
        {
            return Directory.GetCurrentDirectory();
        }
    }
}
