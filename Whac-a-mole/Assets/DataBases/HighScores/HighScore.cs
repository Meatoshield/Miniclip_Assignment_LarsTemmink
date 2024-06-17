using System;

[Serializable]
public record HighScore
{
    public string Name;
    public int Score;

    public HighScore(string pName, int pScore)
    {
        Name = pName;
        Score = pScore;
    }
}
