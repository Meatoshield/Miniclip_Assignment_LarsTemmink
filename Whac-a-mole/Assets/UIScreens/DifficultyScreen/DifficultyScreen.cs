/// <summary>
/// In this screen the player chooses his difficulty. 
/// It either switches to the PlayScreen or the ScoreScreen depending on the switch sequence.
/// </summary>
public class DifficultyScreen : IGameScreen
{
    private ScreenSwitcher _switcher = null;

    public GameData Data { get; private set; }

    public bool TryEnable(ScreenTypes pCurrentScreen)
    {
        if (pCurrentScreen == ScreenTypes.StartScreen)
        {
            return true;
        }

        return false;
    }

    public void OnEnable(ScreenSwitcher pScreenSwitcher, GameData pGameData)
    {
        _switcher = pScreenSwitcher;
        Data = pGameData;

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
                Data = new GameData(DifficultyTypes.Easy, false);
                _switcher.SwitchScreens();
                return;
            case ButtonTypes.Medium:
                Data = new GameData(DifficultyTypes.Medium, false);
                _switcher.SwitchScreens();
                return;
            case ButtonTypes.Hard:
                Data = new GameData(DifficultyTypes.Hard, false);
                _switcher.SwitchScreens();
                return;
        }
    }
}
