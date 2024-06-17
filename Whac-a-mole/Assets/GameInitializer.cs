using UnityEngine;

/*
Script Responsible for firing off the screen states and setting up the Databases.
*/
public class GameInitializer : MonoBehaviour
{
    void Start()
    {
        HighScoreDataBase.Initialize(new PersistantDataPathPusher(), new PersistantDataPathFetcher());
        SettingsDataBase.Initialize(new PersistantDataPathPusher(), new PersistantDataPathFetcher());

        if(SettingsDataBase.FetchData(out GameSettings pSettings) == false)//If there is no settings file, create one
        {
            SettingsDataBase.PushData(new GameSettings());
        }

        ScreenSwitcher switcher = new ScreenSwitcher();
        switcher.SetNextScreen(ScreenTypes.StartScreen);
        switcher.SwitchScreens(new GameData());
        Destroy(this);
    }
}
