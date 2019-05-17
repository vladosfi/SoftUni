using System;

namespace _9.ConvertRadToDeg
{
    class ConvertRadToDeg
    {
        static void Main(string[] args)
        {
            double rad = double.Parse(Console.ReadLine());
            double deg = Math.Round((rad * 180) / Math.PI);

            Console.WriteLine($"Degrees = {deg}");
        }
    }
}
