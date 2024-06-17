
/// <summary>
/// Small extensions of the mole class that add some extra functionality for the MoleKing
/// </summary>
public class KingMole : Mole
{
    protected override void CheckMoleDeath()
    {
        if (TimeUntilDeath <= 0.0f)
        {
            gameObject.SetActive(false);
            EventManager.RaiseMoleKingDied(this);
        }
    }

    protected override int CalculateScoredPoints()
    {
        int calculatedValue = base.CalculateScoredPoints();

        return calculatedValue * 5;
    }
}
