namespace MortalEngines.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using MortalEngines.Common;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;
    using MortalEngines.Entities.Models;

    public class MachinesManager : IMachinesManager
    {
        private readonly List<IPilot> pilots = new List<IPilot>();
        private readonly List<IMachine> machines = new List<IMachine>();

        public string HirePilot(string name)
        {
            if (this.pilots.Any(p => p.Name == name))
            {
                return string.Format(OutputMessages.PilotExists, name);
            }

            Pilot pilot = new Pilot(name);
            this.pilots.Add(pilot);

            return string.Format(OutputMessages.PilotHired, name);
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.Any(p => p.Name == name))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }

            ITank tank = new Tank(name, attackPoints, defensePoints);
            this.machines.Add(tank);

            return string.Format(OutputMessages.TankManufactured, name, tank.AttackPoints, tank.DefensePoints);
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.Any(p => p.Name == name))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }

            IFighter fighter = new Fighter(name, attackPoints, defensePoints);


            this.machines.Add(fighter);

            return string.Format(OutputMessages.FighterManufactured
                , name
                , fighter.AttackPoints
                , fighter.DefensePoints
                , fighter.AggressiveMode == true ? "ON" : "OFF");
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            IPilot pilot = this.pilots.FirstOrDefault(p => p.Name == selectedPilotName);

            if (pilot == null)
            {
                return string.Format(OutputMessages.PilotNotFound, selectedPilotName);
            }

            IMachine machine = this.machines.FirstOrDefault(p => p.Name == selectedMachineName);

            if (machine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, selectedMachineName);
            }

            if (machine.Pilot != null)
            {
                return string.Format(OutputMessages.MachineHasPilotAlready, selectedMachineName);
            }

            pilot.AddMachine(machine);

            return string.Format(OutputMessages.MachineEngaged, selectedPilotName, selectedMachineName);
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            IMachine attackingMachine = this.machines.FirstOrDefault(p => p.Name == attackingMachineName);

            if (attackingMachine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, attackingMachineName);
            }

            IMachine defendingMachine = this.machines.FirstOrDefault(p => p.Name == defendingMachineName);

            if (defendingMachine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, defendingMachineName);
            }

            if (attackingMachine.HealthPoints <= 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, attackingMachineName);
            }

            if (defendingMachine.HealthPoints <= 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, defendingMachineName);
            }

            attackingMachine.Attack(defendingMachine);

            return string.Format(OutputMessages.AttackSuccessful, defendingMachineName, attackingMachineName, defendingMachine.HealthPoints);
        }

        public string PilotReport(string pilotReporting)
        {
            return this.pilots.FirstOrDefault(p => p.Name == pilotReporting).Report();
        }

        public string MachineReport(string machineName)
        {
            return this.machines.FirstOrDefault(m => m.Name == machineName).ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            IFighter fighter = (Fighter)this.machines.FirstOrDefault(t => t.Name == fighterName);

            if (fighter == null)
            {
                return string.Format(OutputMessages.MachineNotFound, fighterName);
            }

            fighter.ToggleAggressiveMode();

            return string.Format(OutputMessages.FighterOperationSuccessful, fighterName);
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            ITank tank = (Tank)this.machines.FirstOrDefault(t => t.Name == tankName);

            if (tank == null)
            {
                return string.Format(OutputMessages.MachineNotFound, tankName);
            }

            tank.ToggleDefenseMode();
            return string.Format(OutputMessages.TankOperationSuccessful, tankName);
        }
    }
}