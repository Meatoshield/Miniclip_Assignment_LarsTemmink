using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Spawn normal moles until it is time to spawn a king mole with his cronies
/// </summary>
/// 
public class KingMoleSpawner : NormalMoleSpawner
{
    private KingMole _moleKing = null;

    private int _kingMoleSpawnCountdown = 0;

    public KingMoleSpawner(DifficultySettings pDifficultySettings)
    {
        _moleKing = GameObject.Instantiate(PrefabStore.Instance.KingMolePrefab).GetComponent<KingMole>();

        _kingMoleSpawnCountdown = pDifficultySettings.KingMoleFrequency;

        EventManager.DisableScreen += OnScreenSwitch;
    }

    private void OnScreenSwitch(ScreenTypes pScreenTypes)
    {
        GameObject.Destroy(_moleKing.gameObject);
        EventManager.DisableScreen -= OnScreenSwitch;
    }

    public override void SpawnMole(SpawnData pSpawnData)
    {
        _kingMoleSpawnCountdown--;

        if (_kingMoleSpawnCountdown > 0)
        {
            base.SpawnMole(pSpawnData);
            return;
        }

        float timeUntilNextMoleSpawn = TimeUntilNextMoleSpawn; //Overwrite the timeUntilNextMoleSpawn being altered by normalMoleSpawner

        GameObject hole = pSpawnData.HolePool.GetFreeInstance();

        _moleKing.Spawn(pSpawnData.DifficultySettings.KingMoleLifeTime, hole, pSpawnData.FreeElementCallback);

        SpawnCronies(pSpawnData);

        _kingMoleSpawnCountdown = pSpawnData.DifficultySettings.KingMoleFrequency;

        TimeUntilNextMoleSpawn = timeUntilNextMoleSpawn + pSpawnData.DifficultySettings.SpawnTimeBetweenMoles; //Overwrite the timeUntilNextMoleSpawn being altered by normalMoleSpawner
    }

    private void SpawnCronies(SpawnData pSpawnData)
    {
        for (int i = 0; i < pSpawnData.DifficultySettings.KingMoleCronieCount; i++)
        {
            base.SpawnMole(pSpawnData);
        }
    }
}
