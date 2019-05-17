using System;
using System.Linq;

namespace _09.KaminoFactory
{
    class KaminoFactory
    {
        static void Main()
        {

            int lenghtOfSequence = int.Parse(Console.ReadLine());
            int bestSquenceLenght = 0;
            int bestIndex = 1;
            int bestSequenceSum = 0;
            string inputSequence = null;
            string maxSequence = null;
            int bestSequenceIndex = 0;
            int currentSequenceIndex = 0;

            while ((inputSequence = Console.ReadLine()) != "Clone them!")
            {
                string currentSequence = null;
                int currentSum = 0;
                int currentSequenceLenght = 0;
                int nextSequenceLenght = 0;
                int currentBestIndex = 0;
                int nextLeftmostIndex = 0;
                int[] dnaSquence = inputSequence
                    .Split("!", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                currentSequence = string.Join(" ", dnaSquence);
                currentSequenceIndex++;

                for (int i = 0; i < dnaSquence.Length; i++)
                {
                    if (dnaSquence[i] == 1)
                    {
                        int dnaElement = i;
                        nextLeftmostIndex = i;

                        while (dnaElement < lenghtOfSequence && dnaSquence[dnaElement] == 1)
                        {
                            currentSum++;
                            nextSequenceLenght++;
                            dnaElement++;
                        }
                        i = dnaElement - 1;
                    }

                    if (nextSequenceLenght > currentSequenceLenght)
                    {
                        currentSequenceLenght = nextSequenceLenght;
                        currentBestIndex = nextLeftmostIndex;

                        nextSequenceLenght = 0;
                        nextLeftmostIndex = 0;
                    }
                }

                if (currentSequenceLenght > bestSquenceLenght
                    || currentSequenceLenght == bestSquenceLenght && bestIndex > currentBestIndex
                    || currentSequenceLenght == bestSquenceLenght && bestIndex == currentBestIndex && bestSequenceSum < currentSum)
                {
                    bestSquenceLenght = currentSequenceLenght;
                    maxSequence = currentSequence;
                    bestIndex = currentBestIndex;
                    bestSequenceSum = currentSum;
                    bestSequenceIndex = currentSequenceIndex;
                }
            }

            Print(bestSequenceIndex, bestSequenceSum, maxSequence);

        }

        static void Print(int maxLeftmostIndex, int maxSum, string maxSequence)
        {
            Console.WriteLine($"Best DNA sample {maxLeftmostIndex} with sum: {maxSum}.");
            Console.WriteLine(maxSequence);
        }
    }
}

