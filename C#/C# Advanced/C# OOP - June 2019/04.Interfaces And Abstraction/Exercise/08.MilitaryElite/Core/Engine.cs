using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MilitaryElite
{
    public class Engine
    {
        private readonly List<ISoldier> army;

        public Engine()
        {
            this.army = new List<ISoldier>();
        }

        public void Run()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandArgs = command.Split(" ");

                string type = commandArgs[0];
                string id = commandArgs[1];
                string firstName = commandArgs[2];
                string lastName = commandArgs[3];
                decimal salary = decimal.Parse(commandArgs[4]);

                if (type == "Private")
                {
                    Private soldier = new Private(id, firstName, lastName, salary);

                    this.army.Add(soldier);
                }
                else if (type == "LieutenantGeneral")
                {
                    ILieutenantGeneral general = new LieutenantGeneral(id, firstName, lastName, salary);

                    string[] privatesToAddArgs = commandArgs.Skip(5).ToArray();

                    foreach (var pid in privatesToAddArgs)
                    {
                        ISoldier soldierToAdd = army.First(s => s.Id == pid);

                        general.AddPrivate(soldierToAdd);
                    }

                    this.army.Add(general);
                }
                else if (type == "Engineer")
                {
                    try
                    {
                        string corps = commandArgs[5];

                        IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);

                        string[] rapairArgs = commandArgs
                            .Skip(6)
                            .ToArray();

                        AddRepairs(engineer, rapairArgs);

                        this.army.Add(engineer);
                    }
                    catch (InvalidCorpsException ice)
                    {
                    }
                }
                else if (type == "Commando")
                {
                    try
                    {
                        string corps = commandArgs[5];

                        IComando commando = new Commando(id, firstName, lastName, salary, corps);

                        string[] missonArgs = commandArgs
                            .Skip(6)
                            .ToArray();

                        for (int i = 0; i < missonArgs.Length; i += 2)
                        {
                            try
                            {
                                string codeName = missonArgs[i];
                                string state = missonArgs[i + 1];

                                IMission mission = new Mission(codeName, state);

                                commando.AddMission(mission);
                            }
                            catch (IvalidStateException ime)
                            {
                                continue;
                            }
                        }

                        this.army.Add(commando);
                    }
                    catch (InvalidCorpsException ice)
                    {

                    }
                }
                else if (type == "Spy")
                {
                    int codeNumber = (int)salary;

                    ISpy spy = new Spy(id, firstName, lastName, codeNumber);

                    this.army.Add(spy);
                }

                command = Console.ReadLine();
            }

            PrintOutput();
        }

        private void PrintOutput()
        {
            foreach (var soldier in this.army)
            {
                Type type = soldier.GetType();

                Object actual = Convert.ChangeType(soldier, type);

                Console.WriteLine(actual.ToString());
            }
        }

        private static void AddRepairs(IEngineer engineer, string[] rapairArgs)
        {
            for (int i = 0; i < rapairArgs.Length; i += 2)
            {
                string partName = rapairArgs[i];
                int hours = int.Parse(rapairArgs[i + 1]);

                IRepair repair = new Repair(partName, hours);

                engineer.AddRepair(repair);
            }
        }
    }
}
