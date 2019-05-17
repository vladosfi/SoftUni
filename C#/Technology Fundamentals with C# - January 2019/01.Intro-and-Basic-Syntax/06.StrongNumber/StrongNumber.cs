using System;

namespace _06.StrongNumber
{
    class StrongNumber
    {
        static void Main()
        {
            string stringNumber = Console.ReadLine();
            int sumOfFacttorials = 0;

            foreach (var digit in stringNumber)
            {
                sumOfFacttorials += Factorial(int.Parse(digit.ToString()));
            }

            if (int.Parse(stringNumber) == sumOfFacttorials)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }

        static int Factorial(int digit)
        {
            int factorial = 1;

            for (int i = 2; i <= digit; i++)
            {
                factorial *= i;
            }

            return factorial;
        }
    }
}
