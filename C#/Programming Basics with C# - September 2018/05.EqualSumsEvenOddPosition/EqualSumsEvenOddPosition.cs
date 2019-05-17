using System;

namespace _05.EqualSumsEvenOddPosition
{
    class EqualSumsEvenOddPosition
    {
        static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int evenSum = 0;
            int oddSum = 0;
            int currentNumber = 0;
            bool odd = true;

            for (int i = a; i <= b; i++)
            {
                evenSum = 0;
                oddSum = 0;
                currentNumber = i;

                for (int j = 0; j < 6; j++)
                {
                    if (odd)
                    {
                        oddSum = oddSum + currentNumber % 10; 
                    }
                    else
                    {
                        evenSum = evenSum + currentNumber % 10; 
                    }

                    odd = !odd;
                    currentNumber = currentNumber / 10;
                }

                if (oddSum == evenSum)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
