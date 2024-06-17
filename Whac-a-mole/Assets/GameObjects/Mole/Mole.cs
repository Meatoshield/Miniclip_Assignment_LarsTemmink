using UnityEngine;

public class Mole : PoolableComponent
{
    private GameObject _hole = null;
    public GameObject Hole => _hole;

    private float _lifeTime = 0.0f;
    private float _timeUntilDeath = 0.0f;
    public bool IsDead => _timeUntilDeath <= 0.0f;

    public void Spawn(float pMoleLifeTime, GameObject pHole)
    {
        _hole = pHole;

        _lifeTime = _timeUntilDeath = pMoleLifeTime;

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
        EventManager.RaisePointsScored(CalculateScoredPoints());

        _timeUntilDeath = 0.0f;
    }

    protected virtual int CalculateScoredPoints()
    {
        return Mathf.RoundToInt(_timeUntilDeath / _lifeTime * 100.0f);
    }
}
