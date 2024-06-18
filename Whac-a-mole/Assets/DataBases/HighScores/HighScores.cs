using System;

[Serializable]
public record HighScores
{
    public HighScore[] HighestScores;

    public HighScores()
    {
        HighestScores = new HighScore[0];
    }
}
