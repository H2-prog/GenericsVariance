namespace GenericsVariance.Collections
{
    public interface ICollectionSet<in T>
    {
        int Set(T obj);
    }
}