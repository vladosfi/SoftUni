using System.Collections.Generic;

namespace MilitaryElite
{
    public interface IComando : ISpecialisedSoldier
    {
        IReadOnlyCollection<IMission> Missions { get; }

        void CompleteMission(IMission mission);
    }
}
