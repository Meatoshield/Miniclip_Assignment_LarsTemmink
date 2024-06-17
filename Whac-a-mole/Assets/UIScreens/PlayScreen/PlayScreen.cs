using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Screen where Whac-a-Mole is played.
/// </summary>
public class PlayScreen : IGameScreen
{
    private GameData _data;

    private ScreenSwitcher _switcher = null;

    private GameRunner _gameRunner = null;

    public bool TryEnable(ScreenTypes pCurrentScreen)
    {
        if (pCurrentScreen == ScreenTypes.DifficultyScreen)
        {
            return true;
        }

        return false;
    }

    public void OnEnable(ScreenSwitcher pScreenSwitcher, GameData pGameData)
    {
        _switcher = pScreenSwitcher;
        _data = pGameData;

        GameObject _gameRunnerObject = new GameObject("GameRunner");
        _gameRunner = _gameRunnerObject.AddComponent<GameRunner>();
        _gameRunner.Initialize(_data.ChosenDifficultySettings, _data.KingMoleMode);

        EventManager.PointsScored += PointsScored;
        EventManager.RequestScore += ScoreRequested;

        DataStreamer.StreamGameTimer += TimerDataStreamed;

        EventManager.RaiseEnableScreen(ScreenTypes.PlayScreen);
    }

    public void OnDisable()
    {
        _gameRunner.Deconstruct();
        GameObject.Destroy(_gameRunner);

        EventManager.PointsScored -= PointsScored;
        EventManager.RequestScore -= ScoreRequested;

        DataStreamer.StreamGameTimer -= TimerDataStreamed;

        EventManager.RaiseDisableScreen(ScreenTypes.PlayScreen);
    }

    private void PointsScored(int pPointsScored)
    {
        _data.Score += pPointsScored;
        DataStreamer.RaiseStreamScoreChange(_data.Score);
    }

    private void ScoreRequested(UnityAction<int> pCallback)
    {
        pCallback.Invoke(_data.Score);
    }

    public void TimerDataStreamed(float pTimerValue)
    {
        if (pTimerValue <= 0.0f)
        {
            _switcher.SetNextScreen(ScreenTypes.EndPlayScreen);
            _switcher.SwitchScreens(_data);
        }
    }
}
