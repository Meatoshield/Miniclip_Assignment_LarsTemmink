using UnityEngine;
using UnityEngine.Events;

public interface IMoleSpawner
{
    public void UpdateSpawner(out bool pTimeToSpawnNextMole);

    public void SpawnMole(SpawnData pSpawnData);
}
