using System;
using System.Linq;

namespace _03.CookingFactory
{
    class CookingFactory
    {
        static int bestTotalQuality = int.MinValue;
        static double bestAverageQuality = int.MinValue;
        static int bestLenght = int.MaxValue;
        static int[] bestBreadBatch;

        static void Main()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Bake It!")
                {
                    break;
                }

                int[] currentBreadBatch = input
                    .Split("#")
                    .Select(int.Parse)
                    .ToArray();

                int curTotalQuality = currentBreadBatch.Sum();
                double currentAverageQuality = currentBreadBatch.Average();
                int currentLenght = currentBreadBatch.Length;


                if ((curTotalQuality > bestTotalQuality)
                    || (bestTotalQuality == curTotalQuality && currentAverageQuality > bestAverageQuality)
                    || (bestTotalQuality == curTotalQuality && bestAverageQuality == currentAverageQuality && currentLenght < bestLenght))
                {
                    CopyBatch(curTotalQuality, currentAverageQuality, currentLenght, currentBreadBatch);
                }
            }

            Console.WriteLine($"Best Batch quality: {bestTotalQuality}");
            Console.WriteLine(string.Join(" ", bestBreadBatch));
        }

        private static void CopyBatch(int curTotalQuality, double currentAverageQuality, int currentLenght, int[] currentBreadBatch)
        {
            bestTotalQuality = curTotalQuality;
            bestAverageQuality = currentAverageQuality;
            bestLenght = currentLenght;
            bestBreadBatch = new int[currentLenght];

            for (int i = 0; i < currentLenght; i++)
            {
                bestBreadBatch[i] = currentBreadBatch[i];
            }
        }
    }
}
