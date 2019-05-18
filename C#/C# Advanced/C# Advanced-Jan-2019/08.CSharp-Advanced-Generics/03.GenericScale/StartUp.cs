using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main()
        {
            var scale1 = new EqualityScale<int>(10, 10);
            Console.WriteLine(scale1.AreEqual());

            var scale2 = new EqualityScale<string>("Two23", "Onqe");
            Console.WriteLine(scale2.AreEqual());
        }
    }
}
