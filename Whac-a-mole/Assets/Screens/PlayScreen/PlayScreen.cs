using UnityEngine;

public class PlayScreen : IGameScreen
{
    private ScreenSwitcher _switcher = null;

    private GameRunner _GameRunner = null;

    public bool TryEnable(ScreenTypes pCurrentScreen)
    {
        if (pCurrentScreen == ScreenTypes.DifficultyScreen)
        {
            return true;
        }

        return false;
    }

    public void OnEnable(ScreenSwitcher pScreenSwitcher)
    {
        _switcher = pScreenSwitcher;

        EventManager.RaiseEnableScreen(ScreenTypes.PlayScreen);

        if(_GameRunner != null)
        {
            //There shouldn't be a GameRunner at this point but lets be very sure
            MonoBehaviour.Destroy(_GameRunner);
            _GameRunner = null;
        }

        GameObject gameRunnerObject = new GameObject("GameRunner");
        _GameRunner = gameRunnerObject.AddComponent<GameRunner>();

        EventManager.ScreenDisabled += OnScreenDisabled;

        DataStreamer.StreamGameTimer += TimerDataStreamed;
    }

    public void OnDisable()
    {
        EventManager.RaiseDisableScreen(ScreenTypes.PlayScreen);

        DataStreamer.StreamGameTimer -= TimerDataStreamed;
    }

    private void OnScreenDisabled(ScreenTypes pDisabledScreen)
    {
        if(pDisabledScreen == ScreenTypes.EndPlayScreen)
        {
            MonoBehaviour.Destroy(_GameRunner);
            _GameRunner = null;
        }
    }

    private void PlayStops()
    {
        _switcher.SetNextScreen(ScreenTypes.EndPlayScreen);
        _switcher.SwitchScreens();
    }

    public void TimerDataStreamed(float pTimerValue)
    {
        if (pTimerValue <= 0.0f)
        {
            PlayStops();
        }
    }
}
