using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.TheFinalQuest
{
    class TheFinalQuest
    {
        static void Main()
        {
            List<string> collectionOfWords = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (true)
            {
                string[] tokens = Console.ReadLine().Split();
                string command = tokens[0];

                if (command.ToLower() == "stop")
                {
                    break;
                }
                else if (command.ToLower() == "delete")
                {
                    int index = int.Parse(tokens[1]) + 1;

                    if (index >= 0 && index < collectionOfWords.Count)
                    {
                        collectionOfWords.RemoveAt(index);
                    }
                }
                else if (command.ToLower() == "swap")
                {
                    string word1 = tokens[1];
                    string word2 = tokens[2];

                    int index1 = collectionOfWords.IndexOf(word1);
                    int index2 = collectionOfWords.IndexOf(word2);

                    if (index1 >= 0 && index1 < collectionOfWords.Count && index2 >= 0 && index2 < collectionOfWords.Count)
                    {
                        collectionOfWords[index1] = word2;
                        collectionOfWords[index2] = word1;
                    }
                }
                else if (command.ToLower() == "put")
                {
                    string word = tokens[1];
                    int index = int.Parse(tokens[2]) - 1;

                    if (index >= 0 && index <= collectionOfWords.Count)
                    {
                        collectionOfWords.Insert(index, word);
                    }
                }
                else if (command.ToLower() == "sort")
                {
                    if (collectionOfWords.Any())
                    {
                        collectionOfWords = collectionOfWords.OrderByDescending(x=>x).ToList();
                    }
                }
                else if (command.ToLower() == "replace")
                {
                    string word1 = tokens[1];
                    string word2 = tokens[2];

                    if (collectionOfWords.Any())
                    {
                        int index = collectionOfWords.IndexOf(word2);

                        if (index != -1)
                        {
                            collectionOfWords[index] = word1;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", collectionOfWords));
        }
    }
}
