using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisableOKButton : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField inputField = null;

    [SerializeField]
    private Button Button = null;

    private void Start()
    {
        if (inputField == null || Button == null)
        {
            Destroy(this);
            return;
        }

        inputField.onValueChanged.AddListener(OnInputChanged);
    }

    private void OnEnable()
    {
        Button.interactable = false;
    }

    private void OnInputChanged(string pText)
    {
        if(string.IsNullOrEmpty(pText) == true)
        {
            Button.interactable = false;
            return;
        }

        Button.interactable = true;
    }
}
