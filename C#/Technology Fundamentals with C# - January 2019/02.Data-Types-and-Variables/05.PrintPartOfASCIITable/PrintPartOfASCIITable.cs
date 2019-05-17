using System;

namespace _05.PrintPartOfASCIITable
{
    class PrintPartOfASCIITable
    {
        static void Main()
        {
            int startChar = int.Parse(Console.ReadLine());
            int endChar = int.Parse(Console.ReadLine());

            for (char i = (char)startChar; i <= endChar; i++)
            {
                Console.Write($"{i} ");
            }
        }
    }
}
