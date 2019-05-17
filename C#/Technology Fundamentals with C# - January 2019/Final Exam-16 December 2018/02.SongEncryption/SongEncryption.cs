using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.SongEncryption
{
    class SongEncryption
    {
        static void Main()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input =="end")
                {
                    break;
                }
                string[] tokens = input.Split(":");
                string artist = tokens[0];
                string song = tokens[1];
                
                if (artist.Length == GetString(artist, @"[A-Z][a-z'\s]{2,}")
                    && song.Length == GetString(song, @"[A-Z\s]+"))
                {
                    int key = artist.Length;

                    input = IncrementASCIIValue(key, input);
                    input = input.Replace(":", "@");
                    Console.WriteLine($"Successful encryption: {input}");
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        private static string IncrementASCIIValue(int key, string input)
        {
            StringBuilder result = new StringBuilder();

            foreach (var symbol in input)
            {
                char incSymbol = symbol;

                if (symbol >= 65 && symbol <= 90)
                {
                    incSymbol = (char)(symbol + key);

                    if (symbol + key > 90)
                    {
                        int newCode = (symbol + key) - 91;

                        incSymbol = (char)(65 + newCode);
                    }
                }
                else if (symbol >= 97 && symbol <= 122)
                {
                    incSymbol = (char)(symbol + key);

                    if (symbol + key > 122)
                    {
                        int newCode = (symbol + key) - 123;

                        incSymbol = (char)(97 + newCode);
                    }
                }

                result.Append(incSymbol);
            }

            return result.ToString();
        }

        private static int GetString(string text, string pattern)
        {
            Regex regex = new Regex(pattern);

            Match match = regex.Match(text);

            return match.ToString().Length;
        }
    }
}
