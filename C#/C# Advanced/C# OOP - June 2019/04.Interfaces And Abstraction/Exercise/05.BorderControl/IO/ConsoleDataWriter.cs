using System;

namespace BirthdayCelebrations
{
    public class ConsoleDataWriter : IDataWriter
    {
        public void Write(object obj)
        {
            Console.WriteLine(obj);
        }
    }
}
