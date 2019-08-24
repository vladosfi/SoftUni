using _03BarracksFactory.Contracts;

namespace P03_BarraksWars.Core.InputCommands
{
    public class ReportCommand : Command
    {
        public ReportCommand(string[] data, IUnitFactory unitFactory, IRepository repository) 
            : base(data, unitFactory, repository)
        {
        }

        public override string Execute()
        {
            string output = this.Repository.Statistics;
            return output;
        }
    }
}
