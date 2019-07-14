using System.Collections.Generic;
using System;

namespace FoodShortage
{
    public class Engine
    {
        private IDataReader dataReader;
        private IDataWriter dataWriter;
        private List<IId> ids;


        public Engine(IDataReader dataReader, IDataWriter dataWriter)
        {
            this.dataReader = dataReader;
            this.dataWriter = dataWriter;
            ids = new List<IId>();
        }

        public void Run()
        {
            string command = dataReader.Read();

            while (command != "End")
            {
                string[] commandTokens = command.Split();

                if (commandTokens.Length == 3)
                {
                    Citizen citizen = GetCitizen(commandTokens);

                    ids.Add(citizen);
                }
                else if (commandTokens.Length == 2)
                {
                    Robot robot = GetRobot(commandTokens);

                    ids.Add(robot);
                }

                command = dataReader.Read();
            }

            var inputId = dataReader.Read();
            PrintIds(inputId);
        }

        private void PrintIds(string inputId)
        {
            foreach (var id in ids)
            {
                if (id.Id.EndsWith(inputId))
                {
                    dataWriter.Write(id.Id);
                }
            }
        }

        private static Robot GetRobot(string[] commandTokens)
        {
            string model = commandTokens[0];
            string id = commandTokens[1];
            Robot robot = new Robot(model, id);
            return robot;
        }

        private static Citizen GetCitizen(string[] commandTokens)
        {
            string name = commandTokens[0];
            int age = int.Parse(commandTokens[1]);
            string id = commandTokens[2];
            Citizen citizen = new Citizen(name, age, id);
            return citizen;
        }
    }
}
