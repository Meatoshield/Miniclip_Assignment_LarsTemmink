using UnityEngine;
using UnityEngine.Events;
using TMPro;

/// <summary>
/// Script that empties the inputfield when screen is closed
/// </summary>
public class PlayerNameInputField : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _inputField = null;

    public void OnEnable()
    {
        EventManager.RequestPlayerName += SendBackPlayerName;  
    }

    public void OnDisable()
    {
        EventManager.RequestPlayerName -= SendBackPlayerName;
        _inputField.text = string.Empty;
    }

    private void SendBackPlayerName(UnityAction<string> pCallback)
    {
        pCallback.Invoke(_inputField.text);
    }
}
