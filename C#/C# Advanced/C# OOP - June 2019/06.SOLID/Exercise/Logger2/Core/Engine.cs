using Logger2.Core.Contracts;
using System;

namespace Logger2.Core
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
            int appendersCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < appendersCount; i++)
            {
                string[] appenderArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                this.commandInterpreter.AddAppender(appenderArgs);
            }


            string inputReport = Console.ReadLine();

            while (inputReport != "END")
            {
                string[] reportArgs = inputReport.Split("|", StringSplitOptions.RemoveEmptyEntries);

                this.commandInterpreter.AddReport(reportArgs);

                inputReport = Console.ReadLine();
            }

            this.commandInterpreter.PrintInfo();
        }
    }
}
