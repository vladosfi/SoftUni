namespace MXGP.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using MXGP.Models.Races.Contracts;
    using MXGP.Repositories.Contracts;

    public class RaceRepository : IRepository<IRace>
    {
        private readonly List<IRace> models;

        public RaceRepository()
        {
            this.models = new List<IRace>();
        }

        public void Add(IRace model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return this.models.ToList();
        }

        public IRace GetByName(string name)
        {
            return this.models.FirstOrDefault(m => m.Name == name);
        }

        public bool Remove(IRace model)
        {
            return this.models.Remove(model);
        }
    }
}
