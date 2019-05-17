using System;

namespace _07.VendingMachine
{
    class VendingMachine
    {
        static void Main()
        {
            decimal totalMoney = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Start")
                {
                    break;
                }

                decimal coin = decimal.Parse(input);

                if (coin == 0.1m || coin == 0.2m || coin == 0.5m || coin == 1 || coin == 2)
                {
                    totalMoney += coin;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coin}");
                }

            }


            while (true)
            {
                string productName= Console.ReadLine();
                decimal productPrice = 0;

                if (productName == "End")
                {
                    break;
                }

                if (productName == "Nuts")
                {
                    productPrice = 2;
                }
                else if (productName == "Water")
                {
                    productPrice = 0.7m;
                }
                else if (productName == "Crisps")
                {
                    productPrice = 1.5m;
                }
                else if (productName == "Soda")
                {
                    productPrice = 0.8m;
                }
                else if (productName == "Coke")
                {
                    productPrice = 1;
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }

                if (productPrice != 0)
                {
                    if (totalMoney >= productPrice)
                    {
                        totalMoney -= productPrice;
                        Console.WriteLine($"Purchased {productName.ToLower()}");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
            }

            Console.WriteLine($"Change: {totalMoney:f2}");
        }
    }
}
