using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _05.DrumSet
{
    class DrumSet
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            decimal savings = decimal.Parse(Console.ReadLine());
            List<int> initialDrumSet = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> drumSet = new List<int>();

            foreach (int set in initialDrumSet)
            {
                drumSet.Add(set);
            }
            

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Hit it again, Gabsy!")
                {
                    break;
                }

                int hitPower = int.Parse(input);

                for (int i = 0; i < drumSet.Count; i++)
                {
                    drumSet[i] -= hitPower;

                    if (drumSet[i] <= 0)
                    {
                        decimal newSetPrice = initialDrumSet[i] * 3;

                        if (newSetPrice <= savings)
                        {
                            savings -= newSetPrice;
                            drumSet[i] = initialDrumSet[i];
                        }
                        else
                        {
                            drumSet.RemoveAt(i);
                            initialDrumSet.RemoveAt(i);
                            i--;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", drumSet));
            Console.WriteLine($"Gabsy has {savings:f02}lv.");
        }
    }
}
