using System;

namespace _07.MaxSequenceOfEqualElements
{
    class MaxSequenceOfEqualElements
    {
        static void Main()
        {
            string[] arrayOfNumbers = Console.ReadLine().Split();
            string[] maxSequence = new string[0];

            for (int i = arrayOfNumbers.Length - 1; i >= 0; i--)
            {
                int index = 0;
                string[] curArray = new string[] {arrayOfNumbers[i]};
                
                for (int j = i+1; j < arrayOfNumbers.Length; j++)
                {
                    if (arrayOfNumbers[i] == arrayOfNumbers[j])
                    {
                        index++;
                        string[] tempArray = curArray;
                        curArray = new string[index + 1];

                        for (int a = 0; a < tempArray.Length; a++)
                        {
                            curArray[a] = tempArray[a];
                        }

                        curArray[index] = arrayOfNumbers[j];
                    }
                    else
                    {
                        break;
                    }
                }

                if (curArray.Length >= maxSequence.Length)
                {
                    maxSequence = curArray;
                }
            }

            Console.WriteLine(string.Join(" ", maxSequence));
        }
    }
}
