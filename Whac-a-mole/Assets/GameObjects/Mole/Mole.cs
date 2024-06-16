using UnityEngine;

public class Mole : PoolableComponent
{
    private GameObject _hole = null;
    public GameObject Hole => _hole;

    private float _timeUntilDeath = 0.0f;

    public bool IsDead => _timeUntilDeath <= 0.0f;

    public void Spawn(GameData pCurrentGameData, GameObject pHole)
    {
        _hole = pHole;

        _timeUntilDeath = pCurrentGameData.ChosenDifficultySettings.MoleLifeTime;

        transform.position = _hole.transform.position;

        gameObject.SetActive(true);
    }

    public void Update()
    {
        _timeUntilDeath -= Time.deltaTime;

        if (_timeUntilDeath <= 0.0f)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        _timeUntilDeath = 0.0f;

        //EventManager.RaiseMoleClicked();

        //return to the pool
    }
}
