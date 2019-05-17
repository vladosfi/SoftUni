using System;

namespace _09.Fishing
{
    class Fishing
    {
        static void Main()
        {
            int dayQuota = int.Parse(Console.ReadLine());
            string fishName;
            double fishKilo;
            int counter = 0;
            double profitLoss = 0;
            double fishPrice = 0;

            while ((fishName = Console.ReadLine()) != "Stop")
            {
                fishKilo = double.Parse(Console.ReadLine());
                fishPrice = 0;
                counter++;

                foreach (char letter in fishName)
                {
                    fishPrice = fishPrice + (int)letter;
                }
                fishPrice = fishPrice / fishKilo;

                if (counter % 3 == 0)
                {
                    profitLoss = profitLoss + fishPrice;
                }
                else
                {
                    profitLoss = profitLoss - fishPrice;
                }

                if (counter == dayQuota)
                {
                    break;
                }
            }

            if (counter == dayQuota)
            {
                Console.WriteLine("Lyubo fulfilled the quota!");
            }

            if (profitLoss >= 0)
            {
                Console.WriteLine($"Lyubo's profit from {counter} fishes is {profitLoss:F02} leva.");
            }
            else
            {
                Console.WriteLine($"Lyubo lost {Math.Abs(profitLoss):F02} leva today.");
            }
        }
    }
}
