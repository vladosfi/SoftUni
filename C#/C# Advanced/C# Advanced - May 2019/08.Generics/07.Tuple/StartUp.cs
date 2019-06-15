using System;
using System.Threading;

namespace GenericTuple
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            Tuple<string,string> tupleOne = new Tuple<string, string>();
            string[] tokens = Console.ReadLine().Split();
            tupleOne.item1 = tokens[0] + " " + tokens[1];
            tupleOne.item2 = tokens[2];
            Console.WriteLine($"{tupleOne.item1} -> {tupleOne.item2}");

            Tuple<string, int> tupleTwo = new Tuple<string, int>();
            tokens = Console.ReadLine().Split();
            tupleTwo.item1 = tokens[0];
            tupleTwo.item2 = int.Parse(tokens[1]);
            Console.WriteLine($"{tupleTwo.item1} -> {tupleTwo.item2}");

            Tuple<int, double> tupleThree = new Tuple<int, double>();
            tokens = Console.ReadLine().Split();
            tupleThree.item1 = int.Parse(tokens[0]);
            tupleThree.item2 = double.Parse(tokens[1]);
            Console.WriteLine($"{tupleThree.item1} -> {tupleThree.item2}");
        }
    }
}
