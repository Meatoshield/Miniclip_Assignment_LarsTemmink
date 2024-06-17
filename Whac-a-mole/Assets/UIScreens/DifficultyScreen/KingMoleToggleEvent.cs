using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class KingMoleToggleEvent : MonoBehaviour
{
    [SerializeField]
    private Toggle _kingMoleModeToggle = null;

    public void Start()
    {
        if (_kingMoleModeToggle == null)
        {
            Destroy(this);
            return;
        }
    }

    private void OnEnable()
    {
        EventManager.RequestKingMoleMode += KingMoleModeRequested;
    }

    private void OnDisable()
    {
        EventManager.RequestKingMoleMode -= KingMoleModeRequested;
    }

    private void KingMoleModeRequested(UnityAction<bool> pCallback)
    {
        pCallback.Invoke(_kingMoleModeToggle.isOn);
    }
}
