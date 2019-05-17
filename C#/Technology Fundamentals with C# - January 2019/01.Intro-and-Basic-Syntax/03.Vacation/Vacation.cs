using System;

namespace _03.Vacation
{
    class Vacation
    {
        static void Main()
        {
            int personsCount = int.Parse(Console.ReadLine());
            string groupeType = Console.ReadLine();
            string day = Console.ReadLine();            
            decimal priceDiscount = 0;

            if (groupeType == "Students" && personsCount >= 30)
            {
                priceDiscount = 0.15m;
            }
            else if (groupeType == "Business" && personsCount >= 100)
            {
                personsCount -= 10;
            }
            else if (groupeType == "Regular" && personsCount >= 10 && personsCount <= 20)
            {
                priceDiscount = 0.05m;
            }

            decimal totalPrice = personsCount;

            if (day == "Friday")
            {
                if (groupeType == "Students")
                {
                    totalPrice = totalPrice * 8.45m ;
                    totalPrice -= totalPrice * priceDiscount;
                }
                else if (groupeType == "Business")
                {
                    totalPrice *= 10.90m;
                }
                else
                {
                    totalPrice = totalPrice * 15;
                    totalPrice -= totalPrice * priceDiscount;
                }
            }
            else if (day == "Saturday")
            {
                if (groupeType == "Students")
                {
                    totalPrice = totalPrice * 9.80m;
                    totalPrice -= totalPrice * priceDiscount;
                }
                else if (groupeType == "Business")
                {
                    totalPrice *= 15.60m;
                }
                else
                {
                    totalPrice = totalPrice * 20;
                    totalPrice -= totalPrice * priceDiscount;
                }
            }
            else if (day == "Sunday")
            {
                if (groupeType == "Students")
                {
                    totalPrice = totalPrice * 10.46m;
                    totalPrice -= totalPrice * priceDiscount;
                }
                else if (groupeType == "Business")
                {
                    totalPrice *= 16;
                }
                else
                {
                    totalPrice = totalPrice * 22.50m;
                    totalPrice -= totalPrice * priceDiscount;
                }
            }

            Console.WriteLine($"Total price: {totalPrice:f2}");


        }
    }
}
