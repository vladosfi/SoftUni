using System;

namespace _06.CharityCampaign
{
    class CharityCampaign
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int confectioner = int.Parse(Console.ReadLine());
            int cakes = int.Parse(Console.ReadLine());
            int wafers = int.Parse(Console.ReadLine());
            int pancakes = int.Parse(Console.ReadLine());
            double expense;
            double sum = (days * confectioner) * ((cakes * 45) + (wafers * 5.80) + (pancakes * 3.20));
            expense = sum / 8;
            sum = sum - expense;

            Console.WriteLine($"{sum:F02}");

        }
    }
}
