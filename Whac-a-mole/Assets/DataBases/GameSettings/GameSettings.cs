using System;

[Serializable]
public record GameSettings
{
    public DifficultySettings[] Difficulties;
  
    public GameSettings()
    {
        Difficulties = new DifficultySettings[3];

        Difficulties[0] = new DifficultySettings();
        Difficulties[0].SpawnTimeBetweenMoles = 2.0f;
        Difficulties[0].MoleLifeTime = 1.5f;
        Difficulties[0].HoleCount = 16;
        Difficulties[0].KingMoleFrequency = 5;
        Difficulties[0].KingMoleLifeTime = 0.5f;
        Difficulties[0].KingMoleCronieCount = 4;

        Difficulties[1] = new DifficultySettings();
        Difficulties[1].SpawnTimeBetweenMoles = 0.55f;
        Difficulties[1].MoleLifeTime = 0.5f;
        Difficulties[1].HoleCount = 24;
        Difficulties[1].KingMoleFrequency = 7;
        Difficulties[1].KingMoleLifeTime = 0.4f;    
        Difficulties[1].KingMoleCronieCount = 7;

        Difficulties[2] = new DifficultySettings();
        Difficulties[2].SpawnTimeBetweenMoles = 0.2f;
        Difficulties[2].MoleLifeTime = 0.3f;
        Difficulties[2].HoleCount = 32;
        Difficulties[2].KingMoleFrequency = 7;
        Difficulties[2].KingMoleLifeTime = 0.3f;
        Difficulties[2].KingMoleCronieCount = 10;
    }
}
