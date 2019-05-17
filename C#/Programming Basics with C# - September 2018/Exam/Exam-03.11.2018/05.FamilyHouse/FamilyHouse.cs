using System;

namespace _05.FamilyHouse
{
    class FamilyHouse
    {
        static void Main()
        {
            int months = int.Parse(Console.ReadLine());
            double electricity = 0;
            double electricitySum = 0;
            double waterSum = 0;
            double internetSum = 0;
            double otherSum = 0;


            for (int i = 0; i < months; i++)
            {
                electricity = double.Parse(Console.ReadLine());
                electricitySum = electricitySum + electricity;
                waterSum = waterSum + 20;
                internetSum = internetSum + 15;
                otherSum = otherSum + ((electricity + 20 + 15) * 1.2);
            }

            Console.WriteLine($"Electricity: {electricitySum:f02} lv");
            Console.WriteLine($"Water: {waterSum:f02} lv");
            Console.WriteLine($"Internet: {internetSum:f02} lv");
            Console.WriteLine($"Other: {otherSum:f02} lv");
            Console.WriteLine($"Average: {(electricitySum + waterSum + internetSum + otherSum) / months:f02} lv");
        }
    }
}
