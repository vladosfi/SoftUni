using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitDemo
{
    class Startup
    {
        static void Main()
        {
            PrintCount();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "exit")
                {
                    return;
                }
                else
                {
                    Console.WriteLine(line);
                }
            }
        }

        public static async void PrintCount()
        {
            var result = await NumberOfPrimesInIntervalAsync(2, 100000);
            Console.WriteLine(result);
        }

        private static Task<int> NumberOfPrimesInIntervalAsync(int min, int max)
        {
            return Task.Run(() => NumberOfPrimesInInterval(min, max));
        }

        private static int NumberOfPrimesInInterval(int min, int max)
        {
            int count = 0;

            for (int i = min; i <= max; i++)
            {
                bool isPrime = true;

                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
