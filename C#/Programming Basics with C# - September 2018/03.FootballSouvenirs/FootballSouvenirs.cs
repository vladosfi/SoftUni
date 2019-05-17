using System;

namespace _03.FootballSouvenirs
{
    class FootballSouvenirs
    {
        static void Main()
        {
            string team = Console.ReadLine();
            string souvenirs = Console.ReadLine();
            int countSouvenirs = int.Parse(Console.ReadLine());
            double totalSum = 0;

            if (team == "Argentina")
            {
                if (souvenirs == "flags")
                {
                    totalSum = countSouvenirs * 3.25;
                }
                else if (souvenirs == "caps")
                {
                    totalSum = countSouvenirs * 7.20;
                }
                else if (souvenirs == "posters")
                {
                    totalSum = countSouvenirs * 5.10;
                }
                else if (souvenirs == "stickers")
                {
                    totalSum = countSouvenirs * 1.25;
                }
            }
            else if (team == "Brazil")
            {
                if (souvenirs == "flags")
                {
                    totalSum = countSouvenirs * 4.20;
                }
                else if (souvenirs == "caps")
                {
                    totalSum = countSouvenirs * 8.50;
                }
                else if (souvenirs == "posters")
                {
                    totalSum = countSouvenirs * 5.35;
                }
                else if (souvenirs == "stickers")
                {
                    totalSum = countSouvenirs * 1.20;
                }
            }
            else if (team == "Croatia")
            {
                if (souvenirs == "flags")
                {
                    totalSum = countSouvenirs * 2.75;
                }
                else if (souvenirs == "caps")
                {
                    totalSum = countSouvenirs * 6.90;
                }
                else if (souvenirs == "posters")
                {
                    totalSum = countSouvenirs * 4.95;
                }
                else if (souvenirs == "stickers")
                {
                    totalSum = countSouvenirs * 1.10;
                }
            }
            else if (team == "Denmark")
            {
                if (souvenirs == "flags")
                {
                    totalSum = countSouvenirs * 3.10;
                }
                else if (souvenirs == "caps")
                {
                    totalSum = countSouvenirs * 6.50;
                }
                else if (souvenirs == "posters")
                {
                    totalSum = countSouvenirs * 4.80;
                }
                else if (souvenirs == "stickers")
                {
                    totalSum = countSouvenirs * 0.90;
                }
            }

            if (!(team == "Argentina" || team == "Brazil" || team == "Croatia" || team == "Denmark"))
            {
                Console.WriteLine("Invalid country!");
            }
            else if(!(souvenirs == "flags" || souvenirs == "caps" || souvenirs == "posters" || souvenirs == "stickers"))
            {
                Console.WriteLine("Invalid stock!");
            }
            else
            {
                Console.WriteLine($"Pepi bought {countSouvenirs} {souvenirs} of {team} for {totalSum:f02} lv.");
            }
            
        }
    }
}
