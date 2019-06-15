using System;
using System.Collections.Generic;
using System.Threading;

namespace GenericCountMethodDouble
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            int n = int.Parse(Console.ReadLine());
            List<double> collenction = new List<double>();

            for (int i = 0; i < n; i++)
            {
                double element = double.Parse(Console.ReadLine());
                collenction.Add(element);
            }

            double elementToCompare = double.Parse(Console.ReadLine());

            Box box = new Box();

            Console.WriteLine(box.Compare(collenction, elementToCompare));
        }
    }
}
