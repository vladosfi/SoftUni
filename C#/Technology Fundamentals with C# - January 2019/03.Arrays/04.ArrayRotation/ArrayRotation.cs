using System;

namespace _04.ArrayRotation
{
    class ArrayRotation
    {
        static void Main()
        {
            string[] numbers = Console.ReadLine().Split();
            int rotations = int.Parse(Console.ReadLine());

            if (rotations > numbers.Length)
            {
                rotations = rotations % numbers.Length;
            }

            for (int i = 0; i < rotations; i++)
            {
                string[] tempArr = new string[numbers.Length];

                for (int j = 0; j < numbers.Length - 1; j++)
                {
                    tempArr[j] = numbers[j+1];
                }

                tempArr[tempArr.Length-1] = numbers[0];
                numbers = tempArr;
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
