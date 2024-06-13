using UnityEngine;

public class PlayScreen : IGameScreen
{
    private ScreenSwitcher _switcher = null;

    private float _timer = 60f;
    private bool _enabled = false;

    public bool TryEnable()
    {
        if (_switcher.CurrentScreen == ScreenTypes.DifficultyScreen)
        {
            return true;
        }

        return false;
    }

    public void OnEnable(ScreenSwitcher pScreenSwitcher)
    {
        _enabled = true;

        _switcher = pScreenSwitcher;

        EventManager.RaiseEnableScreen(ScreenTypes.PlayScreen);

        StartGame();
    }

    public void OnDisable()
    {
        _enabled = false;

        EventManager.RaiseDisableScreen(ScreenTypes.PlayScreen);
    }

    public void Update()
    {
        if(_enabled == false)
        {
            return;
        }

        _timer -= Time.deltaTime;
        DataStreamer.RaiseStreamGameTimer(_timer);

        //No need to clamp the _timer here, players will never see it go below zero
        if (_timer <= 0.0f)
        {
            FinishGame();
        }
    }

    private void StartGame()
    {
        _timer = 60f;
        DataStreamer.RaiseStreamGameTimer(_timer);
    }

    private void FinishGame()
    {
        _switcher.SetNextScreen(ScreenTypes.EndPlayScreen);
        _switcher.SwitchScreens();
    }
}
