using System;
using System.Linq;

namespace _06.EqualSums
{
    class EqualSums
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string equalSums = "no";

            for (int i = 0; i < numbers.Length; i++)
            {
                int leftSum = 0;
                int rightSum = 0;
                
                // Get left Sum
                for (int j = i - 1; j >= 0; j--)
                {
                    leftSum += numbers[j];
                }

                // Get right Sum
                for (int j = i+1; j < numbers.Length; j++)
                {
                    rightSum += numbers[j];
                }

                if (leftSum == rightSum)
                {
                    equalSums = i.ToString();
                    break;
                }
            }

            Console.WriteLine(equalSums);
            

        }
    }
}
