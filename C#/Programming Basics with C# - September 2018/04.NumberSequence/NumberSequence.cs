using System;

namespace _04.NumberSequence
{
    class NumberSequence
    {
        static void Main(string[] args)
        {
            int number = 0;
            int min = int.MaxValue;
            int max = int.MinValue;
            string inputVal = "";


            while (inputVal != "END")
            {
                inputVal = Console.ReadLine();
                if (int.TryParse(inputVal, out number))
                {
                    if (min > number)
                    {
                        min = number;
                    }

                    if(max < number)
                    {
                        max = number;
                    }
                }
            }

            Console.WriteLine($"Max number: {max}");
            Console.WriteLine($"Min number: {min}");
        }
    }
}
