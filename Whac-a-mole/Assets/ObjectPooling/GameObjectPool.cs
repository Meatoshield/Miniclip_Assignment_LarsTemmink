using UnityEngine;

public class GameObjectPool : ObjectPool<GameObject>
{
    private Transform _parent = null;
    private GameObject _prefab = null;

    public GameObjectPool(int pInitialSize, GameObject pPrefab)
    {
        _prefab = pPrefab;

        CreateObjectPool(pInitialSize);
    }

    protected override GameObject CreateInstance()
    {
        if (_parent == null)
        {
            _parent = new GameObject($"{_prefab.name}Pool").transform;
        }

        GameObject poolGameObject = GameObject.Instantiate(_prefab);
        poolGameObject.transform.parent = _parent;

        return poolGameObject;
    }
}
