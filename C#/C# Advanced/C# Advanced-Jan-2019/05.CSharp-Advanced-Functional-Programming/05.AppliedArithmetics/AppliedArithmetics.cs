using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class AppliedArithmetics
    {
        static void Main()
        {
            int[] numbers =
                Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Func<int[], int[]> addOneFunc = nums => nums.Select(x => x + 1).ToArray();
            Func<int[], int[]> subtractOneFunc = nums => nums.Select(x => x - 1).ToArray();
            Func<int[], int[]> multiplyByTwoFunc = nums => nums.Select(x => x * 2).ToArray();
            Action<int[]> print = nums => Console.WriteLine(string.Join(" ", nums));

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                if (command == "add" )
                {
                    //Calc(numbers, Add);
                    numbers = addOneFunc(numbers);
                }
                else if (command == "subtract")
                {
                    //Calc(numbers, Subtract);
                    numbers = subtractOneFunc(numbers);
                }
                else if (command == "multiply")
                {
                    //Calc(numbers, Multiply);
                    numbers = multiplyByTwoFunc(numbers);
                }
                else if (command == "print")
                {
                    //Calc(numbers, Print);
                    //numbers.ForEach( n => Console.Write(n + " "));
                    //Console.WriteLine();
                    print(numbers);
                }

            }
        }

        //public static void Calc(List<int> n, Action<List<int>> opr)
        //{
        //    opr(n);
        //}

        //public static void Add(List<int> n)
        //{
        //    for (int i = 0; i < n.Count; i++)
        //    {
        //        n[i] += 1;
        //    }
        //}

        //public static void Subtract(List<int> n)
        //{
        //    for (int i = 0; i < n.Count; i++)
        //    {
        //        n[i] -= 1;
        //    }
        //}

        //public static void Multiply(List<int> n)
        //{
        //    for (int i = 0; i < n.Count; i++)
        //    {
        //        n[i] *= 2;
        //    }
        //}

        //public static void Print(List<int> n)
        //{
        //    for (int i = 0; i < n.Count; i++)
        //    {
        //        Console.Write(n[i]  + " ");
        //    }
        //    Console.WriteLine();
        //}
    }
}
