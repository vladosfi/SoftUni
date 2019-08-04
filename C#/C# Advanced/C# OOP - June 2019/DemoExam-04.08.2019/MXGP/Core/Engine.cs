namespace MXGP.Core
{
    using System;
    using System.Collections.Generic;
    using MXGP.Core.Contracts;
    using MXGP.IO.Contracts;

    public class Engine : IEngine
    {
        private List<ChampionshipController> championships;
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine()
        {
            championships = new List<ChampionshipController>();
        }

        public Engine(IReader reader, IWriter writer)
            :this()
        {
            this.writer = writer;
            this.reader = reader;
        }

        public void Run()
        {
            ChampionshipController championship = new ChampionshipController();
            string inpit = this.reader.ReadLine();

            while (inpit != "End")
            {
                string[] commandArgs = inpit.Split(" ");
                string commandName = commandArgs[0];

                try
                {
                    if (commandName == "CreateRider")
                    {
                        string riderName = commandArgs[1];

                        this.writer.WriteLine(championship.CreateRider(riderName));
                    }
                    else if (commandName == "CreateMotorcycle")
                    {
                        string type = commandArgs[1];
                        string model = commandArgs[2];
                        int horsepower = int.Parse(commandArgs[3]);

                        this.writer.WriteLine(championship.CreateMotorcycle(type, model, horsepower));
                    }
                    else if (commandName == "AddMotorcycleToRider")
                    {
                        string riderName = commandArgs[1];
                        string motorcycleName = commandArgs[2];

                        this.writer.WriteLine(championship.AddMotorcycleToRider(riderName, motorcycleName));
                    }
                    else if (commandName == "AddRiderToRace")
                    {
                        string raceName = commandArgs[1];
                        string riderName = commandArgs[2];

                        this.writer.WriteLine(championship.AddRiderToRace(raceName, riderName));
                    }
                    else if (commandName == "CreateRace")
                    {
                        string name = commandArgs[1];
                        int laps = int.Parse(commandArgs[2]);

                        this.writer.WriteLine(championship.CreateRace(name, laps));
                    }
                    else if (commandName == "StartRace")
                    {
                        string raceName = commandArgs[1];

                        this.writer.WriteLine(championship.StartRace(raceName));
                    }
                }
                catch (ArgumentNullException ae)
                {
                    this.writer.WriteLine(ae.Message);
                }
                catch (ArgumentException ae)
                {
                    this.writer.WriteLine(ae.Message);
                }
                catch (InvalidOperationException ae)
                {
                    this.writer.WriteLine(ae.Message);
                }

                inpit = this.reader.ReadLine();
            }
        }
    }
}
