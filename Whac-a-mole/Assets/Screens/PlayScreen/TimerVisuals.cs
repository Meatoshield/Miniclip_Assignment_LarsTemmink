using TMPro;
using UnityEngine;

public class TimerVisuals : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _timerText = null;

    private void Awake()
    {
        if (_timerText == null)
        {
            Destroy(this);
            return;
        }

        DataStreamer.StreamGameTimer += TimerDataStreamed;
    }

    public void OnDestroy()
    {
        DataStreamer.StreamGameTimer -= TimerDataStreamed;
    }

    public void TimerDataStreamed(float pTimerValue)
    { 
        _timerText.text = pTimerValue.ToString("0.0"); //Could also do something like Mathf.Round(pTimerValue * 10) / 10.0f;
    }
}
