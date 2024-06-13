using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEventTrigger : MonoBehaviour
{
    public ButtonTypes ButtonType = ButtonTypes.Start;
    
    private Button _triggerButton = null;

    public void Start()
    {
        _triggerButton = GetComponent<Button>();

        if(_triggerButton == null)
        {
            Destroy(this);
            return;
        }

        _triggerButton.onClick.AddListener(RaiseButtonPressed);
    }

    public void OnDestroy()
    {
        _triggerButton.onClick.RemoveListener(RaiseButtonPressed);
    }

    public void RaiseButtonPressed()
    {
        EventManager.RaiseStartButtonPressed(ButtonType);
    }
}
