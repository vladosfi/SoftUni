using System;
using System.Collections.Generic;

namespace _04.MorseCodeTranslator
{
    class MorseCodeTranslator
    {
        static void Main()
        {
            string[] morseCode = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, char> morseCodeDictionary = new Dictionary<string, char>();
            SetMorseCode(morseCodeDictionary);

            foreach (var letter in morseCode)
            {
                Console.Write(morseCodeDictionary[letter]);
            }
            Console.WriteLine();
        }

        private static void SetMorseCode(Dictionary<string, char> morseCodeDictionary)
        {
            morseCodeDictionary.Add(".-", 'A');
            morseCodeDictionary.Add("-...", 'B');
            morseCodeDictionary.Add("-.-.", 'C');
            morseCodeDictionary.Add("-..", 'D');
            morseCodeDictionary.Add(".", 'E');
            morseCodeDictionary.Add("..-.", 'F');
            morseCodeDictionary.Add("--.", 'G');
            morseCodeDictionary.Add("....", 'H');
            morseCodeDictionary.Add("..", 'I');
            morseCodeDictionary.Add(".---", 'J');
            morseCodeDictionary.Add("-.-", 'K');
            morseCodeDictionary.Add(".-..", 'L');
            morseCodeDictionary.Add("--", 'M');
            morseCodeDictionary.Add("-.", 'N');
            morseCodeDictionary.Add("---", 'O');
            morseCodeDictionary.Add(".--.", 'P');
            morseCodeDictionary.Add("--.-", 'Q');
            morseCodeDictionary.Add(".-.", 'R');
            morseCodeDictionary.Add("...", 'S');
            morseCodeDictionary.Add("-", 'T');
            morseCodeDictionary.Add("..-", 'U');
            morseCodeDictionary.Add("...-", 'V');
            morseCodeDictionary.Add(".--", 'W');
            morseCodeDictionary.Add("-..-", 'X');
            morseCodeDictionary.Add("-.--", 'Y');
            morseCodeDictionary.Add("--..", 'Z');
            morseCodeDictionary.Add("|", ' ');
        }
    }
}
