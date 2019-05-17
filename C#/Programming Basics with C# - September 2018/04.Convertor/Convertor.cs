using System;

namespace _04.Convertor
{
    class Convertor
    {
        static void Main(string[] args)
        {
            double unit = double.Parse(Console.ReadLine());
            string inputUnit = Console.ReadLine();
            string outputUnit = Console.ReadLine();
            double meters = unit;

            // Convert all to meters 
            if (inputUnit != "m")
            {
                meters = ConvertToMeters(unit, inputUnit);
            }

            // Convert to output unit
            unit = ConvertToOutputUnits(meters, outputUnit);
            Console.WriteLine($"{unit:F08}"); 

        }

        static double ConvertToOutputUnits(double unit, string outputUnit)
        {
            switch (outputUnit)
            {
                case "m":
                    break;
                case "mm":
                    unit = unit * 1000;
                    break;
                case "cm":
                    unit = unit * 100;
                    break;
                case "mi":
                    unit = unit / 1609.344;
                    break;
                case "in":
                    unit = unit * 39.3700787;
                    break;
                case "km":
                    unit = unit / 1000;
                    break;
                case "ft":
                    unit = unit * 3.2808399;
                    break;
                case "yd":
                    unit = unit * 1.0936133;
                    break;
                default:
                    unit = 0;
                    Console.WriteLine("Invalid output unit!");
                    break;
            }
            return unit;

        }


        static double ConvertToMeters(double unit, string inputUnit)
        {  
            switch (inputUnit)
            {
                case "mm":
                    unit = unit / 1000;
                    break;
                case "cm":
                    unit = unit / 100;
                    break;
                case "mi":
                    unit = unit * 1609.344;
                    break;
                case "in":
                    unit = unit / 39.3700787;
                    break;
                case "km":
                    unit = unit * 1000;
                    break;
                case "ft":
                    unit = unit / 3.2808399;
                    break;
                case "yd":
                    unit = unit / 1.0936133;
                    break;
                default:
                    unit = 0;
                    Console.WriteLine("Invalid input unit!");
                    break;
            }
            return unit;
        }
    }
}
