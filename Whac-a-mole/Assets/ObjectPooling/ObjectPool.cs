using UnityEngine;

public abstract class ObjectPool<T> : IObjectPool<T>
{
    private IElementGetter<T> _elementGetter = null;     

    private T[] _pool = null;

    private int _freeObjectAmount = 0; //How many objects are not in use
    public int FreeObjectAmount => _freeObjectAmount;

    public bool GrowsDynamically { get; set; } //Grows when there are no free instances in the pool

    protected void CreateObjectPool(int pInitialSize, IElementGetter<T> pElementGetter)
    {
        if (_pool != null)
        {
            return;
        }

        _elementGetter = pElementGetter;

        _pool = new T[pInitialSize];
        _freeObjectAmount = pInitialSize;

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

        _freeObjectAmount += pGrowAmount;
    }

    public T[] GetAllInstances()
    {
        return _pool;
    }

    public T GetFreeInstance()
    {
        if (_freeObjectAmount == 0)
        {
            GrowPool(_pool.Length);
        }

        return _elementGetter.GetFreeInstance(ref _pool, ref _freeObjectAmount);
    }

    public void SetInstanceFree(T pLockedInstance)
    {
        int instancePosition = System.Array.IndexOf(_pool, pLockedInstance);

        if (instancePosition == -1)
        {
            Debug.LogError($" {pLockedInstance.GetType()} Instance not contained by this pool");
        }

        T FirstLockedItem = _pool[_freeObjectAmount];
        _pool[_freeObjectAmount] = pLockedInstance;
        _pool[instancePosition] = FirstLockedItem;

        _freeObjectAmount++;
    }

    public abstract void Deconstruct();

    protected abstract T CreateInstance();
}