using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03.WordCount
{
    class WordCount
    {
        static void Main()
        {
            Dictionary<string, int> words = new Dictionary<string, int>();
            string path = "Resources";
            string filePath = Path.Combine(path, "words.txt");

            using (var reader = new StreamReader(filePath))
            {
                while (true)
                {
                    string separateWord = reader.ReadLine();

                    if (separateWord == null)
                    {
                        break;
                    }

                    List<string> wordList = separateWord.Split().ToList();

                    foreach (var word in wordList)
                    {
                        words[word] = 0;
                    }
                }
            }

            filePath = Path.Combine(path, "Input.txt");
            using (var reader = new StreamReader(filePath))
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

            filePath = Path.Combine(path, "Output.txt");
            using (var writer = new StreamWriter(filePath))
            {
                foreach (var kvp in words.OrderByDescending(x => x.Value))
                {
                    string line = $"{kvp.Key} - {kvp.Value}";
                    //Console.WriteLine(line);
                    writer.WriteLine(line);
                }
            }

            string filePathExpected = Path.Combine(path, "expectedResult.txt");

            using (var readerFileOne = new StreamReader(filePath))
            {
                using (var readerFileTwo = new StreamReader(filePathExpected))
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
