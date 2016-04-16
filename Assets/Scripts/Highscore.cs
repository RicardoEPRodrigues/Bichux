using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Highscore
{
    //scores
    private int currentScore = 0;
    private int highScore = 0;

    /*
    CURRENT SCORE
    */
    public int GetCurrentScore()
    {
        return currentScore;
    }

    public void AddPoints(int points)
    {
        currentScore += points;
        if (IsNewHighScore())
        {
            this.highScore = currentScore;
        }
    }

    public void InitCurrentScore()
    {
        this.currentScore = 0;
    }

    /*
    HIGH SCORE
    */
    public int GetHighScore()
    {
        return highScore;
    }

    private bool IsNewHighScore()
    {
        return GetCurrentScore() > GetHighScore();
    }
}

