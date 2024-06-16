using UnityEngine;

public abstract class ObjectPool<T> : IObjectPool<T>
{
    public bool GrowsDynamically { get; set; } //Grows when there are no free instances in the pool

    private T[] _pool = null;

    private int _freeObjectCount = 0; //How many objects are not in use
    public int FreeObjectCount => _freeObjectCount;

    protected void CreateObjectPool(int pInitialSize)
    {
        if (_pool != null)
        {
            return;
        }

        _pool = new T[pInitialSize];
        _freeObjectCount = pInitialSize;

        for (int i = 0; i < pInitialSize; i++)
        {
            _pool[i] = CreateInstance();
        }
    }

    public void GrowPool(int pGrowAmount)
    {
        int newSize = _pool.Length + pGrowAmount;

        T[] oldPool = _pool;
        _pool = new T[newSize];

        oldPool.CopyTo(_pool, newSize - oldPool.Length);

        _freeObjectCount += pGrowAmount;
    }

    public T[] GetAllInstances()
    {
        return _pool;
    }

    public T GetFreeInstance()
    {
        if (_freeObjectCount == 0)
        {
            GrowPool(_pool.Length);
        }

        //Switch the first free instance with the last free instance
        T firstFreeInstance = _pool[0];
        T lastFreeInstance = _pool[_freeObjectCount - 1];
        _pool[_freeObjectCount - 1] = firstFreeInstance;
        _pool[0] = lastFreeInstance;

        //Lock firstFreeItem which was switched with the lastFreeItem
        _freeObjectCount--;

        return firstFreeInstance;
    }

    public void SetInstanceFree(T pLockedInstance)
    {
        int instancePosition = System.Array.IndexOf(_pool, pLockedInstance);

        if (instancePosition == -1)
        {
            Debug.LogError($" {pLockedInstance.GetType()} Instance not contained by this pool");
        }

        T FirstLockedItem = _pool[_freeObjectCount];
        _pool[_freeObjectCount] = pLockedInstance;
        _pool[instancePosition] = FirstLockedItem;

        _freeObjectCount++;
    }

    protected abstract T CreateInstance();
}