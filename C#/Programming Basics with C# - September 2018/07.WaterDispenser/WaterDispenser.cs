using System;

namespace _07.WaterDispenser
{
    class WaterDispenser
    {
        static void Main(string[] args)
        {
            int volume = int.Parse(Console.ReadLine());
            int pressCount = 0;
            int pressSum = 0;
            string pressType = "";

            while (pressSum < volume)
            {
                pressType = Console.ReadLine();

                if (pressType == "Easy")
                {
                    pressCount++;
                    pressSum = pressSum + 50;
                }
                else if (pressType == "Medium")
                {
                    pressCount++;
                    pressSum = pressSum + 100;
                }
                else if (pressType == "Hard")
                {
                    pressCount++;
                    pressSum = pressSum + 200;
                }
            }


            if (pressSum == volume)
            {
                Console.WriteLine($"The dispenser has been tapped {pressCount} times.");
            }
            else
            {
                Console.WriteLine($"{pressSum - volume}ml has been spilled.");
            }

        }
    }
}
