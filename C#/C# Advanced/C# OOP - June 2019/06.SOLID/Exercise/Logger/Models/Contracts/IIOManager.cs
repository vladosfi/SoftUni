namespace LoggerTask.Models.Contracts
{
    public interface IIOManager
    {
        string CurrentDirectory { get; }

        string CurrentDirectoryPath { get; }

        string CurrnetFilePath { get; }

        void EnsuereDiretoryAndFileExist();

        string GetCurrnetPath();
    }
}
