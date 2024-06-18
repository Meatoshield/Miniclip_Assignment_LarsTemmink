using UnityEngine;
using UnityEngine.Events;

public struct SpawnData
{
    public DifficultySettings DifficultySettings { get; }
    public bool KingMoleMode { get; }
    public IObjectPool<PoolableComponent> MolePool { get; }
    public IObjectPool<GameObject> HolePool { get; }
    public UnityAction<Mole> FreeElementCallback { get; private set; }

    public SpawnData(DifficultySettings pDifficultySettings, 
                     bool pKingMoleMode, 
                     IObjectPool<PoolableComponent> pMolePool,
                     IObjectPool<GameObject> pHolePool,
                     UnityAction<Mole> pFreeElementCallback = null)
    {
        DifficultySettings = pDifficultySettings;
        KingMoleMode = pKingMoleMode;
        MolePool = pMolePool;
        HolePool = pHolePool;
        FreeElementCallback = pFreeElementCallback;
    }

    public void SetFreeElementCallback(UnityAction<Mole> pCallback)
    {
        FreeElementCallback = pCallback;
    }
}
