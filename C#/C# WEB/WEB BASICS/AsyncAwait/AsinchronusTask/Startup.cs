using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsinchronusTask
{
    class Startup
    {
        static void Main()
        {
            Console.WriteLine("Starting");

            var worker = new Worker();
            worker.DoWork();

            while (!worker.IsComplete)
            {
                Console.Write(".");
                Thread.Sleep(100);
            }


            Console.WriteLine("Done");
        }
    }

    internal class Worker
    {
        public bool IsComplete { get; private set; }

        public async void DoWork()
        {
            IsComplete = false;
            Console.WriteLine("Doing work");

            await LongOperation();

            Console.WriteLine("Work completed");
            IsComplete = true;
        }        

        private Task LongOperation()
        {
            return Task.Run(() =>
            {
                Console.WriteLine("Working");
                Thread.Sleep(2000);
            });
        }
    }
}
