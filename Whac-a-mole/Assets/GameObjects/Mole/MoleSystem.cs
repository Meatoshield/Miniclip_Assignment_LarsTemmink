using UnityEngine;

/// <summary>
/// Class in charge of Moles and Holes. 
/// It update the spawner functionality and also frees up resources in the pools when they are available.
/// </summary>
public class MoleSystem
{
    private SpawnData _spawnData = default;

    private IMoleSpawner _moleSpawner = null;

    public MoleSystem(SpawnData pSpawnData)
    {
        _spawnData = pSpawnData;

        _spawnData.SetFreeElementCallback(SetMoleFree);

        HolePositioner.PositionHoles(_spawnData.HolePool.GetAllInstances());

        switch (_spawnData.KingMoleMode)
        {
            case true:
                _moleSpawner = new KingMoleSpawner(_spawnData.DifficultySettings);
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
            _moleSpawner.SpawnMole(_spawnData);
        }
    }

    public void Deconstruct()
    {
        _spawnData.MolePool.Deconstruct();
        _spawnData.HolePool.Deconstruct();

        _moleSpawner = null;

        _spawnData = default;
    }

    //When a mole dies, the Mole and Hole need to be freed up for future use
    private void SetMoleFree(Mole pMole)
    {
        if(pMole.GetType() != typeof(KingMole))
        {
            _spawnData.MolePool.SetInstanceFree(pMole);
        }
        _spawnData.HolePool.SetInstanceFree(pMole.Hole);
    }
}
