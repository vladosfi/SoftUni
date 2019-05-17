using System;

namespace _03.RecursiveFibonacci
{
    class RecursiveFibonacci
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(GetFibonacci(n));
        }

        private static long GetFibonacci(int n)
        {
            if (n <= 2)
            {
                return 1;
            }

            return GetFibonacci(n - 1) + GetFibonacci(n - 2);
        }
    }
}
