
/// <summary>
/// Interface for the screens(game states), should expose functionality for enabling and disabling the screens.
/// </summary>
public interface IGameScreen
{
    public bool TryEnable(ScreenTypes pCurrentScreen);
    public void OnEnable(ScreenSwitcher pScreenSwitcher);
    public void OnDisable();
}
