namespace CollectionHierarchy
{
    public class MyList<T> : AddRemoveCollection<T>, IMyList<T>
    {
        public int Used => this.collection.Count;

        public override T Remove()
        {
            int index = 0;
            T removedElement = this.collection[index];
            this.collection.RemoveAt(index);
            return removedElement;
        }
    }
}
