using System;

namespace _03.EvenPowerOf2
{
    class EvenPowerOf2
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            long pow = 1;

            for (int i = 0; i <= n; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine(pow);
                }
                else
                {
                    
                    if (i % 2 == 0)
                    {
                        pow = pow * 4;
                        Console.WriteLine(pow);
                    }
                }
            }
        }
    }
}
