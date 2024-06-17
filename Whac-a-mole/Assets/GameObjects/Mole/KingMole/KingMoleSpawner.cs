using UnityEngine;

/// <summary>
/// Spawn normal moles until it is time to spawn a king mole with his cronies
/// </summary>
public class KingMoleSpawner : NormalMoleSpawner
{
    private KingMole _moleKing = null;

    private int _kingMoleSpawnCountdown = 0;

    public KingMoleSpawner(DifficultySettings pDifficultySettings)
    {
        _moleKing = GameObject.Instantiate(PrefabStore.Instance.KingMolePrefab).GetComponent<KingMole>();

        _kingMoleSpawnCountdown = pDifficultySettings.KingMoleFrequency;
    }

    public override void SpawnMole(DifficultySettings pDifficultySettings, IObjectPool<PoolableComponent> pMolePool, IObjectPool<GameObject> pHolePool)
    {
        _kingMoleSpawnCountdown--;

        if (_kingMoleSpawnCountdown > 0)
        {
            base.SpawnMole(pDifficultySettings, pMolePool, pHolePool);
            return;
        }

        float timeUntilNextMoleSpawn = TimeUntilNextMoleSpawn; //Overwrite the timeUntilNextMoleSpawn being altered by normalMoleSpawner

        GameObject hole = pHolePool.GetFreeInstance();

        _moleKing.Spawn(pDifficultySettings.KingMoleLifeTime, hole);

        SpawnCronies(pDifficultySettings, pMolePool, pHolePool);

        _kingMoleSpawnCountdown = pDifficultySettings.KingMoleFrequency;

        TimeUntilNextMoleSpawn = timeUntilNextMoleSpawn + pDifficultySettings.SpawnTimeBetweenMoles; //Overwrite the timeUntilNextMoleSpawn being altered by normalMoleSpawner
    }

    private void SpawnCronies(DifficultySettings pDifficultySettings, IObjectPool<PoolableComponent> pMolePool, IObjectPool<GameObject> pHolePool)
    {
        for (int i = 0; i < pDifficultySettings.KingMoleCronieCount; i++)
        {
            base.SpawnMole(pDifficultySettings, pMolePool, pHolePool);
        }
    }
}
