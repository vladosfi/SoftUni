using System;
using System.IO;
using System.IO.Compression;

namespace _06.ZipAndExtract
{
    class ZipAndExtract
    {
        static void Main(string[] args)
        {
            string desctopFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path = "Resources";
            string targetDir = path;
            string archiveFile = Path.Combine(".", "destination.zip");

            ZipFile.CreateFromDirectory(targetDir, archiveFile, CompressionLevel.Optimal, false);
            
            ZipFile.ExtractToDirectory(archiveFile, desctopFolder);
        }
    }
}
