using UnityEngine;
/// <summary>
/// Screen where Whac-a-Mole is played.
/// </summary>
public class PlayScreen : IGameScreen
{
    private ScreenSwitcher _switcher = null;

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

        DataStreamer.StreamGameTimer += TimerDataStreamed;
    }

    public void OnDisable()
    {
        EventManager.RaiseDisableScreen(ScreenTypes.PlayScreen);

        DataStreamer.StreamGameTimer -= TimerDataStreamed;
    }

    public void TimerDataStreamed(float pTimerValue)
    {
        if (pTimerValue <= 0.0f)
        {
            PlayStops();
        }
    }

    private void PlayStops()
    {
        _switcher.SetNextScreen(ScreenTypes.EndPlayScreen);
        _switcher.SwitchScreens();
    }
}
