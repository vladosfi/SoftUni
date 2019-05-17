using System;

namespace _07.OddEvenSum
{
    class OddEvenSum
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int inputNumber=0;
            bool even = true;
            int sumEven=0;
            int sumOdd=0;

            for (int i = 0; i < n; i++)
            {
                inputNumber = int.Parse(Console.ReadLine());
                even = !even;

                if (even)
                {
                    sumEven = sumEven + inputNumber;
                }
                else
                {
                    sumOdd = sumOdd + inputNumber;
                }
            }

            if (sumOdd == sumEven)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {sumEven}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(sumEven - sumOdd)}");
            }
        }
    }
}
