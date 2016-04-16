using UnityEngine;
using System.Collections;
using System.Security.Policy;
using System;

public class GameManager : MonoBehaviour
{
    //unique instance
    private static GameManager _instance;

    //scores
    private int CurrentScore = 0;
    private int HighScore = 0;

    public static GameManager GetInstance()
    {
        return _instance;
    }

    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (_instance != null)
            Destroy(_instance.gameObject);

        _instance = this;
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

    void initCurrentScore()
    {
        this.CurrentScore = 0;
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
        return getCurrentScore() > getHighScore();
    }

    //succes and player continues
    public void Save(Player player)
    {
        //save new score
        addPoints(500);
    }

    //end and player die
    public void Die(Player player)
    {
        //salvar novos pontos
        if (isNewHighScore())
        {
            setHighScore(getCurrentScore());
            initCurrentScore();
        }
    }
}
