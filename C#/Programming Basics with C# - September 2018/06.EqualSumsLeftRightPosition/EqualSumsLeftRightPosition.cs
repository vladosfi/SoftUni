using System;

namespace _06.EqualSumsLeftRightPosition
{
    class EqualSumsLeftRightPosition
    {
        static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int leftSum = 0;
            int rightSum = 0;
            int midDigit = 0;
            int digit = 0;

            for (int i = a; i <= b; i++)
            {
                rightSum = 0;
                leftSum = 0;
                midDigit = 0;
                digit = i;

                for (int j = 0; j < 5; j++)
                {
                    if (j <= 1)
                    {
                        rightSum = rightSum + (digit % 10);
                    }
                    else if (j == 2)
                    {
                        midDigit = digit % 10;
                    }
                    else
                    {
                        leftSum = leftSum + (digit % 10);
                    }
                    digit = digit / 10;
                }

                if (leftSum == rightSum)
                {
                    Console.Write(i + " ");
                }
                else if (leftSum + midDigit == rightSum)
                {
                    Console.Write(i + " ");
                }
                else if (leftSum == rightSum + midDigit)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
