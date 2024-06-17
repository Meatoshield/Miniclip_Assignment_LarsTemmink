using UnityEngine;

/// <summary>
/// Main logic for the object pools.
/// Exposes IElementGetter to facilitate different fuctionality for accesssing pool items
/// The pools can grow dynamically with the demand if that is desired
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class ObjectPool<T> : IObjectPool<T>
{
    private IElementGetter<T> _elementGetter = null;

    private T[] _pool = null;

    private int _freeObjectAmount = 0; //How many objects are not in use
    public int FreeObjectAmount => _freeObjectAmount;

    public bool GrowsDynamically { get; set; } = false; //Grows when there are no free instances in the pool

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

        oldPool.CopyTo(_pool, newSize - oldPool.Length); //Copy existing pool data to the back of the new pool array

        _freeObjectAmount += pGrowAmount;

        for (int i = 0; i < pGrowAmount; i++)
        {
            _pool[i] = CreateInstance();
        }
    }

    public T[] GetAllInstances()
    {
        return _pool;
    }

    public T GetFreeInstance()
    {
        if (_freeObjectAmount == 0 && GrowsDynamically == true)
        {
            GrowPool(_pool.Length); //Double the pool in size if there are no available instances
        }

        if (_freeObjectAmount <= 0)
        {
            return default;
        }

        return _elementGetter.GetFreeInstance(ref _pool, ref _freeObjectAmount);
    }

    public void SetInstanceFree(T pLockedInstance)
    {
        int instancePosition = System.Array.IndexOf(_pool, pLockedInstance); //Get index of the instance we're trying to free

        if (instancePosition == -1)
        {
            Debug.LogError($" {pLockedInstance.GetType()} Instance not contained by this pool");
        }

        //Swap the freed instance with the first locked instance in the array
        T FirstLockedItem = _pool[_freeObjectAmount];
        _pool[_freeObjectAmount] = pLockedInstance;
        _pool[instancePosition] = FirstLockedItem;

        _freeObjectAmount++;
    }

    public abstract void Deconstruct();

    protected abstract T CreateInstance();
}