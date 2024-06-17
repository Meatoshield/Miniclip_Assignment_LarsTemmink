using UnityEngine;


/// <summary>
/// Basic mole class, Updates the lifeTime of the mole and calculates the scored points when the mole is clicked
/// </summary>
public class Mole : PoolableComponent
{
    private GameObject _hole = null;
    public GameObject Hole => _hole;

    private float _totalLifeTime = 0.0f;
    protected float TimeUntilDeath = 0.0f;
    public bool IsDead => TimeUntilDeath <= 0.0f;

    public void Spawn(float pMoleLifeTime, GameObject pHole)
    {
        _hole = pHole;

        _totalLifeTime = TimeUntilDeath = pMoleLifeTime;

        transform.position = _hole.transform.position;

        gameObject.SetActive(true);
    }

    public void Update()
    {
        TimeUntilDeath -= Time.deltaTime;

        CheckMoleDeath();
    }

    private void OnMouseDown()
    {
        EventManager.RaisePointsScored(CalculateScoredPoints());

        TimeUntilDeath = 0.0f;
    }

    protected virtual void CheckMoleDeath()
    {
        if (TimeUntilDeath <= 0.0f)
        {
            gameObject.SetActive(false);
        }
    }

    protected virtual int CalculateScoredPoints()
    {
        //faster click equals more points
        return Mathf.RoundToInt(TimeUntilDeath / _totalLifeTime * 100.0f);
    }
}
