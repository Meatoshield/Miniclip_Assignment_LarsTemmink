using UnityEngine;

public class FillHighScoreList : MonoBehaviour
{
    private ScoreField[] _scoreFields = null;

    public void Start()
    {
        _scoreFields = new ScoreField[20];

        for (int i = 0; i < _scoreFields.Length; i++)
        {
            GameObject highScoreField = GameObject.Instantiate(PrefabStore.Instance.HighScoreFieldPrefab, transform);
            _scoreFields[i] = highScoreField.GetComponent<ScoreField>();
        }

        EventManager.RaiseRequestHighScores(ReceiveHighScores);
    }

    public void OnEnable()
    {
        EventManager.RaiseRequestHighScores(ReceiveHighScores);
    }

    public void OnDisable()
    {
        ResetHighScoreFields();
    }

    public void ReceiveHighScores(HighScores pHighScores)
    {
        for (int i = 0; i < pHighScores.HighestScores.Length; i++)
        {
            _scoreFields[i].NameText.text = pHighScores.HighestScores[i].Name;
            _scoreFields[i].ScoreText.text = $"SCORE: {pHighScores.HighestScores[i].Score}";
        }
    }

    public void ResetHighScoreFields()
    {
        for (int i = 0; i < _scoreFields.Length; i++)
        {
            _scoreFields[i].NameText.text = "------";
            _scoreFields[i].ScoreText.text = "SCORE: 0";
        }
    }
}
