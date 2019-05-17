using System;
using System.Threading;

namespace _08.BeerKegs
{
    class BeerKegs
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string maxModel = null;
            double maxVolume = 0;

            for (int i = 0; i < n; i++)
            {
                Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
                string curModel = Console.ReadLine();
                double curRadius = double.Parse(Console.ReadLine());
                int curHeight = int.Parse(Console.ReadLine());
                double curVolume = Math.PI * (curRadius * curRadius) * curHeight;

                if (maxVolume < curVolume)
                {
                    maxVolume = curVolume;
                    maxModel = curModel;
                }
            }

            Console.WriteLine($"{maxModel}");

        }
    }
}
