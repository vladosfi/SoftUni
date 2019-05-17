using System;

namespace _11.ShoppingManiac
{
    class ShoppingManiac
    {
        static void Main()
        {
            int sumForSpend = int.Parse(Console.ReadLine());
            int spendMoney = 0;
            string command = "";
            int clothesCounter = 0;
            int articlePrice = 0;

            while (command != "enough" && sumForSpend > 0)
            {
                command = Console.ReadLine();

                if (command == "enter")
                {
                    while (command != "leave" && sumForSpend > 0)
                    {
                        command = Console.ReadLine();

                        if (int.TryParse(command, out articlePrice))
                        {
                            if (sumForSpend > 0 && sumForSpend >= articlePrice)
                            {
                                clothesCounter++;
                                spendMoney = spendMoney + articlePrice;
                                sumForSpend = sumForSpend - articlePrice;
                            }
                            else
                            {
                                Console.WriteLine("Not enough money.");
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"For {clothesCounter} clothes I spent {spendMoney} lv and have {sumForSpend} lv left.");
        }
    }
}
