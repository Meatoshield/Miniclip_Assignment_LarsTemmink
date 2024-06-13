using UnityEngine;

public class ScreenEnabler : MonoBehaviour
{
    public ScreenTypes ScreenType = ScreenTypes.StartScreen;

    [SerializeField]
    public GameObject screenContent = null;

    public void Awake()
    {
        EventManager.EnableScreen += EnableContent;
        EventManager.DisableScreen += DisableContent;
    }

    public void OnDestroy()
    {
        EventManager.EnableScreen -= EnableContent;
        EventManager.DisableScreen -= DisableContent;
    }

    private void EnableContent(ScreenTypes pScreenType)
    {
        if (pScreenType == ScreenType)
        {
            screenContent.SetActive(true);
        }
    }

    private void DisableContent(ScreenTypes pScreenType)
    {
        if (pScreenType == ScreenType)
        {
            screenContent.SetActive(false);
        }
    }
}
