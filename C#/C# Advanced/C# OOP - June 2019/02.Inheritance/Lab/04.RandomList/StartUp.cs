using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main()
        {
            RandomList randList = new RandomList();

            randList.Add("A");
            randList.Add("B");
            randList.Add("C");

            randList.RandomString();

            foreach (var element in randList)
            {
                Console.WriteLine(element);
            }
        }
    }
}
