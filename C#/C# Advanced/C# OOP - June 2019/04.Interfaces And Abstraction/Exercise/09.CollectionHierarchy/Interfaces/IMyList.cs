namespace CollectionHierarchy
{
    public interface IMyList<T>: IAddRemoveCollection<T>
    {
        int Used { get; }
    }
}
