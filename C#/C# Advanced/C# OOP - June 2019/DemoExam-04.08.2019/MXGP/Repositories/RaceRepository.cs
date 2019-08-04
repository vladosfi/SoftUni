using MXGP.Models.Races.Contracts;
using MXGP.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace MXGP.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly IList<IRace> races;

        public RaceRepository()
        {
            this.races = new List<IRace>();
        }

        public void Add(IRace model)
        {
            this.races.Add(model);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return this.races.ToList();
        }

        public IRace GetByName(string name)
        {
            return races.FirstOrDefault(m => m.Name == name);
        }

        public bool Remove(IRace model)
        {
            return this.races.Remove(model);
        }
    }
}
