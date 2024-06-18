using UnityEngine;

/// <summary>
/// System in charge of running the whac-a-mole game logic
/// </summary>
public class GameRunner : MonoBehaviour
{
    private MoleSystem _moleSystem = null;

    private float _timer = 30.0f;

    public void Initialize(DifficultySettings pChosenDifficultySettings, bool pKingMoleMode)
    {
        SettingsDataBase.FetchData(out GameSettings pSettings);
        _timer = pSettings.PlayTime;

        ComponentPool<Mole> _molePool = new ComponentPool<Mole>(4, PrefabStore.Instance.MolePrefab, new FirstElementGetter<PoolableComponent>());
        _molePool.GrowsDynamically = true;

        GameObjectPool _holePool = new GameObjectPool(pChosenDifficultySettings.HoleCount, PrefabStore.Instance.HolePrefab, new RandomElementGetter<GameObject>());

        SpawnData spawnData = new SpawnData(pChosenDifficultySettings, pKingMoleMode, _molePool, _holePool);
        _moleSystem = new MoleSystem(spawnData);
    }

    public void Deconstruct()
    {
        _moleSystem.Deconstruct();
        _moleSystem = null;
    }

    public void Update()
    {
        if (_timer <= 0.0f)
        {
            return;
        }

        _moleSystem.UpdateSystem();

        _timer -= Time.deltaTime;
        DataStreamer.RaiseStreamGameTimer(_timer);
    }
}
