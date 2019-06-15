using System;

namespace GenericSwapMethodInteger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Generic<int> generic = new Generic<int>();

            for (int i = 0; i < n; i++)
            {
                generic.Add(int.Parse(Console.ReadLine()));
            }

            string[] tokens = Console.ReadLine().Split();
            int indexOne = int.Parse(tokens[0]);
            int indexTwo = int.Parse(tokens[1]);

            generic.Swap(indexOne, indexTwo);
            generic.Print();


        }
    }
}
