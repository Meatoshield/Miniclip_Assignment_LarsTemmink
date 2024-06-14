using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleManager
{
    public GameObjectPool MolePool = null;

    private Transform _moleParent = null;

    public MoleManager(GameObject pPrefab)
    {
        _moleParent = new GameObject("MoleParent").transform;

        MolePool = new GameObjectPool(2, pPrefab);

        MolePool.GrowsDynamically = true;

        foreach (Object hole in MolePool.GetAllInstances())
        {
            ((GameObject)hole).transform.parent = _moleParent;
        }
    }

    public void DestroyMoles()
    {
        GameObject.Destroy(_moleParent.gameObject);
        MolePool = null;
    }
}
