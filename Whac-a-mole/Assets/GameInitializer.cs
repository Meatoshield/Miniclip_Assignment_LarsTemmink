using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    void Start()
    {
        ScreenSwitcher switcher = new ScreenSwitcher();
        switcher.SwitchScreens(ScreenTypes.StartScreen);
        Destroy(gameObject);
    }
}
