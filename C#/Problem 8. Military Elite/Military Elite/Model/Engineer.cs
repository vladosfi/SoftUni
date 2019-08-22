using System.Collections.Generic;
using Military_Elite.Contacts;
using Military_Elite.Enumerables;

namespace Military_Elite.Model
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, 
            string firstName, 
            string lastName, 
            decimal salary, 
            Corps corps, 
            IReadOnlyCollection<IRepair> repairs)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = repairs;
        }

        public IReadOnlyCollection<IRepair> Repairs { get; }
    }
}
