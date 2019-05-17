using System;

namespace _01.SeaTrip
{
    class SeaTrip
    {
        static void Main()
        {

            double moneyForFood = double.Parse(Console.ReadLine());
            double moneyForSouvenirs = double.Parse(Console.ReadLine());
            double moneyForHotel = double.Parse(Console.ReadLine());
            double transport = (((210 * 2.0) * 7) / 100) * 1.85;
            double dayExpense = (moneyForFood + moneyForSouvenirs) * 3;
            double hotelExpense = (moneyForHotel * 0.9) + (moneyForHotel * 0.85) + (moneyForHotel * 0.80);
            double totalSum = transport + dayExpense + hotelExpense;

            Console.WriteLine($"Money needed: {totalSum:F02}");


            //double moneyForFood = double.Parse(Console.ReadLine());
            //double moneyForSouvenirs = double.Parse(Console.ReadLine());
            //double moneyForHotel = double.Parse(Console.ReadLine());
            //double totalMoney = 0;
            //double moneyForTransport = (420.0 / 100 * 7) * 1.85;
            //double moneyForStay = (3 * moneyForFood) + (3 * moneyForSouvenirs);
            //totalMoney = (moneyForHotel * 0.9) + (moneyForHotel * 0.85) + (moneyForHotel * 0.8) + moneyForTransport + moneyForStay;
            //Console.WriteLine($"Money needed: {totalMoney:F02}");
        }
    }
}
