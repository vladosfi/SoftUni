using System;

namespace _10.TopNumber
{
    class TopNumber
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                if (IsSumDivisible(i) && ContainOddDigit(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        private static bool ContainOddDigit(int number)
        {
            int n = number;
            while (n > 0)
            {
                if (n % 2 != 0)
                {
                    return true;
                } 
                n /= 10;
            }
            return false;
        }

        private static bool IsSumDivisible(int number)
        {
            int n = number;
            int sum = 0;

            while (n > 0)
            {
                sum += n % 10;
                n /= 10;
            }

            return sum % 8 == 0 || sum % 88 == 0 ? true : false;
        }
    }
}
