public class DifficultyScreen : IGameScreen
{
    private ScreenSwitcher _switcher = null;

    public bool TryEnable(ScreenTypes pCurrentScreen)
    {
        if(pCurrentScreen == ScreenTypes.StartScreen)
        {
            return true;
        }

        return false;
    }

    public void OnEnable(ScreenSwitcher pScreenSwitcher)
    {
        _switcher = pScreenSwitcher;

        EventManager.RaiseEnableScreen(ScreenTypes.DifficultyScreen);

        EventManager.ButtonPressed += OnButtonPressed;
    }

    public void OnDisable()
    {
        _switcher = null;

        EventManager.RaiseDisableScreen(ScreenTypes.DifficultyScreen);

        EventManager.ButtonPressed -= OnButtonPressed;
    }

    public void OnButtonPressed(ButtonTypes pButtonType)
    {
        switch (pButtonType)
        {
            case ButtonTypes.Easy:
            case ButtonTypes.Medium:
            case ButtonTypes.Hard:
                _switcher.SwitchScreens();
                return;
        }
    }
}
