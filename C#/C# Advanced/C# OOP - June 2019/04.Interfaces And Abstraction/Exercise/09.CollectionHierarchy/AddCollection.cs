using System.Collections.Generic;

namespace CollectionHierarchy
{
    public class AddCollection<T> : IAddCollection<T>
    {
        protected List<T> collection;

        public AddCollection()
        {
            this.collection = new List<T>();
        }

        public virtual int Add(T str)
        {
            this.collection.Add(str);
            return this.collection.Count - 1;
        }
    }
}
