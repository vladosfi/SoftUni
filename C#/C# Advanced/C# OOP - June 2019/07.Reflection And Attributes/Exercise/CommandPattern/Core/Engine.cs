using CommandPattern.Core.Contracts;
using System;

namespace CommandPattern.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            string commandLine = Console.ReadLine();

            while (commandLine != "Exit")
            {
                string result = this.commandInterpreter.Read(commandLine);
                Console.WriteLine(result);

                commandLine = Console.ReadLine();
            }
            
        }
    }
}
