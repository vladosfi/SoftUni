using System;

namespace _01.IntegerOperations
{
    class IntegerOperations
    {
        static void Main()
        {
            long firstNumber = int.Parse(Console.ReadLine());
            long secondNumber = int.Parse(Console.ReadLine());
            long thirdNumber = int.Parse(Console.ReadLine());
            long fourthNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(((firstNumber + secondNumber) / thirdNumber) * fourthNumber);
        }
    }
}
