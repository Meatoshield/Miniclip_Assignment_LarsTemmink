/// <summary>
/// Class that saves and stores the game settings.
/// </summary>
public static class SettingsDataBase
{
    private static IDataPusher _dataPusher = null;
    private static IDataFetcher _dataFetcher = null;

    private const string _folderName = "GameSettings";
    private const string _fileName = "Settings";

    private static GameSettings _settingsInstance = null;

    public static void Initialize(IDataPusher pDataPusher, IDataFetcher pDataFetcher)
    {
        _dataPusher = pDataPusher;
        _dataFetcher = pDataFetcher;
    }

    public static void PushData(GameSettings pSettings)
    {
        if (_dataPusher.PushData(pSettings, _folderName, _fileName) == true)
        {
            _settingsInstance = pSettings;
        }
    }

    public static bool FetchData(out GameSettings pSettings)
    {
        if (_settingsInstance != null)
        {
            pSettings = _settingsInstance;
            return true;
        }

        bool result = _dataFetcher.FetchData(out pSettings, _folderName, _fileName);

        if (result == true)
        {
            _settingsInstance = pSettings;
            return true;
        }

        return false;
    }
}
