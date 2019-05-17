using System;

namespace _01.WeddingHall
{
    class WeddingHall
    {
        static void Main()
        {
            decimal hallLenght = decimal.Parse(Console.ReadLine());
            decimal hallWidth = decimal.Parse(Console.ReadLine());
            decimal sideOfBar = decimal.Parse(Console.ReadLine());
            decimal guestCount;
            decimal hallArea = hallLenght * hallWidth;
            hallArea = (hallArea - (hallArea * 0.19m)) - (sideOfBar * sideOfBar);

            guestCount = hallArea / 3.2m;

            Console.WriteLine(Math.Ceiling(guestCount));            
        }
    }
}
