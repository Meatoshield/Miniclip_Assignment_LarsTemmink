using UnityEngine;

public class ScreenEnabler : MonoBehaviour
{
    public ScreenTypes ScreenType = ScreenTypes.StartScreen;
    public GameObject ScreenContent = null;

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
            ScreenContent.SetActive(true);
        }
    }

    private void DisableContent(ScreenTypes pScreenType)
    {
        if (pScreenType == ScreenType)
        {
            ScreenContent.SetActive(false);
        }
    }
}
