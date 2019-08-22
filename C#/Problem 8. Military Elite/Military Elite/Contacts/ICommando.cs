using Military_Elite.Model;
using System.Collections.Generic;

namespace Military_Elite.Contacts
{
    public interface ICommando
    {
        IReadOnlyCollection<Mission> Missions { get; }
    }
}
