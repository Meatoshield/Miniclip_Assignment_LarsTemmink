/// <summary>
/// Screen where the player fills in his name for the highScore list
/// </summary>
public class EndPlayScreen : IGameScreen
{
    private ScreenSwitcher _switcher = null;

    public GameData Data { get; private set; }

    public bool TryEnable(ScreenTypes pCurrentScreen)
    {
        if (pCurrentScreen == ScreenTypes.PlayScreen)
        {
            return true;
        }

        return false;
    }

    public void OnEnable(ScreenSwitcher pScreenSwitcher, GameData pGameData)
    {
        _switcher = pScreenSwitcher;
        Data = pGameData;

        EventManager.ButtonPressed += OnButtonPressed;
        EventManager.RequestScore += ScoreRequested;

        EventManager.RaiseEnableScreen(ScreenTypes.EndPlayScreen);
    }

    public void OnDisable()
    {
        _switcher = null;

        EventManager.ButtonPressed -= OnButtonPressed;
        EventManager.RequestScore -= ScoreRequested;

        EventManager.RaiseDisableScreen(ScreenTypes.EndPlayScreen);
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

    private void ScoreRequested()
    {
        EventManager.RaiseSendScore(Data.Score);
    }
}
