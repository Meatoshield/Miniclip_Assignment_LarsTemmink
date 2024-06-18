using UnityEngine.Events;

/// <summary>
/// This script in the communication layer for firing events between systems.
/// </summary>
public static class EventManager
{
    // More Generic events for state switching and button pressing
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



    //Event requests, mostly to interact between logic and UI
    public static UnityAction<UnityAction<bool>> RequestKingMoleMode;
    public static void RaiseKingMoleMode(UnityAction<bool> pCallback) => RequestKingMoleMode?.Invoke(pCallback);

    public static UnityAction<UnityAction<int>> RequestScore;
    public static void RaiseRequestScore(UnityAction<int> pCallback) => RequestScore?.Invoke(pCallback);

    public static UnityAction<UnityAction<HighScores>> RequestHighScores;
    public static void RaiseRequestHighScores(UnityAction<HighScores> pCallback) => RequestHighScores?.Invoke(pCallback);

    public static UnityAction<UnityAction<string>> RequestPlayerName;
    public static void RaiseRequestPlayerName(UnityAction<string> pCallback) => RequestPlayerName?.Invoke(pCallback);


    //Events between logic
    public static UnityAction<int> PointsScored;
    public static void RaisePointsScored(int pScoredPoints) => PointsScored?.Invoke(pScoredPoints);
}
