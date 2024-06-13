using UnityEngine.Events;

/*
Main Layer of communication between seperate systems
*/
public static class EventManager
{
    public static UnityAction<ButtonTypes> ButtonPressed;
    public static void RaiseButtonPressed(ButtonTypes pButtonType) => ButtonPressed.Invoke(pButtonType);

    public static UnityAction<ScreenTypes> EnableScreen;
    public static UnityAction<ScreenTypes> DisableScreen;
    public static void RaiseEnableScreen(ScreenTypes pScreenType) => EnableScreen.Invoke(pScreenType);
    public static void RaiseDisableScreen(ScreenTypes pScreenType) => DisableScreen.Invoke(pScreenType);
}
