using System;
using System.Threading;

namespace Problem1
{
    class Program
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            decimal budget = decimal.Parse(Console.ReadLine());
            decimal floorForOne = decimal.Parse(Console.ReadLine());
            int countOfCozonacs = 0;
            int coloredEggs = 0;            
            
            decimal eggsPrice = floorForOne * 0.75m;
            decimal milkPerLiterPrice = floorForOne * 1.25m;

            while (true)
            {
                decimal spentForCozonac = floorForOne + eggsPrice + (milkPerLiterPrice / 4);
                
                if (budget - spentForCozonac <= 0)
                {
                    break; 
                }

                budget -= spentForCozonac;
                countOfCozonacs++;
                coloredEggs += 3;

                if (countOfCozonacs % 3 == 0)
                {
                    coloredEggs -= countOfCozonacs - 2;
                }
            }

            Console.WriteLine($"You made {countOfCozonacs} cozonacs! Now you have {coloredEggs} eggs and {budget:f02}BGN left.");
        }
    }
}
