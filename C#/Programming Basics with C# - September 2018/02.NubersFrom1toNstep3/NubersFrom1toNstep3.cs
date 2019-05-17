using System;

namespace _02.NubersFrom1toNstep3
{
    class NubersFrom1toNstep3
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i += 3)
            {
                Console.WriteLine(i);
            }
        }
    }
}
