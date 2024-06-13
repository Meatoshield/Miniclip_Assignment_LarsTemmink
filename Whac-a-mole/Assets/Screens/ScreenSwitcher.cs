using System.Collections.Generic;
using UnityEngine;

public class ScreenSwitcher
{
    private List<ScreenTypes> _nextScreens = new List<ScreenTypes>();

    private ScreenTypes _currentScreen = ScreenTypes.None;
    public ScreenTypes CurrentScreen => _currentScreen;

    private IGameScreen[] _screenInstances = new IGameScreen[(int)ScreenTypes.NumberOfScreens];

    public void SetNextScreen(ScreenTypes pNextScreen)
    {
        SetNextScreens(new ScreenTypes[1]{ pNextScreen });
    }

    public void SetNextScreens(ScreenTypes[] pNextScreens)
    { 
        if(ScreensContainForbiddenScreen(pNextScreens) == true)
        {
            Debug.LogError("Next screen(s) can't be set because one or more of the new screens are forbidden!");
            return;
        }

        if(pNextScreens == null || pNextScreens.Length == 0)
        {
            Debug.LogError("Next screen(s) not specified!");
            return;
        }

        _nextScreens.AddRange(pNextScreens);
    }

    public void SwitchScreens()
    {
        if (_nextScreens == null || _nextScreens.Count == 0)
        {
            Debug.LogError("Cant switch screens, there is no next screen!");
            return;
        }

        IGameScreen NextgameScreen = GetScreen(_nextScreens[0]);

        if (NextgameScreen.TryEnable() == false)
        {
            Debug.LogError($"Illegal State Switch on State {_currentScreen} to state {_nextScreens[0]}");
            return;
        }

        if(_currentScreen != ScreenTypes.None)
        {
            GetScreen(_currentScreen)?.OnDisable();
        }   

        _currentScreen = _nextScreens[0];
        _nextScreens.RemoveAt(0);

        NextgameScreen.OnEnable(this);
    }

    private IGameScreen GetScreen(ScreenTypes pScreenType)
    {
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

    private bool ScreensContainForbiddenScreen(ScreenTypes[] pScreensToCheck)
    {
        foreach(ScreenTypes type in pScreensToCheck)
        {
            if((int)type >= (int)ScreenTypes.NumberOfScreens) //if enum value is higher or equal to the value of NumberOfScreens it has to be forbidden
            {
                return true;
            }
        }

        return false;
    }
}
