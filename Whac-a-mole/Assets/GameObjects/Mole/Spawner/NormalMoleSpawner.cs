using UnityEngine;

public class NormalMoleSpawner : IMoleSpawner
{
    private float TimeUntilNextMoleSpawn = 0.5f; //First mole spawns after 0.5 seconds

    public void UpdateSpawner(out bool pTimeToSpawnNextMole)
    {
        pTimeToSpawnNextMole = false;

        TimeUntilNextMoleSpawn -= Time.deltaTime;

        if (TimeUntilNextMoleSpawn <= 0.0f)
        {
            pTimeToSpawnNextMole = true;
        }
    }

    public virtual void SpawnMole(DifficultySettings pDifficultySettings, IObjectPool<PoolableComponent> pMolePool, IObjectPool<GameObject> pHolePool)
    {
        Mole mole = pMolePool.GetFreeInstance() as Mole;

        GameObject hole = pHolePool.GetFreeInstance();

        if (mole == null || hole == null)
        {
            return;
        }

        mole.Spawn(pDifficultySettings.MoleLifeTime, hole);

        TimeUntilNextMoleSpawn += pDifficultySettings.SpawnTimeBetweenMoles;
    }
}
