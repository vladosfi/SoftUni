using System;

namespace _13.SpecialNumbers
{
    class SpecialNumbers
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int specialNumber = 0;
            int one, two, three, four;

            for (int i = 1111; i <= 9999; i++)
            {
                specialNumber = i;
                one = specialNumber % 10;
                specialNumber = specialNumber / 10;
                two = specialNumber % 10;
                specialNumber = specialNumber / 10;
                three = specialNumber % 10;
                four = specialNumber / 10;

                if (one > 0 && n % one == 0)
                {
                    if (two > 0 && n % two == 0)
                    {
                        if (three > 0 && n % three == 0)
                        {
                            if (n % four == 0)
                            {
                                Console.Write($"{i} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
