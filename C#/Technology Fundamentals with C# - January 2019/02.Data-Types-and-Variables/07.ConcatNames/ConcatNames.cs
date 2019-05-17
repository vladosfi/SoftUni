using System;

namespace _07.ConcatNames
{
    class ConcatNames
    {
        static void Main()
        {
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            string delimiter = Console.ReadLine();

            Console.WriteLine(firstName + delimiter + lastName);
        }
    }
}
