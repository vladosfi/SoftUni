using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _02.SeizeTheFire
{
    class SeizeTheFire
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            string[] firesAndCells = Console.ReadLine().Split("#");
            int water = int.Parse(Console.ReadLine());
            double effort = 0;
            List<int> totalFire = new List<int>();

            
            for (int i = 0; i < firesAndCells.Length; i++)
            {
                if (water <= 0)
                {
                    break;
                }

                string[] tokens = firesAndCells[i].Split(" = ");

                string typeOfFire = tokens[0];
                int valueOfCell = int.Parse(tokens[1]);
                
                if (typeOfFire == "High" && valueOfCell >= 81 && valueOfCell <= 125
                    || typeOfFire == "Medium" && valueOfCell >= 51 && valueOfCell <= 80
                    || typeOfFire == "Low" && valueOfCell >= 1 && valueOfCell <= 50)
                {
                    if (water - valueOfCell >= 0)
                    {
                        water -= valueOfCell;
                        effort += valueOfCell * 0.25;
                        totalFire.Add(valueOfCell);
                    }
                }


                
            }

            Console.WriteLine("Cells:");
            if (totalFire.Any())
            {
                Console.Write(" - ");
                Console.WriteLine(string.Join(Environment.NewLine + " - ", totalFire));
            }            

            Console.WriteLine($"Effort: {effort:F02}");
            Console.WriteLine($"Total Fire: {totalFire.Sum()}");
        }
    }
}
