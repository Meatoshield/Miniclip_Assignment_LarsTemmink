using System.Collections.Generic;
using UnityEngine.Events;

/// <summary>
/// Screen where the player fills in his name for the highScore list
/// </summary>
public class EndPlayScreen : IGameScreen
{
    private ScreenSwitcher _switcher = null;

    private GameData _data;

    public bool TryEnable(ScreenTypes pCurrentScreen)
    {
        if (pCurrentScreen == ScreenTypes.PlayScreen)
        {
            return true;
        }

        return false;
    }

    public void OnEnable(ScreenSwitcher pScreenSwitcher, GameData pGameData)
    {
        _switcher = pScreenSwitcher;
        _data = pGameData;

        EventManager.ButtonPressed += OnButtonPressed;
        EventManager.RequestScore += ScoreRequested;

        EventManager.RaiseEnableScreen(ScreenTypes.EndPlayScreen);
    }

    public void OnDisable()
    {
        _switcher = null;

        EventManager.ButtonPressed -= OnButtonPressed;
        EventManager.RequestScore -= ScoreRequested;

        EventManager.RaiseDisableScreen(ScreenTypes.EndPlayScreen);
    }

    private void OnButtonPressed(ButtonTypes pButtonType)
    {
        switch (pButtonType)
        {
            case ButtonTypes.Ok:

                EventManager.RaiseRequestPlayerName(ReceiveName);

                _switcher.SetNextScreen(ScreenTypes.ScoreScreen);
                _switcher.SwitchScreens(_data);
                return;
        }
    }

    public void ReceiveName(string pPlayerName)
    {
        if (HighScoreDataBase.FetchData(out HighScores pHighScores, _data.ChosenDifficulty, _data.KingMoleMode) == false)
        {
            pHighScores = new HighScores();
        }

        if (AddScoreToHighScores(ref pHighScores.HighestScores, _data.Score, pPlayerName) == true)
        {
            HighScoreDataBase.PushData(pHighScores, _data.ChosenDifficulty, _data.KingMoleMode);
        }
    }

    //Simply looping through the array is fast enough here, no need to implement a search algorithm like binary search.
    private bool AddScoreToHighScores(ref HighScore[] pHighestScores, int pNewScore, string pPlayerName)
    {
        List<HighScore> highestScores = new List<HighScore>(pHighestScores);

        for (int i = 0; i < highestScores.Count; i++)
        {
            if (pNewScore > highestScores[i].Score)
            {
                highestScores.Insert(i, new HighScore(pPlayerName, _data.Score));

                if(highestScores.Count > 20)
                {
                    highestScores.RemoveAt(20);
                }
              
                pHighestScores = highestScores.ToArray();
                return true;
            }
        }

        if(highestScores.Count < 20)
        {
            highestScores.Add(new HighScore(pPlayerName, _data.Score));
            pHighestScores = highestScores.ToArray();
            return true;
        }
        return false;
    }

    private void ScoreRequested(UnityAction<int> pCallback)
    {
        pCallback.Invoke(_data.Score);
    }
}
