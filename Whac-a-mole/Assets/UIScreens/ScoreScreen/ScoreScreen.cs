using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Screen where the highscore list is shown. 
/// </summary>
public class ScoreScreen : IGameScreen
{
    private ScreenSwitcher _switcher = null;
    private GameData _data;

    public bool TryEnable(ScreenTypes pCurrentScreen)
    {
        if (pCurrentScreen == ScreenTypes.DifficultyScreen || pCurrentScreen == ScreenTypes.EndPlayScreen)
        {
            return true;
        }

        return false;
    }

    public void OnEnable(ScreenSwitcher pScreenSwitcher, GameData pGameData)
    {
        _switcher = pScreenSwitcher;
        _data = pGameData;

        EventManager.RaiseEnableScreen(ScreenTypes.ScoreScreen);

        EventManager.ButtonPressed += OnButtonPressed;
        EventManager.RequestHighScores += HighScoreRequest;
    }

    public void OnDisable()
    {
        _switcher = null;

        EventManager.RaiseDisableScreen(ScreenTypes.ScoreScreen);

        EventManager.ButtonPressed -= OnButtonPressed;
    }

    private void OnButtonPressed(ButtonTypes pButtonType)
    {
        switch (pButtonType)
        {
            case ButtonTypes.StartMenu:
                _switcher.SetNextScreen(ScreenTypes.StartScreen);
                _switcher.SwitchScreens(new GameData());
                return;
        }
    }

    private void HighScoreRequest(UnityAction<HighScores> pCallback)
    {
        if (HighScoreDataBase.FetchData(out HighScores pHighScores, _data.ChosenDifficulty, _data.KingMoleMode) == true)
        {
            pCallback.Invoke(pHighScores);
            return;
        }

        //TODO: Show message on screen that highscore list is unavailable. 
        Debug.LogError("Can't show highscores because the data fetch failed!");
    }
}
