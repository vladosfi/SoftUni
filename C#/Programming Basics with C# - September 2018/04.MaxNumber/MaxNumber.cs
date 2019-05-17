using System;

namespace _04.MaxNumber
{
    class MaxNumber
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int max = int.MinValue;
            int input;

            for (int i = 0; i < n; i++)
            {
                input = int.Parse(Console.ReadLine());
                if (max < input)
                {
                    max = input;
                }
            }

            Console.WriteLine(max);
        }
    }
}
