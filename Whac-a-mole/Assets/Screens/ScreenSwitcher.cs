using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSwitcher
{
    private ScreenTypes _nextScreen = ScreenTypes.None;
    private ScreenTypes _currentScreen = ScreenTypes.None;
    private ScreenTypes _previousScreen = ScreenTypes.None;

    private IGameScreen[] _screenInstances = new IGameScreen[(int)ScreenTypes.NumberOfScreens];

    public void SwitchScreens(ScreenTypes pScreenType)
    {
        IGameScreen NextgameScreen = GetScreen(pScreenType);

        if (NextgameScreen.TryEnable() == false)
        {
            return;
        }

        GetScreen(_currentScreen)?.OnDisable();

        _previousScreen = _currentScreen;
        _currentScreen = pScreenType;

        NextgameScreen.OnEnable(this);
    }

    public IGameScreen GetScreen(ScreenTypes pScreenType)
    {
        if((int)pScreenType >= _screenInstances.Length)
        {
            return null;
        }

        IGameScreen screenType = _screenInstances[(int)pScreenType];

        return screenType != null ? screenType : CreateScreenInstance(pScreenType);
    }

    private IGameScreen CreateScreenInstance(ScreenTypes pScreenType)
    {
        switch (pScreenType)
        {
            case ScreenTypes.StartScreen:
                return _screenInstances[(int)pScreenType] = new StartScreen();
            case ScreenTypes.DifficultyScreen:
                return _screenInstances[(int)pScreenType] = new DifficultyScreen();
            case ScreenTypes.PlayScreen:
                return _screenInstances[(int)pScreenType] = new PlayScreen();
            case ScreenTypes.EndPlayScreen:
                return _screenInstances[(int)pScreenType] = new EndPlayScreen();
            case ScreenTypes.ScoreScreen:
                return _screenInstances[(int)pScreenType] = new ScoreScreen();
        }
        return null;
    }
}
