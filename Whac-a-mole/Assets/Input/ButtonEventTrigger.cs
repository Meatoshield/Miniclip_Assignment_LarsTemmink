using UnityEngine;
using UnityEngine.UI;
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
