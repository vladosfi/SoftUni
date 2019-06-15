using System;

namespace GenericScale
{
    class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<int> equality = new EqualityScale<int>(5, 5);

            Console.WriteLine(equality.AreEqual());
        }
    }
}
