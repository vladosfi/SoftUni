using System;

namespace _04.TextFilter
{
    class TextFilter
    {
        static void Main()
        {
            string[] bannedWords = Console.ReadLine().Split(", ");
            string text = Console.ReadLine();

            foreach (var banned in bannedWords)
            {
                while (text.IndexOf(banned) != -1)
                {
                    text = text.Replace(banned, new string('*', banned.Length));
                }
            }

            Console.WriteLine(text);
        }
    }
}
