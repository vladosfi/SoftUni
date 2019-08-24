using System;
using _03BarracksFactory.Contracts;

namespace P03_BarraksWars.Core.InputCommands
{
    public class FightCommand : Command
    {
        public FightCommand(string[] data, IUnitFactory unitFactory, IRepository repository)
            : base(data, unitFactory, repository)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);

            return string.Empty;
        }
    }
}
