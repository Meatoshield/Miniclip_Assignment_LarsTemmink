using UnityEngine;

public abstract class GameObjectPool<T> : IObjectPool<T>
    where T : MonoBehaviour, IPoolable, ISpawnable
{
    private T[] _pool = null;
    private GameObject _prefab = null;

    public void Initialize(int pInitialSize)
    {
        _pool = new T[pInitialSize];

        GameObject poolGameObject = new GameObject();

        for (int i = 0; i < pInitialSize; i++)
        {
            GameObject instance = GameObject.Instantiate(_prefab, poolGameObject.transform);
            T poolObject = CreateInstance(instance);
        }
    }

    public abstract T CreateInstance(GameObject pInstance);
}
