using System;

namespace _10.ToysStore
{
    class ToysStore
    {
        static void Main(string[] args)
        {
            decimal excursionPrice = decimal.Parse(Console.ReadLine());
            decimal puzzles = decimal.Parse(Console.ReadLine());
            decimal speakingDolls = decimal.Parse(Console.ReadLine());
            decimal teddyBears = decimal.Parse(Console.ReadLine());
            decimal minions = decimal.Parse(Console.ReadLine());
            decimal trucks = decimal.Parse(Console.ReadLine());
            
            decimal gain = 0;

            gain = (puzzles * 2.60m) + (speakingDolls * 3) + (teddyBears * 4.10m) + (minions * 8.20m) + (trucks * 2);

            //  Check for discount 
            if (puzzles + speakingDolls + teddyBears + minions + trucks >= 50)
            {
                gain = gain - (gain * 0.25m);
            }

            // Rent
            gain = gain - (gain * 0.1m);

            if (gain - excursionPrice >= 0)
            {
                Console.WriteLine($"Yes! {(gain - excursionPrice):F02} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {(excursionPrice - gain):F02} lv needed.");
            }

        }
    }
}
