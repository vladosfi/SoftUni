using System;

namespace _8.ConvertCelsiusToFahrenheit
{
    class ConvertCelsiusToFahrenheit
    {
        static void Main(string[] args)
        {
            double celsius = double.Parse(Console.ReadLine());
            double fahrenheit = Math.Round((celsius * 1.8) + 32,2);

            Console.WriteLine($"Fahrenheit = {fahrenheit}");
        }
    }
}
