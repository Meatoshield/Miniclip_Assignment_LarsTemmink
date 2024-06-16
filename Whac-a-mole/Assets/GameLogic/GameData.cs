public struct GameData
{
    public DifficultyTypes ChosenDifficulty;
    public DifficultySettings ChosenDifficultySettings => SettingsDataBase.GetData().Difficulties[(int)ChosenDifficulty];

    public bool KingMoleMode;

    public int Score;

    public GameData(DifficultyTypes pDifficulty = DifficultyTypes.Easy, bool pKingMoleMode = false)
    {
        ChosenDifficulty = pDifficulty;
        KingMoleMode = pKingMoleMode;

        Score = 0;
    }
}

