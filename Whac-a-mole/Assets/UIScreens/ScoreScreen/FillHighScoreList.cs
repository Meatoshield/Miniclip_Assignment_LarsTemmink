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
    }

    public void OnEnable()
    {

    }

    public void OnDisable()
    {

    }

    public void SetHighScores()
    {
    }
}
