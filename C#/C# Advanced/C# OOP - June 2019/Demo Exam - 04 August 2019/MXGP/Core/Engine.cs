namespace MXGP.Core
{
    using System;
    using MXGP.Core.Contracts;
    using MXGP.IO;

    public class Engine : IEngine
    {
        private readonly ConsoleWriter writer;
        private readonly ConsoleReader reader;
        private readonly ChampionshipController controller;

        public Engine()
        {
        }

        public Engine(ChampionshipController controller, ConsoleReader reader, ConsoleWriter writer)
        {
            this.controller = controller;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {



            string input = reader.ReadLine();

            while (input != "End")
            {
                try
                {
                    ExecuteCommand(input);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }


                input = reader.ReadLine();
            }

        }

        private void ExecuteCommand(string input)
        {
            string[] tokens = input.Split();
            string command = tokens[0];

            if (command == "CreateRider")
            {
                string name = tokens[1];

                writer.WriteLine(controller.CreateRider(name));
            }
            else if (command == "CreateMotorcycle")
            {
                string type = tokens[1];
                string model = tokens[2];
                int horsePower = int.Parse(tokens[3]);

                writer.WriteLine(controller.CreateMotorcycle(type, model, horsePower));
            }
            else if (command == "AddMotorcycleToRider")
            {
                string name = tokens[1];
                string model = tokens[2];

                writer.WriteLine(controller.AddMotorcycleToRider(name, model));
            }
            else if (command == "AddRiderToRace")
            {
                string raceName = tokens[1];
                string riderName = tokens[2];

                writer.WriteLine(controller.AddRiderToRace(raceName, riderName));
            }
            else if (command == "CreateRace")
            {
                string race = tokens[1];
                int laps = int.Parse(tokens[2]);

                writer.WriteLine(controller.CreateRace(race, laps));
            }
            else if (command == "StartRace")
            {
                string racename = tokens[1];

                writer.WriteLine(controller.StartRace(racename));
            }
        }
    }
}
