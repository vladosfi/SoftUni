using System;

namespace _02.NumberPyramid
{
    class NumberPyramid
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 0;
            int row = 0;
            int col = 0;

            while (counter < n)
            {
                row++;
                col = 0;

                while (col < row && counter < n)
                {
                    col++;
                    counter++;
                    Console.Write($"{counter} ");
                }
                Console.WriteLine();
            }
        }
    }
}
