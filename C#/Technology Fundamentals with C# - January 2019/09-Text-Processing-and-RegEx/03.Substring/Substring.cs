using System;

namespace _03.Substring
{
    class Substring
    {
        static void Main()
        {
            string first = Console.ReadLine().ToLower();
            string second = Console.ReadLine().ToLower();

            while (second.IndexOf(first) != -1)
            {
                int startIndex = second.IndexOf(first);
                second = second.Remove(startIndex, first.Length);
            }

            Console.WriteLine(second);

        }
    }
}
