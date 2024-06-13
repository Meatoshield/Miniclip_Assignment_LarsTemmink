using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRunner : MonoBehaviour
{
    private float _timer = 5f;

    ScoreManager _scoreManager = null;

    public void Start()
    {
        _scoreManager = gameObject.AddComponent<ScoreManager>();
    }

    public void Update()
    {
        if (_timer <= 0.0f)
        {
            return;
        }

        _timer -= Time.deltaTime;
        DataStreamer.RaiseStreamGameTimer(_timer);
    }

    public void OnDestroy()
    {
        Destroy(_scoreManager);
    }
}
