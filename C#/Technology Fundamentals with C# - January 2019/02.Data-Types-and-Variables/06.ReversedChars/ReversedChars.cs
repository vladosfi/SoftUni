using System;

namespace _06.ReversedChars
{
    class ReversedChars
    {
        static void Main()
        {
            string input = null;

            for (int i = 0; i < 3; i++)
            {
                input = Console.ReadLine() + " " + input;
            }

            Console.Write(input);
        }
    }
}
