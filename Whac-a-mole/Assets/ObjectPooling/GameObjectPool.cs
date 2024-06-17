using UnityEngine;

public class GameObjectPool : ObjectPool<GameObject>
{
    private Transform _parent = null;
    private GameObject _prefab = null;

    public GameObjectPool(int pInitialSize, GameObject pPrefab, IElementGetter<GameObject> pElementGetter)
    {
        _prefab = pPrefab;

        CreateObjectPool(pInitialSize, pElementGetter);
    }

    public override void Deconstruct()
    {
        GameObject.Destroy(_parent.gameObject);
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
