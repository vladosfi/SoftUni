using System;

namespace _07.AlcoholMarket
{
    class AlcoholMarket
    {
        static void Main(string[] args)
        {
            double whiskyPrice = double.Parse(Console.ReadLine());
            double beerAmount = double.Parse(Console.ReadLine());
            double wineAmount = double.Parse(Console.ReadLine());
            double brandyAmount = double.Parse(Console.ReadLine());
            double whiskyAmount = double.Parse(Console.ReadLine());

            double brandyPrice = whiskyPrice / 2;
            double winePrice = brandyPrice - (brandyPrice * 0.4);
            double beerPrice = brandyPrice - (brandyPrice * 0.8);

            double sum = (whiskyPrice * whiskyAmount) + 
                (winePrice * wineAmount) +
                (brandyPrice * brandyAmount) +
                (beerPrice * beerAmount);
                

            Console.WriteLine($"{sum:F02}");


        }
    }
}
