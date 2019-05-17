using System;
using System.Text;

namespace _02.RepeatStrings
{
    class RepeatStrings
    {
        static void Main()
        {
            string[] stringArray = Console.ReadLine().Split();
            StringBuilder sb = new StringBuilder();

            foreach (var word in stringArray)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    sb.Append(word);
                }
            }

            Console.WriteLine(sb);
        }
    }
}
