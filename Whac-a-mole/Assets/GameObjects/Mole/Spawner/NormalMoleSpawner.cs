using UnityEngine;

public class NormalMoleSpawner : IMoleSpawner
{
    private float TimeUntilNextMoleSpawn = 0.5f; //First mole spawns after 0.5 seconds

    public void UpdateSpawner(GameData pGameData, out bool pTimeToSpawnNextMole)
    {
        pTimeToSpawnNextMole = false;

        TimeUntilNextMoleSpawn -= Time.deltaTime;

        if (TimeUntilNextMoleSpawn <= 0.0f)
        {
            pTimeToSpawnNextMole = true;
        }
    }

    public void SpawnMole(GameData pGameData, IObjectPool<PoolableComponent> MolePool, IObjectPool<GameObject> HolePool)
    {
        Mole mole = MolePool.GetFreeInstance() as Mole;

        GameObject hole = HolePool.GetFreeInstance();

        if (mole == null || hole == null)
        {
            return;
        }

        mole.Spawn(pGameData, hole);

        TimeUntilNextMoleSpawn += pGameData.ChosenDifficultySettings.SpawnTimeBetweenMoles;
    }
}
