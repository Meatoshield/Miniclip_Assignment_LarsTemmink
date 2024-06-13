using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Only has one responsibility: firing off the state manager
*/
public class GameInitializer : MonoBehaviour
{
    void Start()
    {
        ScreenSwitcher switcher = new ScreenSwitcher();
        switcher.SetNextScreen(ScreenTypes.StartScreen);
        switcher.SwitchScreens();
        Destroy(gameObject);
    }
}
