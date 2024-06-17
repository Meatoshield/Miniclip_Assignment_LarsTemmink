using System;

[Serializable]
public struct HighScore
{
    public string Name;
    public int Score;

    public HighScore(string pName, int pScore)
    {
        Name = pName;
        Score = pScore;
    }
}
