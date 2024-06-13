using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : IGameScreen
{
    private ScreenSwitcher screenSwitcher = null;

    public bool TryEnable()
    {
        return true;
    }

    public void OnEnable(ScreenSwitcher pScreenSwitcher)
    {
        screenSwitcher = pScreenSwitcher;

        EventManager.RaiseEnableScreen(ScreenTypes.StartScreen);

        EventManager.ButtonPressed += OnButtonPressed;
    }

    public void OnDisable()
    {
        screenSwitcher = null;

        EventManager.RaiseDisableScreen(ScreenTypes.StartScreen);

        EventManager.ButtonPressed -= OnButtonPressed;
    } 

    public void OnButtonPressed(ButtonTypes pButtonType)
    {
        switch (pButtonType)
        {
            case ButtonTypes.Start:
                screenSwitcher.SwitchScreens(ScreenTypes.DifficultyScreen); // next = ScreenTypes.PlayScreen
                return;
            case ButtonTypes.ShowScore:
                screenSwitcher.SwitchScreens(ScreenTypes.DifficultyScreen); // next = ScreenTypes.ScoreScreen
                return;
        }
    }
}
