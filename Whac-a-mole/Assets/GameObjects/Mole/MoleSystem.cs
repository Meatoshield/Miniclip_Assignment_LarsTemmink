using UnityEngine;

public class MoleSystem
{
    private IObjectPool<PoolableComponent> _molePool = null;
    private IObjectPool<GameObject> _holePool = null;

    private IMoleSpawner _moleSpawner = null;

    public MoleSystem(GameData pCurrentGameData, IObjectPool<PoolableComponent> pMolePool, IObjectPool<GameObject> pHolePool)
    {
        _molePool = pMolePool;
        _holePool = pHolePool;

        HolePositioner.PositionHoles(_holePool.GetAllInstances());

        switch (pCurrentGameData.KingSlimeMode)
        {
            case false:
                _moleSpawner = new NormalMoleSpawner();
                break;
            default:
                break;
        }
    }

    public void UpdateSystem(GameData pCurrentGameData)
    {
        _moleSpawner.UpdateSpawner(pCurrentGameData, out bool pTimeToSpawnNextMole);

        if (pTimeToSpawnNextMole)
        {
            _moleSpawner.SpawnMole(pCurrentGameData, _molePool, _holePool);
        }

        PoolableComponent[] allMoles = _molePool.GetAllInstances();

        for (int i = _molePool.FreeObjectCount; i < allMoles.Length; i++) //Only the moles that are currently alive on screen
        {
            Mole mole = allMoles[i] as Mole;

            if (mole.IsDead == true)
            {
                _molePool.SetInstanceFree(allMoles[i]);
                _holePool.SetInstanceFree(mole.Hole);
            }
        }
    }

    public void DestroyPoolitems()
    {
        PoolableComponent[] allMoles = _molePool.GetAllInstances();

        foreach (PoolableComponent mole in allMoles)
        {
            GameObject.Destroy(mole);
        }

        GameObject[] allHoles = _holePool.GetAllInstances();

        foreach (GameObject hole in allHoles)
        {
            GameObject.Destroy(hole);
        }

        _moleSpawner = null;
    }
}
