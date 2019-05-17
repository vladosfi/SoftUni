using System;

namespace _12.EvenNumber
{
    class EvenNumber
    {
        static void Main()
        {
            while (true)
            {
                int evenNumber = int.Parse(Console.ReadLine());

                if (evenNumber % 2 == 0)
                {
                    Console.WriteLine($"The number is: {Math.Abs(evenNumber)}");
                    break;
                }
                else
                {
                    Console.WriteLine("Please write an even number.");
                }
            }
            
        }
    }
}
