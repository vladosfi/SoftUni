using System;
using System.Linq;

namespace _01._Reverse_Array
{
    class ReverseArray
    {
        static void Main()
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int counter = -1; 
            int mid = (array.Length / 2);
            ReverceArray(array, counter, mid);

            Console.WriteLine(string.Join(" ", array));

        }

        private static void ReverceArray(int[] array, int counter, int mid)
        {
            counter++;

            if (counter == mid)
            {
                return;
            }

            int tempVal = array[counter];
            array[counter] = array[array.Length - 1 - counter];
            array[array.Length - 1 - counter] = tempVal;

            ReverceArray(array, counter, mid);
        }
    }
}
