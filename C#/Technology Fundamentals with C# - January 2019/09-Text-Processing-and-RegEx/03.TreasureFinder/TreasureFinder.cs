using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.TreasureFinder
{
    class TreasureFinder
    {
        static void Main()
        {
            int[] key = Console.ReadLine().Split().Select(int.Parse).ToArray();

            while (true)
            {
                string input = Console.ReadLine();
                string decryptedText = string.Empty;

                if (input == "find")
                {
                    break;
                }


                for (int i = 0; i < input.Length; i++)
                {
                    int j = i % key.Length;
                    decryptedText += (char)(input[i] - key[j]);   
                }

                string type = SearchBetween(@"(?<=&)[\w]+(?=&)", decryptedText);
                string coordinates = SearchBetween(@"(?<=<)[\w]+(?=>)", decryptedText);
                Console.WriteLine($"Found {type} at {coordinates}");
                
            }            
        }

        public static string SearchBetween(string pattern, string text)
        {
            Regex regex = new Regex(pattern);
            Match match = regex.Match(text);
            return match.ToString();
        }
    }
}
