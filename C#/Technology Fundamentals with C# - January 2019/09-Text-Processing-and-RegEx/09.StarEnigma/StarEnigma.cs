using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _09.StarEnigma
{
    class StarEnigma
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<string> atacketPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string text = Console.ReadLine();
                int key = GetKey(text);
                string decryptedText = DecryptedText(key, text);
                
                string planetName = GetString(decryptedText, @"(?<=@)[A-Za-z]+");
                bool validInput = ValidParameter(decryptedText, @"@(?<name>[A-Za-z]+)([^@:!\->]*):(?<population>[0-9]+)([^@:!\->]*)!(?<type>(A|D))!([^@:!\->]*)->(?<count>[0-9]+)");

                if (validInput)
                {
                    if (ValidParameter(decryptedText, @"(?<=!)[A](?=!)"))
                    {
                        atacketPlanets.Add(planetName);
                    }
                    else if (ValidParameter(decryptedText, @"(?<=!)[D](?=!)"))
                    {
                        destroyedPlanets.Add(planetName);
                    }
                }    
            }

            Console.WriteLine($"Attacked planets: {atacketPlanets.Count}");
            atacketPlanets.Sort();
            foreach (string planet in atacketPlanets)
            {
                Console.WriteLine($"-> {planet}");
            }
            
            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            destroyedPlanets.Sort();
            foreach (string planet in destroyedPlanets)
            {
                Console.WriteLine($"-> {planet}");
            }
            
        }
        private static bool ValidParameter(string decryptedText, string pattern)
        {
            Regex regex = new Regex(pattern);

            return regex.IsMatch(decryptedText);
        }

        private static string GetString(string decryptedText, string pattern)
        {
            Regex regex = new Regex(pattern);

            Match match = regex.Match(decryptedText);

            return match.ToString();
        }

        private static string DecryptedText(int key, string text)
        {
            string decryptedText = string.Empty;

            foreach (var character in text)
            {
                decryptedText += (char)(character - key);
            }

            return decryptedText;
        }

        private static int GetKey(string text)
        {
            int key = 0;
            char[] keyLetters = { 's', 't', 'a', 'r' };
            text = text.ToLower();

            foreach (var letter in keyLetters)
            {
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] == letter)
                    {
                        key++;
                    }
                }
            }

            return key;
        }
    }
}
