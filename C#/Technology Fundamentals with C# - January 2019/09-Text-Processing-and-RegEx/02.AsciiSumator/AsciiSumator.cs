using System;

namespace _02.AsciiSumator
{
    class AsciiSumator
    {
        static void Main()
        {
            char startSymbol = char.Parse(Console.ReadLine());
            char endSymbol = char.Parse(Console.ReadLine());
            string text = Console.ReadLine();
            int sum = 0;

            foreach (var character in text)
            {
                if (character > startSymbol && character < endSymbol)
                {
                    sum += (int)character;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
