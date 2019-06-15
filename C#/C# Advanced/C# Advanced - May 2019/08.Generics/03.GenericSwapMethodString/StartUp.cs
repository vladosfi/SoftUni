using System;

namespace GenericSwapMethodString
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Generic<string> generic = new Generic<string>();

            for (int i = 0; i < n; i++)
            {
                generic.Add(Console.ReadLine());
            }

            string[] tokens = Console.ReadLine().Split();
            int indexOne = int.Parse(tokens[0]);
            int indexTwo = int.Parse(tokens[1]);

            generic.Swap(indexOne, indexTwo);
            generic.Print();
            
        }
    }
}
