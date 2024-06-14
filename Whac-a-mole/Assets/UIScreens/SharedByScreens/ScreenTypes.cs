/// <summary>
/// all screens(game states) used in the game.
/// </summary>
public enum ScreenTypes
{
    StartScreen = 0, 
    DifficultyScreen = 1,
    PlayScreen = 2,
    EndPlayScreen = 3,
    ScoreScreen = 4,
    NumberOfScreens = 5, //You could also use Enum.GetNames(typeof(ScreenTypes)).Length instead. 
    None = 6
}
