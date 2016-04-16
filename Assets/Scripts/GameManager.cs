using UnityEngine;
using System.Collections;
using System.Security.Policy;
using System;

public class GameManager : MonoBehaviour
{
    //unique instance
    private static GameManager _instance;

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

    private Highscore highscore;
    [SerializeField]
    private float maxSpeed = 10;

    public BlockGenerator generator;
    public Player player;

    void Start()
    {
        highscore = new Highscore();
        generator.Speed = 3;
        StartCoroutine(IncreaseSpeed());
        generator.Play();
    }

    private IEnumerator IncreaseSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            if (generator.Speed < maxSpeed)
            {
                generator.Speed += 0.1f; 
            }
        }
    }

    //succes and player continues
    public void Save()
    {
        //update highscore
        highscore.AddPoints(500);
        //TODO update ui

    }

    //end and player die
    public void Die()
    {
        // resets current score
        highscore.InitCurrentScore();
        // pauses game until restart
        generator.Pause();
    }
}
