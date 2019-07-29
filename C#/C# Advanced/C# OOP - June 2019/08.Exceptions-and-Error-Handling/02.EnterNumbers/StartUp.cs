using System;

namespace _02.EnterNumbers
{
    public class StartUp
    {
        static void Main()
        {
            int count = 0;

            while (true)
            {
                try
                {
                    Console.WriteLine(ReadNumber(1, 100));
                    count++;

                    if (count == 10)
                    {
                        break;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    count = 0;
                }
                catch (IndexOutOfRangeException iore){
                    Console.WriteLine(iore.Message);
                    count = 0;
                }
            }
        }

        private static int ReadNumber(int start, int end)
        {
            if (!int.TryParse(Console.ReadLine(), out int number))
            {
                throw new ArgumentException("Invalid number!");
            }
            else if (number < start || number > end)
            {
                throw new IndexOutOfRangeException($"Enter number between {start} and {end}!");
            }

            return number;
        }
    }
}
