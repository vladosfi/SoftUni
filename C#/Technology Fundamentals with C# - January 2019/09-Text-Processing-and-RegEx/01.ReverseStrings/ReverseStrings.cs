using System;

namespace _01.ReverseStrings
{
    class ReverseStrings
    {
        static void Main()
        {
            while (true)
            {
                string word = Console.ReadLine();
                string reversedWord = null;

                if (word.ToLower() == "end")
                {
                    break;
                }

                Console.Write($"{word} = ");

                foreach (var @char in word)
                {
                    reversedWord = @char + reversedWord;
                }

                Console.WriteLine($"{reversedWord}");
            }
        }
    }
}