using TMPro;
using UnityEngine;

/// <summary>
/// Script in charge of displaying the Score in the UI.
/// </summary>
public class ScoreVisaul : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _scoreText = null;

    [SerializeField]
    private bool _requestScoreOnEnable = false;

    private void Awake()
    {
        if (_scoreText == null)
        {
            Destroy(this);
            return;
        }

        DataStreamer.StreamScoreChange += ScoreChanged;
    }

    private void OnEnable()
    {
        if (_requestScoreOnEnable == true)
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
        _scoreText.text = $"SCORE: {pScore}";
    }
}
