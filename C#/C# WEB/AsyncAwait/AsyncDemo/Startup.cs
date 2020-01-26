using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncDemo
{
    class Startup
    {
        static void Main()
        {
            
            var number = Task.Run(() => NumberOfPrimesInInterval(2, 100000));
            number.ContinueWith((task) => Console.WriteLine(task.Result + " comes from thread #" + Thread.CurrentThread.ManagedThreadId));
            
            //Wait task to complete
            //number.Wait();


            Console.WriteLine("Main thread #"+ Thread.CurrentThread.ManagedThreadId);

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
