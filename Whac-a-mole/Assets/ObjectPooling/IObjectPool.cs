using UnityEngine;
using UnityEngine.Events;
public interface IObjectPool<T>
{
    public T Prefab { get; }

    public bool GrowsDynamically { get; set; }

    public void GrowPoolSize(int pNewPoolSize);

    public T[] GetAllInstances();
    public T GetFreeInstance();

    public void SetInstanceFree(T pLockedInstance);
}
