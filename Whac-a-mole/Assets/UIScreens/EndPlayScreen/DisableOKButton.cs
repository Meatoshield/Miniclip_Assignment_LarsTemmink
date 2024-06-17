using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script in charge of disabling the OK Button when the Username is not filled in.
/// </summary>
public class DisableOKButton : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _inputField = null;

    [SerializeField]
    private Button _Button = null;

    private void Start()
    {
        if (_inputField == null || _Button == null)
        {
            Destroy(this);
            return;
        }

        _inputField.onValueChanged.AddListener(OnInputChanged);
    }

    private void OnEnable()
    {
        _Button.interactable = false;
    }

    private void OnInputChanged(string pText)
    {
        if (string.IsNullOrEmpty(pText) == true)
        {
            _Button.interactable = false;
            return;
        }

        _Button.interactable = true;
    }
}
