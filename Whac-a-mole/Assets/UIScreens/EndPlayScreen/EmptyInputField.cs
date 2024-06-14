using UnityEngine;
using TMPro;

/// <summary>
/// Script that empties the inputfield when screen is closed
/// </summary>
public class EmptyInputField : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _inputField = null;
    public void OnDisable()
    {
        _inputField.text = string.Empty;
    }
}
