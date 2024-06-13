public abstract class ObjectPool<T> : IObjectPool<T>
    where T : IPoolable
{
    private T[] _pool = null;

    private int _freeObjects = 0;

    public void Initialize(int pInitialSize)
    {
        _pool = new T[pInitialSize];
        _freeObjects = pInitialSize;

        for (int i = 0; i < pInitialSize; i++)
        {
            T poolObject = CreateInstance();
        }
    }

    public void GrowPoolSize(int pGrowAmount, bool pAddInFront)
    {
        int newSize = _pool.Length + pGrowAmount;

        T[] oldPool = _pool;
        _pool = new T[newSize];

        if (pAddInFront == true)
        {
            oldPool.CopyTo(_pool, newSize - oldPool.Length);
            return;
        }

        oldPool.CopyTo(_pool, 0);
    }

    public T GetFreeInstance()
    {
        if (_freeObjects == 0)
        {
            GrowPoolSize(_pool.Length * 2, true);
        }


        return _pool[0];
    }

    protected abstract T CreateInstance();
}
