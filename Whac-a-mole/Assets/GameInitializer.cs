using UnityEngine;

/*
Only has one responsibility: firing off the state manager
*/
public class GameInitializer : MonoBehaviour
{
    void Start()
    {
        HighScoreDataBase.Initialize(new PersistantDataPathPusher(), new PersistantDataPathFetcher());

        ScreenSwitcher switcher = new ScreenSwitcher();
        switcher.SetNextScreen(ScreenTypes.StartScreen);
        switcher.SwitchScreens();
        Destroy(this);
    }
}
