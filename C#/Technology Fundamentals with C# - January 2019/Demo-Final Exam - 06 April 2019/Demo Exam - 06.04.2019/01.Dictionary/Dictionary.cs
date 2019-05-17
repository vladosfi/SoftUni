using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem1
{
    class Dictionary
    {
        static void Main()
        {
            string[] inputData = Console.ReadLine().Split(" | ");
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
            

            for (int i = 0; i < inputData.Length; i++)
            {
                string[] tokens = inputData[i].Split(": ");
                string word = tokens[0];
                string description = tokens[1];
                
                if (!dictionary.ContainsKey(word))
                {
                    dictionary.Add(word, new List<string>());
                }

                dictionary[word].Add(description);
            }

            string[] searchedWords = Console.ReadLine().Split(" | ");

            foreach (var searched in searchedWords)
            {
                if (dictionary.ContainsKey(searched))
                {
                    Console.WriteLine($"{searched}");
                    foreach (var item in dictionary[searched].OrderByDescending(x => x.Length))
                    {
                        Console.WriteLine($" -{item}");
                    }
                }
            }

            string command = Console.ReadLine();

            if (command.ToLower() == "end")
            {
                return;
            }
            else if (command.ToLower() == "list")
            {
                foreach (var w in dictionary.OrderBy(x=>x.Key))
                {
                    Console.Write($"{w.Key} ");
                }
                Console.WriteLine();
            }
        }
    }
}
