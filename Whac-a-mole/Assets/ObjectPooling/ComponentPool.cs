using UnityEngine;

public class ComponentPool<T> : ObjectPool<PoolableComponent>
    where T : PoolableComponent
{
    private Transform _parent = null;
    private GameObject _prefab = null;

    public ComponentPool(int pInitialSize, GameObject pPrefab)
    {
        _prefab = pPrefab;

        CreateObjectPool(pInitialSize);
    }

    protected override PoolableComponent CreateInstance()
    {
        if (_parent == null)
        {
            _parent = new GameObject($"{_prefab.name}Pool").transform;
        }

        GameObject instanceGameObject = GameObject.Instantiate(_prefab);
        PoolableComponent poolObject = instanceGameObject.AddComponent<T>();
        instanceGameObject.transform.parent = _parent;

        return poolObject;
    }
}
