using System.Collections.Generic;

namespace MilitaryElite
{
    public interface ILieutenantGeneral : IPrivate
    {
        IReadOnlyCollection<ISoldier> Privates { get; }

        void AddPrivate(IPrivate @private);
    }
}
