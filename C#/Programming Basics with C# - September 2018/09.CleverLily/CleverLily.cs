using System;

namespace _09.CleverLily
{
    class CleverLily
    {
        static void Main()
        {
            int age = int.Parse(Console.ReadLine());
            double washingMachine = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());
            bool odd = false;
            int moneyFromToy = 0;
            int moneyForEvenBD = 0;
            int evenCount = 0;
            int sumTotal = 0;

            for (int i = 1; i <= age; i++)
            {
                odd = !odd;

                if (odd)
                {
                    moneyFromToy = moneyFromToy + toyPrice;
                }
                else
                {
                    evenCount++;
                    moneyForEvenBD = moneyForEvenBD + ((10 * evenCount) - 1);
                }
            }

            sumTotal = moneyForEvenBD + moneyFromToy;

            if (sumTotal >= washingMachine)
            {
                Console.WriteLine($"Yes! {sumTotal - washingMachine:f02}");
            }
            else
            {
                Console.WriteLine($"No! {washingMachine - sumTotal:f02}");
            }
            
        }
    }
}
