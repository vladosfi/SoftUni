using System;

namespace _03.SushiTime
{
    class SushiTime
    {
        static void Main()
        {
            string sushiType = Console.ReadLine();
            string restaurant = Console.ReadLine();
            int portionCount = int.Parse(Console.ReadLine());
            char order = char.Parse(Console.ReadLine());
            double totalPrice = 0;
            bool invalidRestaurant = false;

            if (restaurant == "Sushi Zone")
            {
                if (sushiType == "sashimi")
                {
                    totalPrice = portionCount * 4.99;
                }
                else if (sushiType == "maki")
                {
                    totalPrice = portionCount * 5.29;
                }
                else if (sushiType == "uramaki")
                {
                    totalPrice = portionCount * 5.99;
                }
                else if (sushiType == "temaki")
                {
                    totalPrice = portionCount * 4.29;
                }
            }
            else if (restaurant == "Sushi Time")
            {
                if (sushiType == "sashimi")
                {
                    totalPrice = portionCount * 5.49;
                }
                else if (sushiType == "maki")
                {
                    totalPrice = portionCount * 4.69;
                }
                else if (sushiType == "uramaki")
                {
                    totalPrice = portionCount * 4.49;
                }
                else if (sushiType == "temaki")
                {
                    totalPrice = portionCount * 5.19;
                }
            }
            else if (restaurant == "Sushi Bar")
            {
                if (sushiType == "sashimi")
                {
                    totalPrice = portionCount * 5.25;
                }
                else if (sushiType == "maki")
                {
                    totalPrice = portionCount * 5.55;
                }
                else if (sushiType == "uramaki")
                {
                    totalPrice = portionCount * 6.25;
                }
                else if (sushiType == "temaki")
                {
                    totalPrice = portionCount * 4.75;
                }
            }
            else if (restaurant == "Asian Pub")
            {
                if (sushiType == "sashimi")
                {
                    totalPrice = portionCount * 4.50;
                }
                else if (sushiType == "maki")
                {
                    totalPrice = portionCount * 4.80;
                }
                else if (sushiType == "uramaki")
                {
                    totalPrice = portionCount * 5.50;
                }
                else if (sushiType == "temaki")
                {
                    totalPrice = portionCount * 5.50;
                }
            }
            else
            {
                Console.WriteLine($"{restaurant} is invalid restaurant!");
                invalidRestaurant = true;
            }

            if (invalidRestaurant == false)
            {
                if (order == 'Y')
                {
                    totalPrice = totalPrice * 1.2;
                }
                Console.WriteLine($"Total price: {Math.Ceiling(totalPrice)} lv.");
            }
        }
    }
}
