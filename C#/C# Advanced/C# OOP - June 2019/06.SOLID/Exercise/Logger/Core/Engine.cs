using System;
using System.Linq;
using LoggerTask.Contracts;
using LoggerTask.Factories;
using LoggerTask.Models.Contracts;

namespace LoggerTask.Core
{
    public class Engine
    {
        private readonly ILogger logger;
        private readonly ErrorFactory errorFactory;

        private Engine()
        {
            errorFactory = new ErrorFactory();
        }

        public Engine(ILogger logger)
            :this()
        {
            this.logger = logger;
        }

        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] errorArgs = command
                    .Split("|")
                    .ToArray();

                string level = errorArgs[0];
                string date = errorArgs[1];
                string message = errorArgs[2];

                IError error;

                try
                {
                    error = this.errorFactory.GetError(date, level, message);
                    this.logger.Log(error);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(this.logger.ToString());
        }

    }
}
