using System;

namespace _02.RandomizeWords
{
    class RandomizeWords
    {
        static Random rnd = new Random();

        static void Main()
        {
            string text = Console.ReadLine();

            string[] rndWords = Randomize(text);

            Console.WriteLine(string.Join(Environment.NewLine, rndWords));
        }

        private static string[] Randomize(string text)
        {
            string[] words = text.Split();
            string[] rndWords = new string[words.Length];

            for (int i = 0; i < words.Length; i++)
            {
                while (true)
                {
                    int index = rnd.Next(0, words.Length);
                    if (rndWords[index] == null)
                    {
                        rndWords[index] = words[i];
                        break;
                    }
                }
                    
            }

            return rndWords;
        }
    }
}
