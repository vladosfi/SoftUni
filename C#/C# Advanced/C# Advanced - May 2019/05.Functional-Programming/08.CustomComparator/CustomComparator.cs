using System;
using System.Linq;

namespace _08.CustomComparator
{
    class CustomComparator
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] evenNumbers = numbers.Where(n => n % 2 == 0).ToArray();
            int[] oddNumbers = numbers.Where(n => n % 2 != 0).ToArray();

            Func<int, int, int> sortArray = (a, b) => a.CompareTo(b);
            Action<int[], int[]> print = (a, b) => Console.WriteLine($"{string.Join(" ", a)} {string.Join(" ", b)}");

            Array.Sort(evenNumbers, new Comparison<int>(sortArray));
            Array.Sort(oddNumbers, new Comparison<int>(sortArray));

            print(evenNumbers, oddNumbers);
        }
    }
}
