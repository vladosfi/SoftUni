using System;

namespace _10.MatchTickets
{
    class MatchTickets
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string ticketCategory = Console.ReadLine();
            int peopleNumber = int.Parse(Console.ReadLine());
            double transportPercent = 0;
            double ticketsPrice = 0;
            double moneyLeft = 0;
            

            if (ticketCategory == "VIP")
            {
                ticketsPrice = peopleNumber * 499.99;

                if (peopleNumber >= 1 && peopleNumber <= 4)
                {
                    transportPercent = budget * 0.75;
                }
                else if (peopleNumber >= 5 && peopleNumber <= 9)
                {
                    transportPercent = budget * 0.60;
                }
                else if (peopleNumber >= 10 && peopleNumber <= 24)
                {
                    transportPercent = budget * 0.50;
                }
                else if (peopleNumber >= 25 && peopleNumber <= 49)
                {
                    transportPercent = budget * 0.40;
                }
                else if (peopleNumber >= 50)
                {
                    transportPercent = budget * 0.25;
                }
            }
            else if (ticketCategory == "Normal")
            {
                ticketsPrice = peopleNumber * 249.99;

                if (peopleNumber >= 1 && peopleNumber <= 4)
                {
                    transportPercent = budget * 0.75;
                }
                else if (peopleNumber >= 5 && peopleNumber <= 9)
                {
                    transportPercent = budget * 0.60;
                }
                else if (peopleNumber >= 10 && peopleNumber <= 24)
                {
                    transportPercent = budget * 0.50;
                }
                else if (peopleNumber >= 25 && peopleNumber <= 49)
                {
                    transportPercent = budget * 0.40;
                }
                else if (peopleNumber >= 50)
                {
                    transportPercent = budget * 0.25;
                }
            }


            moneyLeft = budget - transportPercent;
            if (moneyLeft >= ticketsPrice)
            {
                Console.WriteLine($"Yes! You have {(moneyLeft - ticketsPrice):f02} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {(ticketsPrice - moneyLeft):f02} leva.");
            }
                
            
        }
    }
}
