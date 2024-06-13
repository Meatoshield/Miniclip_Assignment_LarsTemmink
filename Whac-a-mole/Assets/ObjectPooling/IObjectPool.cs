public interface IObjectPool<T>
{
    public void Initialize(int pInitialSize);

    public void GrowPoolSize(int pNewPoolSize, bool pAddInFront);

    public T GetFreeInstance();
}
