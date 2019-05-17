using System;

namespace _04.TailoringWorkshop
{
    class TailoringWorkshop
    {
        static void Main(string[] args)
        {
            int tables = int.Parse(Console.ReadLine());
            double lenght = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());

            double totalPrice = 0;
            double totalPriceInBgn = 0;
            double cursUsd = 1.85;
            int coverPrice = 7;
            int squarePrice = 9;
            double cover = tables * (lenght + (0.3 * 2)) * (width + (0.3 * 2));
            double square = tables * (lenght / 2) * (lenght / 2);


            cover = cover * coverPrice;
            square = square * squarePrice;
            totalPrice = cover + square;
            totalPriceInBgn = totalPrice * cursUsd;

            Console.WriteLine($"{totalPrice:F02} USD");
            Console.WriteLine($"{totalPriceInBgn:F02} BGN");



        }
    }
}
