using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _01.EvenLines
{
    class EvenLines
    {
        static void Main(string[] args)
        {
            string path = "Resources";
            string filePath = Path.Combine(path, "text.txt");

            using (var reader = new StreamReader(filePath))
            {
                int counter = 0;
                while (true)
                {
                    var line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }

                    if (counter % 2 == 0)
                    {
                        char[] symbolsToReplace = new char[] { '-', ',', '.', '!', '?' };

                        foreach (var symbol in symbolsToReplace)
                        {
                            line = line.Replace(symbol, '@');
                        }

                        List<string> reversedLine = line.Split(" ").Reverse().ToList();

                        Console.WriteLine(string.Join(" ", reversedLine));
                    }

                    counter++;
                }
            }
        }
    }
}
