using System;
using System.Linq;

namespace _08.CondenseArrayToNumber
{
    class CondenseArrayToNumber
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            while (numbers.Length > 1)
            {
                int[] condensedArray = new int[numbers.Length - 1];

                for (int i = 0; i < condensedArray.Length; i++)
                {
                    condensedArray[i] = numbers[i] + numbers[i + 1];
                }

                numbers = condensedArray;
            }

            foreach (var element in numbers)
            {
                Console.WriteLine(element);
            }
        }
    }
}
