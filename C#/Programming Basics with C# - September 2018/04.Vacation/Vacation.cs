using System;

namespace _04.Vacation
{
    class Vacation
    {
        static void Main(string[] args)
        {
            double moneyForVac = double.Parse(Console.ReadLine());
            double cash = double.Parse(Console.ReadLine());
            string action = "";
            double moneyForAction = 0;
            int spendCount = 0;
            int days = 0;

            do
            {
                action = Console.ReadLine();
                moneyForAction = double.Parse(Console.ReadLine());
                days++;

                if (action == "spend")
                {
                    spendCount++;
                    cash = cash - moneyForAction;
                    if (cash <= 0)
                    {
                        cash = 0;
                    }
                }
                else if(action == "save")
                {
                    cash = cash + moneyForAction;
                    spendCount = 0;
                }
            } while (spendCount < 5 && cash < moneyForVac);


            if (spendCount == 5)
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine(days);
            }
            else if (spendCount < 5)
            {
                Console.WriteLine($"You saved the money for {days} days.");
            }
        }
    }
}
