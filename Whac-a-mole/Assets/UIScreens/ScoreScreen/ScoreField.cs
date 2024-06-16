using TMPro;
using UnityEngine;

public class ScoreField : MonoBehaviour
{
    [SerializeField]
    private TMP_Text nameText = null;
    public TMP_Text NameText => nameText;

    [SerializeField]
    private TMP_Text scoreText = null;
    public TMP_Text ScoreText => scoreText;
}
