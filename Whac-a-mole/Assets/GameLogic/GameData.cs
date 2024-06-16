public class GameData
{
    public float Timer = 5.0f;

    public DifficultyTypes ChosenDifficulty;
    public DifficultySettings ChosenDifficultySettings => SettingsDataBase.GetData().Difficulties[(int)ChosenDifficulty];

    public bool KingSlimeMode;

    public GameData(DifficultyTypes pDifficulty, bool pKingSlimeMode)
    {
        ChosenDifficulty = pDifficulty;
        KingSlimeMode = pKingSlimeMode;
    }
}

