using System.Collections.Generic;

namespace MilitaryElite
{
    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corps { get; }
    }
}
