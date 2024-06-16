using UnityEngine;
/// <summary>
/// Screen where Whac-a-Mole is played.
/// </summary>
public class PlayScreen : IGameScreen
{
    public GameData Data { get; protected set; }

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
        Data = pGameData;

        GameObject _gameRunnerObject = new GameObject("GameRunner");
        _gameRunner = _gameRunnerObject.AddComponent<GameRunner>();
        _gameRunner.Initialize(Data.ChosenDifficultySettings, Data.KingMoleMode);

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

    private void PointsScored(int pScoredPoints)
    {
        GameData data = Data;
        data.Score += pScoredPoints;
        Data = data;

        DataStreamer.RaiseStreamScoreChange(Data.Score);
    }

    private void ScoreRequested()
    {
        EventManager.RaiseSendScore(Data.Score);
    }

    public void TimerDataStreamed(float pTimerValue)
    {
        if (pTimerValue <= 0.0f)
        {
            _switcher.SetNextScreen(ScreenTypes.EndPlayScreen);
            _switcher.SwitchScreens();
        }
    }
}
