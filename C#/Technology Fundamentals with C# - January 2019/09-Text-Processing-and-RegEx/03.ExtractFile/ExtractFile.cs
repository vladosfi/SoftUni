using System;

namespace _03.ExtractFile
{
    class ExtractFile
    {
        static void Main()
        {
            string file = Console.ReadLine();

            int start = file.LastIndexOf("\\")+1;
            int end = file.LastIndexOf(".");

            string fileName = string.Empty;

            for (int i = start; i < end; i++)
            {
                fileName += file[i];
            }

            string fileExtension = string.Empty;

            for (int i = end+1; i < file.Length; i++)
            {
                fileExtension += file[i];
            }

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {fileExtension}");
        }
    }
}
