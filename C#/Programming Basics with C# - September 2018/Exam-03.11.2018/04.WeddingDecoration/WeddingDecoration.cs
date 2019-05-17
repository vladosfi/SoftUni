using System;

namespace _04.WeddingDecoration
{
    class WeddingDecoration
    {
        static void Main()
        {
            decimal budget = decimal.Parse(Console.ReadLine());
            decimal spendMoney = 0;
            string articleType = "";
            int articleCount = 0;
            decimal articlePrice = 0;
            int balloonsCount = 0;
            int flowersCount = 0;
            int candlesCount = 0;
            int ribbon = 0;


            do
            {
                articlePrice = 0;
                articleType = Console.ReadLine();

                if (articleType == "stop")
                {
                    break;
                }

                articleCount = int.Parse(Console.ReadLine());

                switch (articleType)
                {
                    case "balloons":
                        articlePrice = articleCount * 0.1m;
                        balloonsCount = balloonsCount + articleCount;
                        break;
                    case "flowers":
                        articlePrice = articleCount * 1.5m;
                        flowersCount = flowersCount + articleCount;
                        break;
                    case "candles":
                        articlePrice = articleCount * 0.5m;
                        candlesCount = candlesCount + articleCount;
                        break;
                    case "ribbon":
                        articlePrice = articleCount * 2m;
                        ribbon = ribbon + articleCount;
                        break;
                    default:
                        break;
                }

                spendMoney = spendMoney + articlePrice;
                budget = budget - articlePrice;

            } while (budget > 0);

            if (articleType == "stop")
            {
                Console.WriteLine($"Spend money: {spendMoney:f02}");
                Console.WriteLine($"Money left: {budget:f02}");
            }
            else if (budget <= 0)
            {
                Console.WriteLine("All money is spent!");
            }

            Console.WriteLine($"Purchased decoration is {balloonsCount} balloons, " +
                $"{ribbon} m ribbon, {flowersCount} flowers and {candlesCount} candles.");
        }
    }
}
