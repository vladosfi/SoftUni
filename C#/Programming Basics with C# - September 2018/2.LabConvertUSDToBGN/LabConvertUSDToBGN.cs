using System;

namespace _2.LabConvertUSDToBGN
{
    class LabConvertUSDToBGN
    {
        static void Main()
        {
            double dolars = double.Parse(Console.ReadLine());
            double lev = dolars * 1.79549;

            Console.WriteLine($"{lev:F02}");
        }
    }
}
