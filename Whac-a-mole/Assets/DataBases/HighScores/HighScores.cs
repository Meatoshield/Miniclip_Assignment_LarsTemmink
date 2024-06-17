using System;

[Serializable]
public struct HighScores
{
    public HighScore[] HighestScores;

    public HighScores(int pHighScoreCount)
    {
        HighestScores = new HighScore[pHighScoreCount];

        for(int i = 0; i < pHighScoreCount; i++)
        {
            HighestScores[i] = new HighScore("------", 0);
        }
    }
}
