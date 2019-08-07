namespace PlayersAndMonsters.IO
{
    using System;
    using PlayersAndMonsters.IO.Contracts;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
