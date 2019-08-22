using Military_Elite.Contacts;
using System.Collections.Generic;

namespace Military_Elite.Model
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary, ICollection<ISoldier> privates)
            : base(id, firstName, lastName, salary)
        {
            this.Privates = privates;
        }
        
        public ICollection<ISoldier> Privates { get; }
    }
}
