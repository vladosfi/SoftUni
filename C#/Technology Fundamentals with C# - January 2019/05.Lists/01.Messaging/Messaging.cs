using System;
using System.Collections.Generic;
using System.Linq;

namespace Lists___More_Exercise
{
    class Program
    {
        static void Main()
        {
            List<string> numbers = Console.ReadLine().Split().ToList();
            string text = Console.ReadLine();
            string extractedChars = string.Empty;

            foreach (string number in numbers)
            {
                int sumOfDigits = 0;
                foreach (char character in number)
                {
                    sumOfDigits += character - '0';
                }

                if (sumOfDigits > text.Length)
                {
                    sumOfDigits = sumOfDigits % text.Length;
                }

                extractedChars += text[sumOfDigits];
                text = text.Remove(sumOfDigits, 1);
            }

            
            Console.WriteLine(extractedChars);
        }
    }
}
