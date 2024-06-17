using UnityEngine;

public class MoleSystem
{
    private readonly DifficultySettings _difficultySettings;

    private IObjectPool<PoolableComponent> _molePool = null;
    private IObjectPool<GameObject> _holePool = null;

    private IMoleSpawner _moleSpawner = null;

    public MoleSystem(DifficultySettings pDifficultySettings, bool pKingMoleMode, IObjectPool<PoolableComponent> pMolePool, IObjectPool<GameObject> pHolePool)
    {
        _difficultySettings = pDifficultySettings;

        _molePool = pMolePool;
        _holePool = pHolePool;

        HolePositioner.PositionHoles(_holePool.GetAllInstances());

        switch (pKingMoleMode)
        {
            case true:
                _moleSpawner = new KingMoleSpawner(pDifficultySettings);
                break;
            case false:
                _moleSpawner = new NormalMoleSpawner();
                break;
        }
    }

    public void UpdateSystem()
    {
        _moleSpawner.UpdateSpawner(out bool pTimeToSpawnNextMole);

        if (pTimeToSpawnNextMole)
        {
            _moleSpawner.SpawnMole(_difficultySettings, _molePool, _holePool);
        }

        //When a mole dies, the Mole and Hole need to be freed up for future use
        ReturnInstancesToPools();
    }

    private void ReturnInstancesToPools()
    {
        PoolableComponent[] allMoles = _molePool.GetAllInstances();

        for (int i = _molePool.FreeObjectAmount; i < allMoles.Length; i++) //Only instances of moles currently in use
        {
            Mole mole = allMoles[i] as Mole;

            if (mole.IsDead == true)
            {
                _molePool.SetInstanceFree(allMoles[i]);
                _holePool.SetInstanceFree(mole.Hole);
            }
        }
    }

    public void Deconstruct()
    {
        _molePool.Deconstruct();
        _holePool.Deconstruct();

        _molePool = null;
        _holePool = null;
        _moleSpawner = null;
    }
}
