using System;
using System.Numerics;

namespace _11.Snowballs
{
    class Snowballs
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int maxSnowballSnow = 0;
            int maxSnowballTime = 0;
            int maxSnowballQuality = 0;
            BigInteger maxSnowballValue = 0;

            for (int i = 0; i < n; i++)
            {
                int curSnowballSnow = int.Parse(Console.ReadLine());
                int curSnowballTime = int.Parse(Console.ReadLine());
                int curSnowballQuality = int.Parse(Console.ReadLine());
                BigInteger curSnowballValue = PowerCalc((curSnowballSnow / curSnowballTime), curSnowballQuality);

                if (maxSnowballValue < curSnowballValue)
                {
                    maxSnowballSnow = curSnowballSnow;
                    maxSnowballTime = curSnowballTime;
                    maxSnowballQuality = curSnowballQuality;
                    maxSnowballValue = curSnowballValue;
                }
            }

            Console.WriteLine($"{maxSnowballSnow} : {maxSnowballTime} = {maxSnowballValue} ({maxSnowballQuality})");
             
        }

        private static BigInteger PowerCalc(int number, int pow)
        {
            BigInteger power = 1;

            for (int i = 0; i < pow; i++)
            {
                power *= (BigInteger)number;
            }
            return power;
        }
    }
}
