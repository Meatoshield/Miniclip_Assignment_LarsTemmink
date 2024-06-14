using UnityEngine.Events;

/// <summary>
/// This script in the communication layer for streaming data between systems.
/// For this game, the DataStreamer works the same as EventManager, but it's still good practice to seperate these two.
/// </summary>
public static class DataStreamer
{
    public static UnityAction<float> StreamGameTimer;
    public static void RaiseStreamGameTimer(float pTimer) => StreamGameTimer?.Invoke(pTimer);

    public static UnityAction<int> StreamScoreChange;
    public static void RaiseStreamScoreChange(int pScore) => StreamScoreChange?.Invoke(pScore);
}
