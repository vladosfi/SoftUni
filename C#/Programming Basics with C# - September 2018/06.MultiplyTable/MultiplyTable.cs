using System;

namespace _06.MultiplyTable
{
    class MultiplyTable
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            int first = number % 10;
            number = number / 10;
            int second = number % 10;
            number = number / 10;
            int third = number;

            for (int a = 1; a <= first; a++)
            {
                for (int b = 1; b <= second; b++)
                {
                    for (int c = 1; c <= third; c++)
                    {
                        Console.WriteLine(a + " * " + b + " * " + c + " = " + (a*b*c) + ";");
                    }
                }
            }
        }
    }
}
