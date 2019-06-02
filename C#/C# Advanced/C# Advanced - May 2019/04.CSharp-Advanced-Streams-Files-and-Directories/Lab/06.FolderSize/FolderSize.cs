using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _06.FolderSize
{
    class FolderSize
    {
        static void Main()
        {
            Dictionary<string, Dictionary<string, double>> filesInfo = new Dictionary<string, Dictionary<string, double>>();
            string desctopFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string[] filesInDir = Directory.GetFiles(desctopFolder, "*.*", SearchOption.AllDirectories);

            foreach (var file in filesInDir)
            {
                FileInfo fileInfo = new FileInfo(file);
                string ext = fileInfo.Extension;
                string fileName = fileInfo.Name;

                if (!filesInfo.ContainsKey(ext))
                {
                    filesInfo.Add(ext, new Dictionary<string, double>());
                }

                if (!filesInfo[ext].ContainsKey(fileName))
                {
                    filesInfo[ext].Add(fileName, (double)fileInfo.Length / 1024);
                }
            }

            double dirSize = 0;
            string filePath = Path.Combine(desctopFolder, "Output.txt");

            using (var writer = new StreamWriter(filePath))
            {
                foreach (var kvp in filesInfo.OrderBy(x => x.Value.Count()))
                {
                    writer.WriteLine(kvp.Key);
                    //Console.WriteLine(kvp.Key);

                    foreach (var innerKvp in kvp.Value.OrderBy(x => x.Value))
                    {
                        writer.WriteLine($"-- {innerKvp.Key} - {innerKvp.Value:f2}kb");
                        //Console.WriteLine($"-- {innerKvp.Key} - {innerKvp.Value:f2}kb");
                        dirSize += innerKvp.Value;
                    }
                }
            }

            Console.WriteLine($"{dirSize / 1024:f02}MB");
        }
    }
}
