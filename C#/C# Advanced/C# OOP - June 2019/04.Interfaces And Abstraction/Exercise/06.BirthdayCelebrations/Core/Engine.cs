using System.Collections.Generic;
using System;

namespace BirthdayCelebrations
{
    public class Engine
    {
        private IDataReader dataReader;
        private IDataWriter dataWriter;
        private List<IId> ids;
        private List<IBirthdate> birthdates;


        public Engine(IDataReader dataReader, IDataWriter dataWriter)
        {
            this.dataReader = dataReader;
            this.dataWriter = dataWriter;
            ids = new List<IId>();
            birthdates = new List<IBirthdate>();
        }

        public void Run()
        {
            string command = dataReader.Read();

            while (command != "End")
            {
                string[] commandTokens = command.Split();
                string objectType = commandTokens[0];

                if (objectType == "Citizen")
                {
                    Citizen citizen = GetCitizen(commandTokens);
                    ids.Add(citizen);
                    birthdates.Add(citizen);
                }
                else if (objectType == "Robot")
                {
                    Robot robot = GetRobot(commandTokens);
                    ids.Add(robot);
                }
                else if (objectType == "Pet")
                {
                    Pet pet = GetPet(commandTokens);
                    birthdates.Add(pet);
                }

                command = dataReader.Read();
            }

            var inputBirthDate = dataReader.Read();
            PrintDate(inputBirthDate);
        }

        private void PrintDate(string inputBirthDate)
        {
            foreach (var date in birthdates)
            {
                if (date.Birthdate.EndsWith(inputBirthDate))
                {
                    dataWriter.Write(date.Birthdate);
                }
            }
        }

        private static Robot GetRobot(string[] robotData)
        {
            string model = robotData[1];
            string id = robotData[2];
            Robot robot = new Robot(model, id);
            return robot;
        }

        private static Citizen GetCitizen(string[] citizenData)
        {
            string name = citizenData[1];
            int age = int.Parse(citizenData[2]);
            string id = citizenData[3];
            string birthdate = citizenData[4];
            Citizen citizen = new Citizen(name, age, id, birthdate);
            return citizen;
        }

        private static Pet GetPet(string[] petData)
        {
            string name = petData[1];
            string birthdate = petData[2];
            Pet pet = new Pet(name, birthdate);
            return pet;
        }
    }
}
