namespace MXGP.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using MXGP.Models.Motorcycles.Contracts;
    using MXGP.Repositories.Contracts;

    public class MotorcycleRepository : IRepository<IMotorcycle>
    {
        private readonly List<IMotorcycle> models;

        public MotorcycleRepository()
        {
            this.models = new List<IMotorcycle>();
        }

        public void Add(IMotorcycle model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<IMotorcycle> GetAll()
        {
            return this.models.ToList();
        }

        public IMotorcycle GetByName(string name)
        {
            return this.models.FirstOrDefault(m => m.Model == name);
        }

        public bool Remove(IMotorcycle model)
        {
            return this.models.Remove(model);
        }
    }
}
