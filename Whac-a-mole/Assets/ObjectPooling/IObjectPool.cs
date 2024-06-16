public interface IObjectPool<T>
{
    public int FreeObjectCount { get; }
    public bool GrowsDynamically { get; set; }

    public void GrowPool(int pNewPoolSize);

    public T[] GetAllInstances();
    public T GetFreeInstance();

    public void SetInstanceFree(T pLockedInstance);
}
