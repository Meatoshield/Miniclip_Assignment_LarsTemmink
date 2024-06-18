using UnityEngine;
using System.Collections;


public class FillHighScoreList : MonoBehaviour
{
    private ScoreField[] _scoreFields = null;

    private bool _highscoresReceived = false;

    private Coroutine GetHighScoresRoutine = null;

    public void OnEnable()
    {
        GetHighScoresRoutine = StartCoroutine(TryReceiveHighScores());
    }

    public void OnDisable()
    {
        ResetHighScoreFields();

        if(GetHighScoresRoutine != null)
        {
            StopCoroutine(GetHighScoresRoutine);
        }
    }

    private IEnumerator TryReceiveHighScores()
    {
        while (_highscoresReceived == false)
        {        
            EventManager.RaiseRequestHighScores(ReceiveHighScores);
            yield return null; //Wait a frame
        }

        GetHighScoresRoutine = null;
    }

    public void ReceiveHighScores(HighScores pHighScores)
    {
        _scoreFields = new ScoreField[pHighScores.HighestScores.Length];

        for (int i = 0; i < _scoreFields.Length; i++)
        {
            GameObject highScoreField = GameObject.Instantiate(PrefabStore.Instance.HighScoreFieldPrefab, transform);
            _scoreFields[i] = highScoreField.GetComponent<ScoreField>();
        }

        for (int i = 0; i < pHighScores.HighestScores.Length; i++)
        {
            _scoreFields[i].NameText.text = pHighScores.HighestScores[i].Name;
            _scoreFields[i].ScoreText.text = $"SCORE: {pHighScores.HighestScores[i].Score}";
        }

        _highscoresReceived = true;
    }

    public void ResetHighScoreFields()
    {
        if(_scoreFields == null) 
        {
            return;
        }

        foreach(ScoreField pField in _scoreFields)
        {
            GameObject.Destroy(pField.gameObject);
        }

        _scoreFields = null;
        _highscoresReceived = false;
    }
}
