using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager
{
    private int _Score = 0;

    public void Subscribe()
    {
        EventManager.RequestScore += ScoreRequested;
    }

    public void Unsubscribe()
    {
        EventManager.RequestScore -= ScoreRequested;
    }

    private void ScoreRequested()
    {
        EventManager.RaiseSendScore(_Score);
    }
}
