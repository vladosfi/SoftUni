using System;
using System.Threading;

namespace _07.Tuple
{
    class StartUp
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            string[] line = Console.ReadLine().Split();
            string fullName = line[0] + " " + line[1];
            string address = line[2];
            Tuple<string, string> firstTuple = new Tuple<string, string>(fullName, address);

            line = Console.ReadLine().Split();
            string name = line[0];
            int leters = int.Parse(line[1]);
            Tuple<string, int> secondTuple = new Tuple<string, int>(name, leters);

            line = Console.ReadLine().Split();
            int num1 = int.Parse(line[0]);
            double num2 = double.Parse(line[1]);
            Tuple<int, double> thirdTuple = new Tuple<int, double>(num1, num2);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
