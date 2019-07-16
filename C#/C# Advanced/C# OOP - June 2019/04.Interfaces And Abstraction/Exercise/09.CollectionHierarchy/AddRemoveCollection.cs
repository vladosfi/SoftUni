using System.Collections;

namespace CollectionHierarchy
{
    public class AddRemoveCollection<T> : AddCollection<T>, IAddRemoveCollection<T>
    {
        public override int Add(T str)
        {
            int index = 0;
            this.collection.Insert(index, str);
            return index;
        }

        public virtual T Remove()
        {
            int index = this.collection.Count - 1;
            T removedElement = this.collection[index];
            this.collection.RemoveAt(index);
            return removedElement;
        }
    }
}
