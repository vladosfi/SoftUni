using MXGP.Repositories.Contracts;
using System.Collections.Generic;

namespace MXGP.Repositories
{
    public abstract class Repository<T> : IRepository<T>
    {
        private List<T> models = new List<T>();

        public IReadOnlyCollection<T> Models { get => models; }

        public void Add(T model)
        {
            models.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return Models;
        }

        public abstract T GetByName(string name);

        public bool Remove(T model)
        {
            return models.Remove(model);
        }
    }
}
