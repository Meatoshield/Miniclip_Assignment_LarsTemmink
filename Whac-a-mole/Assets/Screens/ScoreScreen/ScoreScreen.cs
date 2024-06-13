using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScreen : IGameScreen
{
    private ScreenSwitcher _switcher = null;

    public bool TryEnable(ScreenTypes pCurrentScreen)
    {
        if (pCurrentScreen == ScreenTypes.DifficultyScreen || pCurrentScreen == ScreenTypes.EndPlayScreen)
        {
            return true;
        }

        return false;
    }

    public void OnEnable(ScreenSwitcher pScreenSwitcher)
    {
        _switcher = pScreenSwitcher;

        EventManager.RaiseEnableScreen(ScreenTypes.ScoreScreen);

        EventManager.ButtonPressed += OnButtonPressed;
    }

    public void OnDisable()
    {
        _switcher = null;

        EventManager.RaiseDisableScreen(ScreenTypes.ScoreScreen);

        EventManager.ButtonPressed -= OnButtonPressed;
    }

    public void OnButtonPressed(ButtonTypes pButtonType)
    {
        switch (pButtonType)
        {
            case ButtonTypes.StartMenu:
                _switcher.SetNextScreen(ScreenTypes.StartScreen);
                _switcher.SwitchScreens();
                return;
        }
    }
}
