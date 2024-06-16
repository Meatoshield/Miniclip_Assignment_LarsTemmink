/// <summary>
/// First screen in the game, options to play or show score.
/// </summary>
public class StartScreen : IGameScreen
{
    private ScreenSwitcher _switcher = null;

    public GameData Data { get; private set; }

    public bool TryEnable(ScreenTypes pCurrentScreen)
    {
        return true;
    }

    public void OnEnable(ScreenSwitcher pScreenSwitcher, GameData pGameData)
    {
        _switcher = pScreenSwitcher;
        Data = pGameData;

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
                _switcher.SetNextScreens(new ScreenTypes[2] { ScreenTypes.DifficultyScreen, ScreenTypes.PlayScreen }); //creating a switch sequence to go to PlayScreen
                _switcher.SwitchScreens();
                return;
            case ButtonTypes.ShowScore:
                _switcher.SetNextScreens(new ScreenTypes[2] { ScreenTypes.DifficultyScreen, ScreenTypes.ScoreScreen }); //creating a switch sequence to go to ScoreScreen
                _switcher.SwitchScreens();
                return;
        }
    }
}
