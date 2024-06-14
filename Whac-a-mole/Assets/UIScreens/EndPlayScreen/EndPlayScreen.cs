/// <summary>
/// Screen where the player fills in his name for the highScore list
/// </summary>
public class EndPlayScreen : IGameScreen
{
    private ScreenSwitcher _switcher = null;

    public bool TryEnable(ScreenTypes pCurrentScreen)
    {
        if (pCurrentScreen == ScreenTypes.PlayScreen)
        {
            return true;
        }

        return false;
    }

    public void OnEnable(ScreenSwitcher pScreenSwitcher)
    {
        _switcher = pScreenSwitcher;

        EventManager.RaiseEnableScreen(ScreenTypes.EndPlayScreen);

        EventManager.ButtonPressed += OnButtonPressed;
    }

    public void OnDisable()
    {
        _switcher = null;

        EventManager.RaiseDisableScreen(ScreenTypes.EndPlayScreen);

        EventManager.ButtonPressed -= OnButtonPressed;
    }

    public void OnButtonPressed(ButtonTypes pButtonType)
    {
        switch (pButtonType)
        {
            case ButtonTypes.Ok:
                //Save name & Score to Score list

                _switcher.SetNextScreen(ScreenTypes.ScoreScreen);
                _switcher.SwitchScreens();
                return;
        }
    }
}
