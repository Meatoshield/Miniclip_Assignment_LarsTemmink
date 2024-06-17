using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingMole : Mole
{
    //TODO: Free Hole

    protected override int CalculateScoredPoints()
    {
        return base.CalculateScoredPoints() * 3;
    }
}
