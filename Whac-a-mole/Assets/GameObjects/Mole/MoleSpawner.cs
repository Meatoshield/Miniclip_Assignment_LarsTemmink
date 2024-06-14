using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleSpawner
{
    private DifficultySettings _difficultySettings;

    private float _timeSinceLastMoleSpawn = 0.0f;

    public void StartMoleSpawning(DifficultySettings pDifficulty)
    {
        _difficultySettings = pDifficulty;

        _timeSinceLastMoleSpawn = _difficultySettings.SpawnTimeBetweenMoles - 0.5f;  //Start with a small delay
    }

    public void Update()
    {
        _timeSinceLastMoleSpawn += Time.deltaTime;
    }

    public bool ReadyToSpawnMole()
    {
        if (_timeSinceLastMoleSpawn > _difficultySettings.SpawnTimeBetweenMoles)
        {
            return true;
        }

        return false;
    }

    public void TrySpawnMole()
    {

    }
}
