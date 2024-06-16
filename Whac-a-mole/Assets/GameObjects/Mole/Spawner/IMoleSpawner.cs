using UnityEngine;

public interface IMoleSpawner
{
    public void UpdateSpawner(GameData pGameData, out bool pTimeToSpawnNextMole);

    public void SpawnMole(GameData pGameData, IObjectPool<PoolableComponent> MolePool, IObjectPool<GameObject> HolePool);
}
