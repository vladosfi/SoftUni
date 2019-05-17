using System;

namespace _03.Volleyball
{
    class Volleyball
    {
        static void Main(string[] args)
        {
            string year = Console.ReadLine();
            int p = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());

            double volleyballDays = (48 - h);
            volleyballDays = (volleyballDays * (3 / 4.0)) + (p * (2 / 3.0));

            if (year == "leap")
            {
                volleyballDays = Math.Floor((volleyballDays + h) * 1.15);
            }
            else
            {
                volleyballDays = Math.Floor((volleyballDays + h));
            }

            Console.WriteLine($"{volleyballDays}");
        }
    }
}
