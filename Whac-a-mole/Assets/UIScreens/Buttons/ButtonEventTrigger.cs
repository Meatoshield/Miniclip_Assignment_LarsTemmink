using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script listens to button click and fires off an button click event.
/// </summary>
public class ButtonEventTrigger : MonoBehaviour
{
    public ButtonTypes ButtonType = ButtonTypes.Start;
    
    [SerializeField]
    private Button triggerButton = null;

    public void Start()
    {
        if(triggerButton == null)
        {
            Destroy(this);
            return;
        }

        triggerButton.onClick.AddListener(RaiseButtonPressed);
    }

    public void OnDestroy()
    {
        triggerButton.onClick.RemoveListener(RaiseButtonPressed);
    }

    public void RaiseButtonPressed()
    {
        EventManager.RaiseButtonPressed(ButtonType);
    }
}
