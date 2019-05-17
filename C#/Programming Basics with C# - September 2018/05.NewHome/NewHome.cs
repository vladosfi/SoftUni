using System;

namespace _05.NewHome
{
    class NewHome
    {
        static void Main(string[] args)
        {
            string flowersType = Console.ReadLine();
            int flowersCount = int.Parse(Console.ReadLine());
            decimal budget = int.Parse(Console.ReadLine());
            decimal expenses = 0;

            if (flowersType == "Roses")
            {
                if (flowersCount > 80)
                {
                    expenses = (flowersCount * 5);
                    expenses = expenses - (expenses * 0.1m);
                }
                else
                {
                    expenses = flowersCount * 5;
                }
                
            }
            else if (flowersType == "Dahlias")
            {
                if (flowersCount > 90)
                {
                    expenses = (flowersCount * 3.80m);
                    expenses = expenses - (expenses * 0.15m);
                }
                else
                {
                    expenses = flowersCount * 3.80m;
                }
            }
            else if (flowersType == "Tulips")
            {
                if (flowersCount > 80)
                {
                    expenses = (flowersCount * 2.80m);
                    expenses = expenses - (expenses * 0.15m);
                }
                else
                {
                    expenses = flowersCount * 2.80m;
                }
            }
            else if (flowersType == "Narcissus")
            {
                if (flowersCount < 120)
                {
                    expenses = flowersCount * 3;
                    expenses = expenses + (expenses * 0.15m);
                }
                else
                {
                    expenses = flowersCount * 3;
                }
            }
            else if (flowersType == "Gladiolus")
            {
                if (flowersCount < 80)
                {
                    expenses = flowersCount * 2.50m;
                    expenses = expenses + (expenses * 0.20m);
                }
                else
                {
                    expenses = flowersCount * 2.50m;
                }
            }


            if (budget >= expenses)
            {
                Console.WriteLine($"Hey, you have a great garden with {flowersCount} {flowersType} and {(budget - expenses):f02} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {(expenses - budget):f02} leva more.");
            }
            
        }
    }
}
