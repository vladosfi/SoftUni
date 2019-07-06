using System;

namespace P01_RawData
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            Engine engine = new Engine(Console.ReadLine, Console.WriteLine);
            engine.Run();
        }
    }
}
