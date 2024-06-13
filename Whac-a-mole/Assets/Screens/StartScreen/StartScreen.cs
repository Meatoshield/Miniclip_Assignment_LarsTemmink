public class StartScreen : IGameScreen
{
    private ScreenSwitcher _switcher = null;

    public bool TryEnable()
    {
        return true;
    }

    public void OnEnable(ScreenSwitcher pScreenSwitcher)
    {
        _switcher = pScreenSwitcher;

        EventManager.RaiseEnableScreen(ScreenTypes.StartScreen);

        EventManager.ButtonPressed += OnButtonPressed;
    }

    public void OnDisable()
    {
        _switcher = null;

        EventManager.RaiseDisableScreen(ScreenTypes.StartScreen);

        EventManager.ButtonPressed -= OnButtonPressed;
    } 

    public void OnButtonPressed(ButtonTypes pButtonType)
    {
        switch (pButtonType)
        {
            case ButtonTypes.Start:
                _switcher.SetNextScreens(new ScreenTypes[2] { ScreenTypes.DifficultyScreen, ScreenTypes.PlayScreen });
                _switcher.SwitchScreens();
                return;
            case ButtonTypes.ShowScore:
                _switcher.SetNextScreens(new ScreenTypes[2] { ScreenTypes.DifficultyScreen, ScreenTypes.ScoreScreen });
                _switcher.SwitchScreens();
                return;
        }
    }
}
