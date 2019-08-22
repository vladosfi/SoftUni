using Military_Elite.Contacts;
using Military_Elite.Enumerables;

namespace Military_Elite.Model
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, Corps corps)
            : base(id, firstName, lastName, salary)
        {
            this.Corps = Corps;
        }

        public Corps Corps { get; }
        
    }
}
