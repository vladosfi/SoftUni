using _03BarracksFactory.Contracts;

namespace P03_BarraksWars.Core.InputCommands
{
    public class RetireCommand : Command
    {
        public RetireCommand(string[] data, IUnitFactory unitFactory, IRepository repository) 
            : base(data, unitFactory, repository)
        {
        }

        public override string Execute()
        {
            string unitType = Data[1];
            this.Repository.RemoveUnit(unitType);
            string output = unitType + " retired!";
            return output;
        }
    }
}
