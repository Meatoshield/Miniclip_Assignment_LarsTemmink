using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayScreen : IGameScreen
{
    public bool TryEnable()
    {
        return true;
    }

    public void OnEnable(ScreenSwitcher pScreenSwitcher)
    {
    }

    public void OnDisable()
    {
    }
}
