namespace GenericsVariance.Collections
{
    public interface IBetterCollection<in T, out R> : ICollectionGet<R>, ICollectionSet<T>
        where T : R
    {
    }
}
