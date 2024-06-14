using UnityEngine;

public class GameRunner : MonoBehaviour
{
    [SerializeField]
    private GamePrefabs _gamePrefabs = null;

    [SerializeField]
    private GameSettings _gameSettings = null;

    private GameData _gameData = null;

    private HoleManager _holeManager = null;
    private MoleManager _moleManager = null;

    private MoleSpawner _moleSpawner = null;

    ScoreManager _scoreManager = new ScoreManager();

    private bool _playing = false;

    public void Start()
    {
        _scoreManager.Subscribe();

        EventManager.EnableScreen += OnScreenEnabled;
        EventManager.ButtonPressed += OnButtonPressed;
    }

    public void Update()
    {
        if(_playing == false)
        {
            return;
        }

        if (_gameData.Timer <= 0.0f)
        {
            _playing = false;
            return;
        }

        _gameData.Timer -= Time.deltaTime;
        DataStreamer.RaiseStreamGameTimer(_gameData.Timer);

        _moleSpawner.Update();

        if (_moleSpawner.ReadyToSpawnMole() == true)
        {
            _moleSpawner.TrySpawnMole();
        }
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
                _gameData = null;
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
                _gameData = new GameData(DifficultyTypes.Easy);
                return;
            case ButtonTypes.Medium:
                _gameData = new GameData(DifficultyTypes.Medium);
                return;
            case ButtonTypes.Hard:
                _gameData = new GameData(DifficultyTypes.Hard);
                return;
        }
    }

    public void StartPlaying()
    {
        DifficultySettings difficultySettings = _gameSettings.Difficulties[(int)_gameData.CurrentDifficulty];

        _holeManager = new HoleManager(_gamePrefabs.HolePrefab, difficultySettings);
        _moleManager = new MoleManager(_gamePrefabs.MolePrefab);

        HoleSpawner.PositionHoles(_holeManager.HolePool);

        _moleSpawner = new MoleSpawner();
        _moleSpawner.StartMoleSpawning(difficultySettings);

        _playing = true;
    }

    public void StopPlaying()
    {
        _holeManager.DestroyHoles();
        _holeManager = null;

        _moleManager.DestroyMoles();
        _moleManager = null;
    }
}
