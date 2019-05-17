using System;

namespace _02.Cinema
{
    class Cinema
    {
        static void Main(string[] args)
        {
            string show = Console.ReadLine();
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());
            double totalSum = row * col;

            if (show == "Premiere")
            {
                totalSum = totalSum * 12.0;
            }
            else if (show == "Normal")
            {
                totalSum = totalSum * 7.50;
            }
            else if (show == "Discount")
            {
                totalSum = totalSum * 5.0;
            }

            Console.WriteLine($"{totalSum:f02} leva");
        }
    }
}
