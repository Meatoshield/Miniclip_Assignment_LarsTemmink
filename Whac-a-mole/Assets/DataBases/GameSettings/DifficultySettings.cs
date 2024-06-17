using System;

[Serializable]
public record DifficultySettings
{
    public float SpawnTimeBetweenMoles;
    public float MoleLifeTime;  
    public int HoleCount;

    public int KingMoleFrequency;
    public float KingMoleLifeTime;
    public int KingMoleCronieCount;
}
