using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Spawn moles at a regular interval based on the difficulty
/// </summary>
public class NormalMoleSpawner : IMoleSpawner
{
    protected float TimeUntilNextMoleSpawn = 0.5f; //First mole spawns after 0.5 seconds

    public void UpdateSpawner(out bool pTimeToSpawnNextMole)
    {
        pTimeToSpawnNextMole = false;

        TimeUntilNextMoleSpawn -= Time.deltaTime;

        if (TimeUntilNextMoleSpawn <= 0.0f)
        {
            pTimeToSpawnNextMole = true;
        }
    }

    public virtual void SpawnMole(SpawnData pSpawnData)
    {
        Mole mole = pSpawnData.MolePool.GetFreeInstance() as Mole;

        GameObject hole = pSpawnData.HolePool.GetFreeInstance();

        if (mole == null || hole == null)
        {
            return;
        }

        mole.Spawn(pSpawnData.DifficultySettings.MoleLifeTime, hole, pSpawnData.FreeElementCallback);

        TimeUntilNextMoleSpawn += pSpawnData.DifficultySettings.SpawnTimeBetweenMoles;
    }
}
