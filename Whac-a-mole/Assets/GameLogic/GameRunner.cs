using UnityEngine;

public class GameRunner : MonoBehaviour
{
    private MoleSystem _moleSystem = null;

    private float _timer = 30.0f;

    public void Initialize(DifficultySettings pChosenDifficultySettings, bool pKingMoleMode)
    {
        ComponentPool<Mole> _molePool = new ComponentPool<Mole>(4, PrefabStore.Instance.MolePrefab);
        GameObjectPool _holePool = new GameObjectPool(pChosenDifficultySettings.HoleCount, PrefabStore.Instance.HolePrefab);

        _moleSystem = new MoleSystem(pChosenDifficultySettings, pKingMoleMode, _molePool, _holePool);
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
