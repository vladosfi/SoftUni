using System.Collections.Generic;

namespace Military_Elite.Contacts
{
    public interface IEngineer
    {
        IReadOnlyCollection<IRepair> Repairs { get; }
    }
}
