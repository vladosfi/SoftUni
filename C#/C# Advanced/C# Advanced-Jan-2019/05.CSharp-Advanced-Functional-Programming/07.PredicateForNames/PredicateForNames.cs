using System;
using System.Linq;

namespace _07.PredicateForNames
{
    class PredicateForNames
    {
        static void Main()
        {
            Func<string[], int, string[]> filterNames = (x,c) => x.Where(b => b.Length <= c).ToArray();
            Action<string[]> print = p => Console.WriteLine(string.Join(Environment.NewLine, p));

            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            names = filterNames(names, n);
            print(names);

        }
    }
}
