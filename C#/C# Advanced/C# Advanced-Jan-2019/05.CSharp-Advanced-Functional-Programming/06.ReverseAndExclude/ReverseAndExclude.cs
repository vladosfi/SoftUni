using System;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class ReverseAndExclude
    {
        static void Main()
        {
            Func<int[], int[]> reversFunc = nums => nums.Reverse().ToArray();
            Func<int[], int, int[]> removeFunc = (nums, n) => nums.Where(x => x % n != 0).ToArray();
            Action<int[]> print = nums => Console.WriteLine(string.Join(" ", nums));

            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int divNumber = int.Parse(Console.ReadLine());

            numbers = reversFunc(numbers);
            numbers = removeFunc(numbers,divNumber);
            print(numbers);

            //numbers.Where(x => x % n != 0).Reverse().ToList().ForEach(x => Console.Write(x + " "));
            //Console.WriteLine();
        }
    }
}
