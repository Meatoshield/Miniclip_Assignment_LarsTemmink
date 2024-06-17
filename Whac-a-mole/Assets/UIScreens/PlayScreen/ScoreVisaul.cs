using TMPro;
using UnityEngine;

/// <summary>
/// Script in charge of displaying the Score in the UI.
/// </summary>
public class ScoreVisaul : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText = null;

    [SerializeField]
    private bool requestScoreOnEnable = false;

    private void Awake()
    {
        if (scoreText == null)
        {
            Destroy(this);
            return;
        }

        DataStreamer.StreamScoreChange += ScoreChanged;
    }

    private void OnEnable()
    {
        if(requestScoreOnEnable == true)
        {
            EventManager.RaiseRequestScore(ScoreChanged);
        }
    }

    public void OnDestroy()
    {
        DataStreamer.StreamScoreChange -= ScoreChanged;
    }

    public void ScoreChanged(int pScore)
    {
        scoreText.text = $"SCORE: {pScore}";
    }
}
