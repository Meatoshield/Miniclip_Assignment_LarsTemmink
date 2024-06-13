using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;
public static class EventManager
{
    public static UnityAction<ButtonTypes> ButtonPressed;
    public static void RaiseStartButtonPressed(ButtonTypes pButtonType) => ButtonPressed.Invoke(pButtonType);

    public static UnityAction<ScreenTypes> EnableScreen;
    public static UnityAction<ScreenTypes> DisableScreen;
    public static void RaiseEnableScreen(ScreenTypes pScreenType) => EnableScreen.Invoke(pScreenType);
    public static void RaiseDisableScreen(ScreenTypes pScreenType) => DisableScreen.Invoke(pScreenType);
}
