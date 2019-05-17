using System;

namespace _02.HalfSumElement
{
    class HalfSumElement
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int max = int.MinValue;
            int number = 0;

            for (int i = 0; i < n; i++)
            {
                number = int.Parse(Console.ReadLine());

                if (max < number)
                {
                    max = number;
                }
                sum = sum + number;
            }

            sum = sum - max;
            if (sum == max)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {sum}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(max - sum)}");
            }
        }
    }
}
