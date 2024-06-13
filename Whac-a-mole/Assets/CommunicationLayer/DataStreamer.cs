using UnityEngine.Events;

/*
For this game, the DataStreamer works the same as the EventManager
but it's still good to split up this functionality
*/
public static class DataStreamer
{
    public static UnityAction<float> StreamGameTimer;
    public static void RaiseStreamGameTimer(float pTimer) => StreamGameTimer.Invoke(pTimer);
}
