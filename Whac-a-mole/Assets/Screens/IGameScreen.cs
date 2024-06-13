public interface IGameScreen
{
    public bool TryEnable();
    public void OnEnable(ScreenSwitcher pScreenSwitcher);
    public void OnDisable();
}
