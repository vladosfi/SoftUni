using System;

namespace GenericBoxofInteger
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Box<int> currentBox = new Box<int>(int.Parse(Console.ReadLine()));
                Console.WriteLine(currentBox.ToString());
            }
        }
    }
}
