using UnityEngine;

/// <summary>
/// Class in charge of Moles and Holes. 
/// It update the spawner functionality and also frees up resources in the pools when they are available.
/// </summary>
public class MoleSystem
{
    private readonly DifficultySettings _difficultySettings;
    private readonly bool _kingMoleMode;

    private IObjectPool<PoolableComponent> _molePool = null;
    private IObjectPool<GameObject> _holePool = null;

    private IMoleSpawner _moleSpawner = null;

    public MoleSystem(DifficultySettings pDifficultySettings, bool pKingMoleMode, IObjectPool<PoolableComponent> pMolePool, IObjectPool<GameObject> pHolePool)
    {
        _difficultySettings = pDifficultySettings;
        _kingMoleMode = pKingMoleMode;

        _molePool = pMolePool;
        _holePool = pHolePool;

        HolePositioner.PositionHoles(_holePool.GetAllInstances());

        switch (_kingMoleMode)
        {
            case true:
                _moleSpawner = new KingMoleSpawner(_difficultySettings);
                EventManager.MoleKingDied += MoleKingDied;
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
        if (_kingMoleMode == true)
        {
            EventManager.MoleKingDied -= MoleKingDied;
        }

        _molePool.Deconstruct();
        _holePool.Deconstruct();

        _molePool = null;
        _holePool = null;
        _moleSpawner = null;
    }

    public void MoleKingDied(KingMole pMoleKing)
    {
        _holePool.SetInstanceFree(pMoleKing.Hole);
    }
}
