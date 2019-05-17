using System;
using System.Threading;

namespace _09.PadawanEquipment
{
    class PadawanEquipment
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            decimal amountOfMoney = decimal.Parse(Console.ReadLine());
            int countOfStudents = int.Parse(Console.ReadLine());

            decimal priceOfLightsabers = decimal.Parse(Console.ReadLine());
            priceOfLightsabers = priceOfLightsabers * Math.Ceiling(countOfStudents * 1.1m);
            decimal priceOfRobes = decimal.Parse(Console.ReadLine()) * countOfStudents;
            decimal priceOfBelts = decimal.Parse(Console.ReadLine());
            priceOfBelts = priceOfBelts * (countOfStudents - Math.Floor(countOfStudents / 6m));
            decimal costOfTheEquipment = 0;


            costOfTheEquipment = priceOfLightsabers + priceOfRobes + priceOfBelts;

            if (amountOfMoney >= costOfTheEquipment)
            {
                Console.WriteLine($"The money is enough - it would cost {costOfTheEquipment:F02}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {costOfTheEquipment - amountOfMoney:F02}lv more.");
            }


        }
    }
}
