using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public float Timer = 5.0f;

    public DifficultyTypes CurrentDifficulty;

    public GameData(DifficultyTypes pDifficulty)
    {
        CurrentDifficulty = pDifficulty;
    }
}
