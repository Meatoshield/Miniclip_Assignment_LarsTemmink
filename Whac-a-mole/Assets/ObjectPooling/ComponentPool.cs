using UnityEngine;

/// <summary>
/// Pool that stores Components which are attached to gameObjects
/// </summary>
/// <typeparam name="T"></typeparam>
public class ComponentPool<T> : ObjectPool<PoolableComponent>
    where T : PoolableComponent
{
    private Transform _parent = null;
    private GameObject _prefab = null;

    public ComponentPool(int pInitialSize, GameObject pPrefab, IElementGetter<PoolableComponent> pElementGetter)
    {
        _prefab = pPrefab;

        CreateObjectPool(pInitialSize, pElementGetter);
    }

    public override void Deconstruct()
    {
        GameObject.Destroy(_parent.gameObject);
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
