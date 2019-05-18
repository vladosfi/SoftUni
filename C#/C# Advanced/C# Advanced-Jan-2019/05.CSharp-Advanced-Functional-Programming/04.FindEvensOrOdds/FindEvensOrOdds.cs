using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    class FindEvensOrOdds
    {

        static void Main()
        {
            List<int> boundaries = Console.ReadLine()
                           .Split()
                           .Select(int.Parse)
                           .ToList();

            string command = Console.ReadLine();
            int down = boundaries[0];
            int upper = boundaries[1];

            Func<int, string, bool> printNumbers = getNumbers;

            for (int i = down; i <= upper; i++)
            {
                if (getNumbers(i, command))
                {
                    Console.Write($"{i} ");
                }
            }
        }

        public static bool getNumbers(int n, string command)
        {
            if (command == "even")
            {
                return n % 2 == 0;
            }
            else
            {
                return n % 2 != 0;
            }
        }
    }
}
