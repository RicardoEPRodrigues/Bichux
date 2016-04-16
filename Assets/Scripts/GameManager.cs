using UnityEngine;
using System.Collections;
using System.Security.Policy;

public class GameManager : MonoBehaviour
{
    private int CurrentScore = 0;
    private int HighScore = 0;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    /*
    CURRENT SCORE
    */
    int getCurrentScore()
    {
        return CurrentScore;
    }

    void addPoints(int points)
    {
        CurrentScore += points;
    }

    /*
    HIGH SCORE
    */
    int getHighScore()
    {
        return HighScore;
    }

    void setHighScore(int points)
    {
        this.HighScore = points;
    }

    bool isNewHighScore()
    {
        if (getCurrentScore() > getHighScore())
        {
            setHighScore(getCurrentScore());
            return true;
        }
        else
        {
            return false;
        }
    }
}
