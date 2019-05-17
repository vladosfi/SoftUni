using System;

namespace _07.SumPrimeNonPrime
{
    class SumPrimeNonPrime
    {
        static void Main()
        {
            string number = "";
            int n = 0;
            int sumNonPrime = 0;
            int sumPrime = 0;
            bool prime;
            int sqrtN;

            while (number.ToLower() != "stop")
            {
                number = Console.ReadLine();

                if (int.TryParse(number, out n))
                {
                    if (n < 0)
                    {
                        Console.WriteLine("Number is negative.");
                    }
                    else if (n == 0 || n == 1)
                    {
                        sumNonPrime = sumNonPrime + n;
                    }
                    else if (n == 2)
                    {
                        sumPrime = sumPrime + n;
                    }
                    else if (n < 2147483647)
                    {
                        sqrtN = (int)Math.Sqrt((double)n) + 1;
                        prime = true;

                        for (int i = 2; i <= sqrtN; i++)
                        {
                            if (n % i == 0)
                            {
                                prime = false;
                                break;
                            }
                        }
                        if (prime)
                        {
                            sumPrime = sumPrime + n;
                        }
                        else
                        {
                            sumNonPrime = sumNonPrime + n;
                        }
                    }
                }
                
            }

            Console.WriteLine($"Sum of all prime numbers is: {sumPrime}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumNonPrime}");
        }
    }
}
