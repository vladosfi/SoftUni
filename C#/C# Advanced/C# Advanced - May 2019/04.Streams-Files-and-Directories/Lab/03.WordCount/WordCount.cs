using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03.WordCount
{
    class WordCount
    {
        static void Main(string[] args)
        {
            string path = "Resources";
            string fileWords = Path.Combine(path, "words.txt");
            string fileText = Path.Combine(path, "text.txt");
            string actualResult = Path.Combine(path, "actualResult.txt");
            string expectedResult = Path.Combine(path, "expectedResult.txt");

            Dictionary<string, int> words = new Dictionary<string, int>();

            using (var reader = new StreamReader(fileWords))
            {
                while (true)
                {
                    string word = reader.ReadLine();

                    if (word == null)
                    {
                        break;
                    }

                    words[word] = 0;
                }
            }

            using (var reader = new StreamReader(fileText))
            {
                while (true)
                {
                    string line = reader.ReadLine();

                    if (line == null)
                    {
                        break;
                    }

                    for (int i = 0; i < line.Length; i++)
                    {
                        if (char.IsPunctuation(line[i]))
                        {
                            line = line.Replace(line[i], ' ');
                        }
                    }

                    string[] lineOfWords = line.Split();

                    foreach (var item in lineOfWords)
                    {
                        if (words.ContainsKey(item.ToLower()))
                        {
                            words[item.ToLower()]++;
                        }
                    }
                }
            }

            using (var writer = new StreamWriter(actualResult))
            {
                foreach (var kvp in words.OrderByDescending(x => x.Value))
                {
                    string line = $"{kvp.Key} - {kvp.Value}";
                    writer.WriteLine(line);
                }
            }

            using (var readerFileOne = new StreamReader(actualResult))
            {
                using (var readerFileTwo = new StreamReader(expectedResult))
                {
                    while (true)
                    {
                        string lineF1 = readerFileOne.ReadLine();
                        string lineF2 = readerFileTwo.ReadLine();

                        if (lineF1 == null && lineF2 == null)
                        {
                            break;
                        }

                        if (lineF1 != lineF2)
                        {
                            Console.WriteLine("Files are different");
                            return;
                        }
                    }
                }
            }

            Console.WriteLine("Files are equals");
        }
    }
}
