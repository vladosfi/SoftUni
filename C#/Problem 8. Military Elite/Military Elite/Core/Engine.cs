using Military_Elite.Contacts;
using Military_Elite.Enumerables;
using Military_Elite.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Military_Elite.Core
{
    public class Engine : IEngine
    {
        private readonly IList<ISoldier> soldiers;

        public Engine()
        {
            this.soldiers = new List<ISoldier>();
        }

        public void Run()
        {
            string line = Console.ReadLine();

            while (line != "End")
            {
                try
                {
                    Execute(line);
                }
                catch (Exception ex)
                {

                }

                line = Console.ReadLine();
            }
        }

        public void Execute(string line)
        {
            ISoldier soldier = null;

            string[] tokens = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string itemType = tokens[0];
            int id = int.Parse(tokens[1));
            string firstName = tokens[2];
            string lastName = tokens[3];

            if (itemType == "Private")
            {
                decimal salary = decimal.Parse(tokens[4]);
                soldier = new Private(id, firstName, lastName, salary);
            }
            else if (itemType == "LieutenantGeneral")
            {
                decimal salary = decimal.Parse(tokens[4]);

                List<ISoldier> privates = new List<ISoldier>();

                for (int i = 5; i < tokens.Length; i++)
                {
                    int currentPrivateId = int.Parse(tokens[i];
                    soldier = soldiers.FirstOrDefault(p => p.Id == currentPrivateId);

                    if (soldier != null)
                    {
                        privates.Add(soldier);
                    }
                }

                soldier = new LieutenantGeneral(id, firstName, lastName, salary, privates);
            }
            else if (itemType == "Engineer")
            {
                decimal salary = decimal.Parse(tokens[4]);
                string corpsString = tokens[5];

                if (!Enum.TryParse<Corps>(corpsString, out Corps corps))
                {
                    return;
                }

                IRepair repair = null;
                List<IRepair> repairs = new List<IRepair>();

                for (int i = 6; i < tokens.Length; i += 2)
                {
                    string partName = tokens[i];
                    int hoursWorked = int.Parse(tokens[i + 1]);

                    repair = new Repair(partName, hoursWorked);
                    repairs.Add(repair);
                }

                soldier = new Engineer(id, firstName, lastName, salary, corps, repairs);
            }
            else if (itemType == "Commando")
            {
                decimal salary = decimal.Parse(tokens[4]);
                string corpsString = tokens[5];

                if (!Enum.TryParse<Corps>(corpsString, out Corps corps))
                {
                    return;
                }

                List<IMission> missins = new List<IMission>();

                for (int i = 6; i < tokens.Length; i += 2)
                {
                    string codeName = tokens[i];
                    string stateString = tokens[i+1];

                    if (!Enum.TryParse<State>(stateString, out State state))
                    {
                        continue;
                    }

                    IMission mission = new Mission(codeName, state);
                    missins.Add(mission);
                }
            }
            else if (itemType == "Spy")
            {
                int codeNumber = int.Parse(tokens[4]);

                soldier = new Spy(id, firstName, lastName, codeNumber);
            }

            soldiers.Add(soldier);

        }
    }
}
