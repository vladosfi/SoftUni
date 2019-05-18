using System;
using System.Collections.Generic;
using System.Linq;

namespace _13.TriFunction
{
    class TriFunction
    {
        static void Main()
        {
            int sum = int.Parse(Console.ReadLine());
            List<string> pNames = Console.ReadLine().Split().ToList();

            Func<string, int, bool> isEqualSum = (name, s) => name.Sum(x => x) >= s;

            Func<List<string>, Func<string, int, bool>, string> getName = (names, isEqualSumAscii) =>
                             names.FirstOrDefault(x => isEqualSumAscii(x, sum));

            Console.WriteLine(getName(pNames, isEqualSum));

        }
    }
}
