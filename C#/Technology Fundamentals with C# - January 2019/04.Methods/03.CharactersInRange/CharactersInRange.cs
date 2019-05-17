using System;

namespace _03.CharactersInRange
{
    class CharactersInRange
    {
        static void Main()
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());
            char min = start;

            if (min > end)
            {
                start = end;
                end = min;
            }

            Console.WriteLine(GetRange((char)((int)start + 1), end));
        }

        private static string GetRange(char start, char end)
        {
            string range = null;

            for (char i = start; i < end; i++)
            {
                range = range + i + ' ';
            }

            return range;
        }
    }
}
