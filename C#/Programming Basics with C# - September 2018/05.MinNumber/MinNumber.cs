using System;

namespace _04.MinNumber
{
    class MinNumber
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int min = int.MaxValue;
            int input;

            for (int i = 0; i < n; i++)
            {
                input = int.Parse(Console.ReadLine());
                if (min > input)
                {
                    min = input;
                }
            }

            Console.WriteLine(min);
        }
    }
}
