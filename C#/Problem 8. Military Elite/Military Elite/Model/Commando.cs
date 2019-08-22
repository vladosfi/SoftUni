using Military_Elite.Contacts;
using Military_Elite.Enumerables;
using Military_Elite.Model.Privates.SpecialisedSoldiers;
using System.Collections.Generic;

namespace Military_Elite.Model
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id,
            string firstName, 
            string lastName, 
            decimal salary, 
            Corps corps, 
            IReadOnlyCollection<Mission> missions)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = missions;
        }

        public IReadOnlyCollection<Mission> Missions { get; }
    }
}
