using System;

namespace LoggerTask
{
    public class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Icollection
            Engine engin = new Engine();
            engin.Run();
        }
    }
}
