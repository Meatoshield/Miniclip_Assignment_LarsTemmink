using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if(_kingMoleSpawnCountdown > 0)
        {
            base.SpawnMole(pDifficultySettings, pMolePool, pHolePool);
            _kingMoleSpawnCountdown--;
            return;
        }

        GameObject hole = pHolePool.GetFreeInstance();

        _moleKing.Spawn(pDifficultySettings.KingMoleLifeTime, hole);

        SpawnCronies(pDifficultySettings, pMolePool, pHolePool);

        _kingMoleSpawnCountdown = pDifficultySettings.KingMoleFrequency;
    }

    private void SpawnCronies(DifficultySettings pDifficultySettings, IObjectPool<PoolableComponent> pMolePool, IObjectPool<GameObject> pHolePool)
    {
        for (int i = 0; i < pDifficultySettings.KingMoleCronieCount; i++)
        {
            base.SpawnMole(pDifficultySettings, pMolePool, pHolePool);
        }
    }
}
