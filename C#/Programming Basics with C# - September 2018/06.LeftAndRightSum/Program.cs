using System;

namespace _06.LeftAndRightSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int inputVal = 0;
            int leftSum = 0;
            int rightSum = 0;

            for (int i = 0; i < n; i++)
            {
                inputVal = int.Parse(Console.ReadLine());
                leftSum = leftSum + inputVal;
            }
            for (int i = 0; i < n; i++)
            {
                inputVal = int.Parse(Console.ReadLine());
                rightSum = rightSum + inputVal;
            }

            if (leftSum == rightSum)
            {
                Console.WriteLine($"Yes, sum = {leftSum}");
            }
            else
            {
                Console.WriteLine($"No, diff = {Math.Abs(leftSum - rightSum)}");
            }
        }
    }
}
