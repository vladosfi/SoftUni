using System;
using System.Linq;

namespace _01.ActionPoint
{
    class ActionPoint
    {
        static void Main()
        {
            Action<string[]> printNames = names =>
                Console.WriteLine(string.Join(Environment.NewLine,names));

            string[] inputNames = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            printNames(inputNames);
        }
    }
}
