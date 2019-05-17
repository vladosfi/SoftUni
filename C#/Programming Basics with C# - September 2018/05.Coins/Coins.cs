using System;

namespace _05.Coins
{
    class Coins
    {
        static void Main(string[] args)
        {
            decimal coins = decimal.Parse(Console.ReadLine());
            int restCount = 0;


            while (coins > 0)
            {
                if (coins >= 2)
                {
                    coins = coins - 2;
                    restCount++;
                }
                else if (coins >= 1)
                {
                    coins = coins - 1;
                    restCount++;
                }
                else if (coins >= 0.5m)
                {
                    coins = coins - 0.5m;
                    restCount++;
                }
                else if (coins >= 0.2m)
                {
                    coins = coins - 0.2m;
                    restCount++;
                }
                else if (coins >= 0.1m)
                {
                    coins = coins - 0.1m;
                    restCount++;
                }
                else if (coins >= 0.05m)
                {
                    coins = coins - 0.05m;
                    restCount++;
                }
                else if (coins >= 0.02m)
                {
                    coins = coins - 0.02m;
                    restCount++;
                }
                else if (coins >= 0.01m)
                {
                    coins = coins - 0.01m;
                    restCount++;
                }
            }
            Console.WriteLine(restCount);
        }
    }
}
