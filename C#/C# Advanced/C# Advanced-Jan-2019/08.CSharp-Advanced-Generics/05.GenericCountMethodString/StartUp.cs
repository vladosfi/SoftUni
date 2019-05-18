using System;
using System.Collections.Generic;

namespace _05.GenericCountMethodString
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> elements = new List<string>();

            for (int i = 0; i < n; i++)
            {
                elements.Add(Console.ReadLine());
            }

            var elementToCompare = Console.ReadLine();

            Console.WriteLine(Box.Compare(elements, elementToCompare));

        }
    }
}
