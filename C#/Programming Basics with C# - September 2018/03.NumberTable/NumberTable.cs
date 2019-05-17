using System;

namespace _03.NumberTable
{
    class NumberTable
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 0;
            bool backward = false;

            for (int row = 1; row <= n; row++)
            {
                backward = false;
                for (int col = 1; col <= n; col++)
                {
                    if (counter == n)
                    {
                        backward = true;
                    }

                    if (backward)
                    {
                        counter--;
                    }
                    else
                    {
                        counter++;
                    }
                    Console.Write($"{counter} ");
                }
                counter = row;
                Console.WriteLine();
            }
        }
    }
}
