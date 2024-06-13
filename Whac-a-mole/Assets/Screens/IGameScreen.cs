public interface IGameScreen
{
    public bool TryEnable(ScreenTypes pCurrentScreen);
    public void OnEnable(ScreenSwitcher pScreenSwitcher);
    public void OnDisable();
}
