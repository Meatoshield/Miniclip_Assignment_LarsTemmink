using UnityEngine;

public class GameRunner : MonoBehaviour
{
    private GameData _currentGameData = null;

    private MoleSystem _moleSystem = null;

    ScoreManager _scoreManager = new ScoreManager();

    private bool _playing = false;

    public void Start()
    {
        _scoreManager.Subscribe();

        EventManager.EnableScreen += OnScreenEnabled;
        EventManager.ButtonPressed += OnButtonPressed;
    }

    public void OnDestroy()
    {
        _scoreManager.Unsubscribe();

        EventManager.EnableScreen -= OnScreenEnabled;
        EventManager.ButtonPressed -= OnButtonPressed;
    }

    public void OnScreenEnabled(ScreenTypes pScreenEnabled)
    {
        switch (pScreenEnabled)
        {
            case ScreenTypes.StartScreen:
                _currentGameData = null;
                return;
            case ScreenTypes.PlayScreen:
                StartPlaying();
                return;
            case ScreenTypes.EndPlayScreen:
                StopPlaying();
                return;
        }
    }

    public void OnButtonPressed(ButtonTypes pButtonPressed)
    {
        switch (pButtonPressed)
        {
            case ButtonTypes.Easy:
                _currentGameData = new GameData(DifficultyTypes.Easy, false);
                return;
            case ButtonTypes.Medium:
                _currentGameData = new GameData(DifficultyTypes.Medium, false);
                return;
            case ButtonTypes.Hard:
                _currentGameData = new GameData(DifficultyTypes.Hard, false);
                return;
        }
    }

    public void Update()
    {
        if (_playing == false)
        {
            return;
        }

        if (_currentGameData.Timer <= 0.0f)
        {
            _playing = false;
            return;
        }

        _moleSystem.UpdateSystem(_currentGameData);

        _currentGameData.Timer -= Time.deltaTime;
        DataStreamer.RaiseStreamGameTimer(_currentGameData.Timer);
    }

    public void StartPlaying()
    {
        _playing = true;

        ComponentPool<Mole> _molePool = new ComponentPool<Mole>(4, PrefabStore.Instance.MolePrefab);
        GameObjectPool _holePool = new GameObjectPool(_currentGameData.ChosenDifficultySettings.HoleCount, PrefabStore.Instance.HolePrefab);

        _moleSystem = new MoleSystem(_currentGameData, _molePool, _holePool);
    }

    public void StopPlaying()
    {
        _moleSystem.DestroyPoolitems();
        _moleSystem = null;
    }
}
