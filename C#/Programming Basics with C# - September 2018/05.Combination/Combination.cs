using System;

namespace _05.Combination
{
    class Combination
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 0;

            for (int a = 0; a <= n; a++)
            {
                for (int b = 0; b <= n; b++)
                {
                    for (int c = 0; c <= n; c++)
                    {
                        for (int d = 0; d <= n; d++)
                        {
                            for (int e = 0; e <= n; e++)
                            {
                                if (a + b + c + d + e == n)
                                {
                                    counter++;
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}
