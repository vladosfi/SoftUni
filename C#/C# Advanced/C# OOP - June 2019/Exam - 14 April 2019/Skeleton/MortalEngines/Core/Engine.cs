namespace MortalEngines.Core
{
    using System;
    using MortalEngines.Core.Contracts;

    public class Engine : IEngine
    {
        private readonly IMachinesManager machineManager;

        public Engine()
        {
            machineManager = new MachinesManager();
        }

        public void Run()
        {            
            string input = Console.ReadLine();

            while (input != "Quit")
            {
                string[] commandArgs = input.Split(" ");
                string command = commandArgs[0];
                string name = commandArgs[1];

                try
                {
                    if (command == "HirePilot")
                    {
                        Console.WriteLine(machineManager.HirePilot(name));
                    }
                    else if (command == "PilotReport")
                    {
                        Console.WriteLine(machineManager.PilotReport(name));
                    }
                    else if (command == "ManufactureTank")
                    {
                        double attack = double.Parse(commandArgs[2]);
                        double deffense = double.Parse(commandArgs[3]);

                        Console.WriteLine(machineManager.ManufactureTank(name, attack, deffense));
                    }
                    else if (command == "ManufactureFighter")
                    {
                        double attack = double.Parse(commandArgs[2]);
                        double deffense = double.Parse(commandArgs[3]);

                        Console.WriteLine(machineManager.ManufactureFighter(name, attack, deffense));
                    }
                    else if (command == "MachineReport")
                    {
                        Console.WriteLine(machineManager.MachineReport(name));
                    }
                    else if (command == "AggressiveMode")
                    {
                        Console.WriteLine(machineManager.ToggleFighterAggressiveMode(name));
                    }
                    else if (command == "DefenseMode")
                    {
                        Console.WriteLine(machineManager.ToggleTankDefenseMode(name));
                    }
                    else if (command == "Engage")
                    {
                        string machineName = commandArgs[2];
                        Console.WriteLine(machineManager.EngageMachine(name, machineName));
                    }
                    else if (command == "Attack")
                    {
                        string deffending = commandArgs[2];
                        Console.WriteLine(machineManager.AttackMachines(name, deffending));
                    }
                }
                catch (NullReferenceException nre)
                {
                    Console.WriteLine("Error: " + nre.Message);
                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("Error: " + ane.Message);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine("Error: " + ae.Message);
                }


                input = Console.ReadLine();
            }
        }
    }
}