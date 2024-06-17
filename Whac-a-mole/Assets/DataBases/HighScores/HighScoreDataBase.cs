
/// <summary>
/// Responsible for storing and retrieving the highscore lists.
/// </summary>
public static class HighScoreDataBase
{
    private static IDataPusher _dataPusher = null;
    private static IDataFetcher _dataFetcher = null;

    private const string _folderName = "HighScores";

    public static void Initialize(IDataPusher pDataPusher, IDataFetcher pDataFetcher)
    {
        _dataPusher = pDataPusher;
        _dataFetcher = pDataFetcher;
    }

    public static void PushData(HighScores pHighScores, DifficultyTypes pDifficultySetting, bool pKingMoleMode)
    {
        _dataPusher.PushData(pHighScores, _folderName, GetFileName(pDifficultySetting, pKingMoleMode));
    }

    public static bool FetchData(out HighScores pHighScores, DifficultyTypes pDifficultySetting, bool pKingMoleMode)
    {
        return _dataFetcher.FetchData(out pHighScores, _folderName, GetFileName(pDifficultySetting, pKingMoleMode));
    }

    //Gets the file name of the highscore list based on the chosen settings in the difficulty screen
    private static string GetFileName(DifficultyTypes pDifficultySetting, bool pKingMoleMode)
    {
        if (pKingMoleMode == true)
        {
            return $"{pDifficultySetting}_KingMoleMode";
        }

        return pDifficultySetting.ToString();
    }
}
