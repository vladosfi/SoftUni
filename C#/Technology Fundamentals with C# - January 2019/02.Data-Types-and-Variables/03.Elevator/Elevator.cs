using System;

namespace _03.Elevator
{
    class Elevator
    {
        static void Main()
        {
            double n = double.Parse(Console.ReadLine());
            double p = double.Parse(Console.ReadLine());

            Console.WriteLine(Math.Ceiling(n/p));
        }
    }
}
