using UnityEngine;

public interface IMoleSpawner
{
    public void UpdateSpawner(out bool pTimeToSpawnNextMole);

    public void SpawnMole(DifficultySettings pDifficultySettings, IObjectPool<PoolableComponent> MolePool, IObjectPool<GameObject> HolePool);
}
