public record GameSettings
{
    public DifficultySettings[] Difficulties;

    public GameSettings()
    {
        Difficulties = new DifficultySettings[3];

        Difficulties[0].SpawnTimeBetweenMoles = 0.8f;
        Difficulties[0].MoleLifeTime = 0.7f;
        Difficulties[0].KingSlimeLifeTime = 0.5f;
        Difficulties[0].HoleCount = 8;
        Difficulties[0].KingSlimeFriendCount = 4;

        Difficulties[1].SpawnTimeBetweenMoles = 0.55f;
        Difficulties[1].MoleLifeTime = 0.5f;
        Difficulties[1].KingSlimeLifeTime = 0.4f;
        Difficulties[1].HoleCount = 12;
        Difficulties[1].KingSlimeFriendCount = 7;

        Difficulties[1].SpawnTimeBetweenMoles = 0.2f;
        Difficulties[1].MoleLifeTime = 0.3f;
        Difficulties[1].KingSlimeLifeTime = 0.3f;
        Difficulties[1].HoleCount = 16;
        Difficulties[1].KingSlimeFriendCount = 10;
    }
}
