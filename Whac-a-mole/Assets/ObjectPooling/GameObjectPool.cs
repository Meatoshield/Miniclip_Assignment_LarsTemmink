using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : ObjectPool<GameObject>
{
    public GameObjectPool(int pInitialSize, GameObject pPrefab) : base(pInitialSize, pPrefab)
    {
    }

    protected override GameObject CreateInstance()
    {
        return GameObject.Instantiate(Prefab);
    }
}
