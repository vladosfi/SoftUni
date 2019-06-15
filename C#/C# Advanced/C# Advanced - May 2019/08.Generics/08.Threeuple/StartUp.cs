using System;
using System.Threading;

namespace Threeuples
{
    class StartUp
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            Threeuple<string, string, string> tupleOne = new Threeuple<string, string, string>();
            string[] tokens = Console.ReadLine().Split();
            tupleOne.item1 = tokens[0] + " " + tokens[1];
            tupleOne.item2 = tokens[2];
            tupleOne.item3 = tokens[3];
            for (int i = 4; i < tokens.Length; i++)
            {
                tupleOne.item3 += " " + tokens[i];
            }
            Console.WriteLine($"{tupleOne.item1} -> {tupleOne.item2} -> {tupleOne.item3}");

            Threeuple<string, int, bool> tupleTwo = new Threeuple<string, int, bool>();
            tokens = Console.ReadLine().Split();
            tupleTwo.item1 = tokens[0];
            tupleTwo.item2 = int.Parse(tokens[1]);
            tupleTwo.item3 = tokens[2] == "drunk" ? true : false;
            Console.WriteLine($"{tupleTwo.item1} -> {tupleTwo.item2} -> {tupleTwo.item3}");

            Threeuple<string, double, string> tupleThree = new Threeuple<string, double, string>();
            tokens = Console.ReadLine().Split();
            tupleThree.item1 = tokens[0];
            tupleThree.item2 = double.Parse(tokens[1]);
            tupleThree.item3 = tokens[2];
            Console.WriteLine($"{tupleThree.item1} -> {tupleThree.item2} -> {tupleThree.item3}");
        }
    }
}
