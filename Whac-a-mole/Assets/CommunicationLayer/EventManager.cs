using UnityEngine.Events;

/// <summary>
/// This script in the communication layer for firing events between systems.
/// </summary>
public static class EventManager
{
    public static UnityAction<ButtonTypes> ButtonPressed;
    public static void RaiseButtonPressed(ButtonTypes pButtonType) => ButtonPressed?.Invoke(pButtonType);

    public static UnityAction<ScreenTypes> EnableScreen;
    public static UnityAction<ScreenTypes> DisableScreen;
    public static void RaiseEnableScreen(ScreenTypes pScreenType) => EnableScreen?.Invoke(pScreenType);
    public static void RaiseDisableScreen(ScreenTypes pScreenType) => DisableScreen?.Invoke(pScreenType);

    public static UnityAction<ScreenTypes> ScreenEnabled;
    public static UnityAction<ScreenTypes> ScreenDisabled;
    public static void RaiseScreenEnabled(ScreenTypes pScreenType) => ScreenEnabled?.Invoke(pScreenType);
    public static void RaiseScreenDisabled(ScreenTypes pScreenType) => ScreenDisabled?.Invoke(pScreenType);

    public static UnityAction RequestScore;
    public static UnityAction<int> SendScore;
    public static void RaiseRequestScore() => RequestScore?.Invoke();
    public static void RaiseSendScore(int pScore) => SendScore?.Invoke(pScore);

}
