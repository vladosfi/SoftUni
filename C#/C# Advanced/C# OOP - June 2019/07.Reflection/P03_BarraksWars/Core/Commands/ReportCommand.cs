using _03BarracksFactory.Contracts;
using System;
namespace P03_BarraksWars.Core.Commands
{
    class ReportCommand : Command
    {
        public ReportCommand(string[] data, IUnitFactory unitFactory, IRepository unitRepository) 
            : base(data, unitFactory, unitRepository)
        {
        }

        public override string Execute()
        {
            string output = this.UnitRepository.Statistics;
            return output;
        }
    }
}
