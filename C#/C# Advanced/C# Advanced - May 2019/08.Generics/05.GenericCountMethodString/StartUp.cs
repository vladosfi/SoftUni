using System;
using System.Collections.Generic;

namespace GenericCountMethodString
{
    class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<string> collenction = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string element = Console.ReadLine();
                collenction.Add(element);
            }

            string elementToCompare = Console.ReadLine();

            Box box = new Box();

            Console.WriteLine(box.Compare(collenction,elementToCompare));

        }
    }
}
