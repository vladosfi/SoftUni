using MXGP.Models.Motorcycles.Contracts;
using MXGP.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace MXGP.Repositories
{
    public class MotorcycleRepository : IRepository<IMotorcycle>
    {
        private readonly IList<IMotorcycle> motorcycles;

        public MotorcycleRepository()
        {
            this.motorcycles = new List<IMotorcycle>();
        }

        public void Add(IMotorcycle model)
        {
            this.motorcycles.Add(model);
        }

        public IReadOnlyCollection<IMotorcycle> GetAll()
        {
            return this.motorcycles.ToList();
        }

        public IMotorcycle GetByName(string name)
        {
            return motorcycles.FirstOrDefault(m => m.Model == name);
        }

        public bool Remove(IMotorcycle model)
        {
            return this.motorcycles.Remove(model);
        }

    }
}
