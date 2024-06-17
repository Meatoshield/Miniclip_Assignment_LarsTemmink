public struct GameData
{
    public DifficultyTypes ChosenDifficulty;
    public DifficultySettings ChosenDifficultySettings => GetDifficultySettings();

    public bool KingMoleMode;

    public int Score;

    public GameData(DifficultyTypes pDifficulty = DifficultyTypes.Easy, bool pKingMoleMode = false)
    {
        ChosenDifficulty = pDifficulty;
        KingMoleMode = pKingMoleMode;

        Score = 0;
    }

    private DifficultySettings GetDifficultySettings()
    {
        SettingsDataBase.FetchData(out GameSettings pSettings);
        return pSettings.Difficulties[(int)ChosenDifficulty];
    }
}

