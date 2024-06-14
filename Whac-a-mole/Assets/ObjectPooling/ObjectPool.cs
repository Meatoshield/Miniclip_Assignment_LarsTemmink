using UnityEngine;
using UnityEngine.Events;

public abstract class ObjectPool<T> : IObjectPool<T>
    where T : Object
{
    public T Prefab { get; } = null;

    public bool GrowsDynamically { get; set; }

    private T[] _pool = null;

    private int _freeObjects = 0; //How many objects are not in use

    public ObjectPool(int pInitialSize, T pPrefab)
    {
        Prefab = pPrefab;

        _pool = new T[pInitialSize];
        _freeObjects = pInitialSize;

        for (int i = 0; i < pInitialSize; i++)
        {
            _pool[i] = CreateInstance();
        }
    }

    public void GrowPoolSize(int pGrowAmount)
    {
        int newSize = _pool.Length + pGrowAmount;

        T[] oldPool = _pool;
        _pool = new T[newSize];

        oldPool.CopyTo(_pool, newSize - oldPool.Length);

        _freeObjects += pGrowAmount;
    }

    public T[] GetAllInstances()
    {
        return _pool;
    }
    
    public T GetFreeInstance()
    {
        if (_freeObjects == 0)
        {
            GrowPoolSize(_pool.Length);   
        }

        //Switch the first free instance with the last free instance
        T firstFreeInstance = _pool[0];
        T lastFreeInstance = _pool[_freeObjects - 1];
        _pool[_freeObjects - 1] = firstFreeInstance;
        _pool[0] = lastFreeInstance;

        //Lock firstFreeItem which was switched with the lastFreeItem
        _freeObjects--;

        return firstFreeInstance;
    }

    public void SetInstanceFree(T pLockedInstance)
    {
        int instancePosition = System.Array.IndexOf(_pool, pLockedInstance);

        if(instancePosition == -1)
        {
            Debug.LogError($" {pLockedInstance.GetType()} Instance not contained by this pool");
        }

        //Switch the first free instance with the last free instance
        T FirstLockedItem = _pool[_freeObjects];
        _pool[_freeObjects] = pLockedInstance;
        _pool[instancePosition] = FirstLockedItem;

        //Lock firstFreeItem which was switched with the lastFreeItem
        _freeObjects++;
    }

    protected abstract T CreateInstance();
}