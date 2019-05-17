using System;

namespace _10.LowerOrUpper
{
    class LowerOrUpper
    {
        static void Main()
        {
            char letter = char.Parse(Console.ReadLine());

            if (letter >= 97 && letter <= 122)
            {
                Console.WriteLine("lower-case");
            }
            else
            {
                Console.WriteLine("upper-case");
            }
        }
    }
}
