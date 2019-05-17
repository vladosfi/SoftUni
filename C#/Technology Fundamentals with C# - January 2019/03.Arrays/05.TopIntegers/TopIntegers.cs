using System;
using System.Linq;

namespace _05.TopIntegers
{
    class TopIntegers
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] topIntegers = new int[0];

            for (int i = 0; i < numbers.Length; i++)
            {
                bool isTopInt = true;

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] <= numbers[j])
                    {
                        isTopInt = false;
                        break;
                    }
                }

                if (isTopInt)
                {
                    int[] tempArray = topIntegers;
                    topIntegers = new int[topIntegers.Length + 1];

                    for (int j = 0; j < tempArray.Length; j++)
                    {
                        topIntegers[j] = tempArray[j];
                    }

                    topIntegers[topIntegers.Length - 1] = numbers[i];
                }
            }

            Console.WriteLine(string.Join(" ",topIntegers));

        }
    }
}
