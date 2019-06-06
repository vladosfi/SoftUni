using System;
using System.Linq;

namespace _13.TriFunction
{
    class TriFunction
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            Func<string, int, bool> isLarger = (string name, int length)
                => name.Sum(c => c) >= length;

            Func<string[], Func<string, int, bool>, string> nameFilter =
                (inputNames, isLargerFilter) 
                => inputNames.FirstOrDefault(x => isLargerFilter(x,n));

            string resultName = nameFilter(names, isLarger);

            Console.WriteLine(resultName);
        }
    }
}
