using System;
using System.Threading;

namespace _08.Threeuple
{
    class StartUp
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            string[] line = Console.ReadLine().Split();
            string fullName = line[0] + " " + line[1];
            string address = line[2];
            string city = line[3];
            Threeuple<string, string, string> firstTuple = new Threeuple<string, string, string>(fullName, address, city);

            line = Console.ReadLine().Split();
            string name = line[0];
            int leters = int.Parse(line[1]);
            bool drunk = line[2] == "drunk" ? true : false;
            Threeuple<string, int, bool> secondTuple = new Threeuple<string, int, bool>(name, leters, drunk);

            line = Console.ReadLine().Split();
            name = line[0];
            double num = double.Parse(line[1]);
            string bankName = line[2];
            Threeuple<string, double, string> thirdTuple = new Threeuple<string, double, string>(name, num, bankName);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
