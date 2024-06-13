using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int _Score = 0;

    public void Start()
    {
        EventManager.RequestScore += ScoreRequested;

        _Score = Random.Range(0, 99999);
        EventManager.RaiseSendScore(_Score);
    }

    public void OnDestroy()
    {
        EventManager.RequestScore -= ScoreRequested;
    }

    private void ScoreRequested()
    {
        EventManager.RaiseSendScore(_Score);
    }
}
