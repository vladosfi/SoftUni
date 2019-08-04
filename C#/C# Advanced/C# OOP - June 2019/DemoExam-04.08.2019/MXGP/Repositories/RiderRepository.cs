using MXGP.Models.Riders.Contracts;
using MXGP.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace MXGP.Repositories
{
    public class RiderRepository : IRepository<IRider>
    {
        private readonly IList<IRider> riders;

        public RiderRepository()
        {
            this.riders = new List<IRider>();
        }

        public void Add(IRider model)
        {
            this.riders.Add(model);
        }

        public IReadOnlyCollection<IRider> GetAll()
        {
            return this.riders.ToList();
        }

        public IRider GetByName(string name)
        {
            return this.riders.FirstOrDefault(m => m.Name == name);
        }

        public bool Remove(IRider model)
        {
            return this.riders.Remove(model);
        }
    }
}


