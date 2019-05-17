using System;

namespace _03.OddEvenPosition
{
    class OddEvenPosition
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            double evenSum = 0;
            double evenMin = 1000000000.0;
            double evenMax = -1000000000.0;
            double oddSum = 0;
            double oddMin = 1000000000.0;
            double oddMax = -1000000000.0;
            double number = 0;

            for (int i = 1; i <= n; i++)
            {
                number = double.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    if (evenMin > number)
                    {
                        evenMin = number;
                    }
                    if (evenMax < number)
                    {
                        evenMax = number;
                    }
                    evenSum = evenSum + number;
                }
                else
                {
                    if (oddMin > number)
                    {
                        oddMin = number;
                    }
                    if (oddMax < number)
                    {
                        oddMax = number;
                    }
                    oddSum = oddSum + number;
                }
            }

            Console.WriteLine($"OddSum={oddSum},");
            if (oddMin != 1000000000.0)
            {
                Console.WriteLine($"oddMin={oddMin},");
            }
            else
            {
                Console.WriteLine($"oddMin=No,");
            }
            if (oddMax != -1000000000.0)
            {
                Console.WriteLine($"oddMax={oddMax},");
            }
            else
            {
                Console.WriteLine($"oddMax=No,");
            }
            

            Console.WriteLine($"EvenSum={evenSum}");
            if (evenMin != 1000000000.0)
            {
                Console.WriteLine($"evenMin={evenMin},");
            }
            else
            {
                Console.WriteLine($"evenMin=No,");
            }
            if (evenMax != -1000000000.0)
            {
                Console.WriteLine($"evenMax={evenMax}");
            }
            else
            {
                Console.WriteLine($"evenMax=No");
            }
        }
    }
}
