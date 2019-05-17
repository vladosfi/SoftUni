using System;

namespace _2.ConverInches
{
    class ConverInches
    {
        static void Main(string[] args)
        {
            double inches = double.Parse(Console.ReadLine());
            double santimeters = inches * 2.54;
            Console.WriteLine(santimeters);
        }
    }
}
