using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleManager
{
    public GameObjectPool HolePool = null;

    private Transform _holeParent = null;

    public HoleManager(GameObject pPrefab, DifficultySettings pSettings)
    {
        _holeParent = new GameObject("HoleParent").transform;

        HolePool = new GameObjectPool(pSettings.HoleCount, pPrefab);

        foreach(Object hole in HolePool.GetAllInstances())
        {
            ((GameObject)hole).transform.parent = _holeParent;
        }
    }

    public void DestroyHoles()
    {
        GameObject.Destroy(_holeParent.gameObject);
        HolePool = null;
    }
}
