using System;

namespace FoodShortage
{
    public class ConsoleDataWriter : IDataWriter
    {
        public void Write(object obj)
        {
            Console.WriteLine(obj);
        }
    }
}
