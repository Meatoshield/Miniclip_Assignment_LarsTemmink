public static class SettingsDataBase
{
    private static GameSettings _gameSettings = null;

    public static GameSettings GetData()
    {
        //Try load from disc

        if (_gameSettings == null)
        {
            _gameSettings = new GameSettings();
        }

        return _gameSettings;
    }

    public static void SaveData()
    {

    }
}
