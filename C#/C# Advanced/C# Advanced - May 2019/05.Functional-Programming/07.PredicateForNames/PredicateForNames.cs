using System;
using System.Linq;

namespace _07.PredicateForNames
{
    class PredicateForNames
    {
        static void Main()
        {
            Func<int, string, bool> NameFilter = (i, n) => (n.Length <= i);

            int namesCount = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(x=>NameFilter(namesCount,x))
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine,names));

        }
    }
}
