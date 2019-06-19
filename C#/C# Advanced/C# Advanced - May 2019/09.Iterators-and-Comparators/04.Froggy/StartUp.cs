using System;
using System.Linq;

namespace _04.Froggy
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] inputData = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Lake<int> lake = new Lake<int>(inputData);

            Console.WriteLine(string.Join(", ",lake));
        }
    }
}
