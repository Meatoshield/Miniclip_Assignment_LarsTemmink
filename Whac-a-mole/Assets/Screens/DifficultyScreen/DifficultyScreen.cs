using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyScreen : IGameScreen
{
    private ScreenSwitcher screenSwitcher = null;

    public bool TryEnable()
    {
        return true;
    }

    public void OnEnable(ScreenSwitcher pScreenSwitcher)
    {
        screenSwitcher = pScreenSwitcher;

        EventManager.RaiseEnableScreen(ScreenTypes.DifficultyScreen);

        //EventManager.ButtonPressed += OnButtonPressed;
    }

    public void OnDisable()
    {
        screenSwitcher = null;

        EventManager.RaiseDisableScreen(ScreenTypes.DifficultyScreen);

        //EventManager.ButtonPressed -= OnButtonPressed;
    }
}
