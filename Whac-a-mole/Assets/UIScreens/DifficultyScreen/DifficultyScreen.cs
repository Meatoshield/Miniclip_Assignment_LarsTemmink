/// <summary>
/// In this screen the player chooses his difficulty. 
/// It either switches to the PlayScreen or the ScoreScreen depending on the switch sequence.
/// </summary>
public class DifficultyScreen : IGameScreen
{
    private ScreenSwitcher _switcher = null;

    private GameData _data;

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
        _data = pGameData;

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
        EventManager.RequestKingMoleMode(ReceiveKingMoleMode);

        switch (pButtonType)
        {
            case ButtonTypes.Easy:
                _data = new GameData(DifficultyTypes.Easy, _data.KingMoleMode);
                _switcher.SwitchScreens(_data);
                return;
            case ButtonTypes.Medium:
                _data = new GameData(DifficultyTypes.Medium, _data.KingMoleMode);
                _switcher.SwitchScreens(_data);
                return;
            case ButtonTypes.Hard:
                _data = new GameData(DifficultyTypes.Hard, _data.KingMoleMode);
                _switcher.SwitchScreens(_data);
                return;
        }
    }

    public void ReceiveKingMoleMode(bool pKingMoleMode)
    {
        _data.KingMoleMode = pKingMoleMode;
    }
}
