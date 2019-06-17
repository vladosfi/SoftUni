using System;
using System.IO;

namespace _02.LineNumbers
{
    class LineNumbers
    {
        static void Main(string[] args)
        {
            string path = "Resources";
            string filePath = Path.Combine(path, "text.txt");
            string fileOutputPath = Path.Combine(path, "output.txt");

            using (var reader = new StreamReader(filePath))
            {
                int counter = 1;
                using (var writer = new StreamWriter(fileOutputPath))
                {
                    while (true)
                    {
                        var line = reader.ReadLine();

                        if (line == null)
                        {
                            break;
                        }

                        int letterCount = 0;
                        int punctuationCount = 0;

                        foreach (var symbol in line)
                        {
                            if (char.IsLetter(symbol))
                            {

                                letterCount++;
                            }
                            if (char.IsPunctuation(symbol))
                            {

                                punctuationCount++;
                            }
                        }

                        line = $"Line {counter}: {line} ({letterCount})({punctuationCount})";
                        Console.WriteLine(line);
                        writer.WriteLine(line);

                        counter++;
                    }
                }
            }
        }
    }
}
