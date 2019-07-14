using System.Collections.Generic;
using System;
using System.Linq;

namespace FoodShortage
{
    public class Engine
    {
        private IDataReader dataReader;
        private IDataWriter dataWriter;
        private List<IId> ids;
        private List<IBirthdate> birthdates;
        private List<ICitizen> buyers;


        public Engine(IDataReader dataReader, IDataWriter dataWriter)
        {
            this.dataReader = dataReader;
            this.dataWriter = dataWriter;
            ids = new List<IId>();
            birthdates = new List<IBirthdate>();
            buyers = new List<ICitizen>();
        }

        public void Run()
        {
            int numberOfInputLines = int.Parse(dataReader.Read());

            for (int i = 0; i < numberOfInputLines; i++)
            {
                string[] commandTokens = dataReader.Read().Split();

                if (commandTokens.Length == 4)
                {
                    Citizen citizen = GetCitizen(commandTokens);
                    ids.Add(citizen);
                    birthdates.Add(citizen);
                    buyers.Add(citizen);
                }
                else if (commandTokens.Length == 3)
                {
                    Rebel rebel = GetRebel(commandTokens);
                    buyers.Add(rebel);
                }
            }


            string name = dataReader.Read();

            while (name != "End")
            {
                ICitizen citizen = buyers.Where(c => c.Name == name).FirstOrDefault();

                if (citizen != null)
                {
                    citizen.BuyFood();
                }

                name = dataReader.Read();
            }

            PrintTotalAmountOfFoodBuyed();
        }

        private void PrintTotalAmountOfFoodBuyed()
        {
            int totalSum = buyers.Select(b => b.Food).Sum();

            dataWriter.Write(totalSum);
        }



        private static Rebel GetRebel(string[] rebelData)
        {
            string name = rebelData[0];
            int age = int.Parse(rebelData[1]);
            string group = rebelData[2];
            Rebel rebel = new Rebel(name, age, group);
            return rebel;
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
            string name = citizenData[0];
            int age = int.Parse(citizenData[1]);
            string id = citizenData[2];
            string birthdate = citizenData[3];
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
