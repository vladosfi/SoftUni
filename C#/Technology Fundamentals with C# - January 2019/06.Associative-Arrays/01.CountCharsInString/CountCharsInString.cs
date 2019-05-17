using System;
using System.Collections.Generic;

namespace _01.CountCharsInString
{
    class CountCharsInString
    {
        static void Main()
        {
            string text = Console.ReadLine();
            Dictionary<char, int> chars = new Dictionary<char, int>(); 

            foreach (char character in text)
            {
                if (character != ' ')
                {
                    if (!chars.ContainsKey(character))
                    {
                        chars.Add(character, 0);
                    }

                    chars[character]++;
                }
            }

            foreach (var kvp in chars)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
