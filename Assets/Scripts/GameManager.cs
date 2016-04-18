﻿using UnityEngine;
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

    public GameObject[] UI_CanvasPrefab;
    private int CurrentCanvhhas;
    public bool IsUnicornAvailable { get; set; }
    private bool hasWaitingDelay;



    public ICanvasComunication ICanvas;

    public Highscore highscore;
    [SerializeField]
    private float maxSpeed = 10;

    public BlockGenerator generator;
    public Player player;

    public int CurrentCanvas { get; private set; }

    void Start()
    {
        highscore = new Highscore();

        // resets current score
        highscore.InitCurrentScore(); //ver com eles

        generator.Speed = 3;
        StartCoroutine(IncreaseSpeed());
        generator.Play();
        IsUnicornAvailable = false;
        hasWaitingDelay = false;

        ChangeUICanvas(0);

        if (ICanvas != null)
            ICanvas.SetGameManager(this);

        generator.generateRandom = false;
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
        
        if( player.hasUnicorn() && highscore.GetCurrentScore() == 500 && CurrentCanvas == 2 && !IsUnicornAvailable && !hasWaitingDelay )
        {
            IsUnicornAvailable = true;
            ICanvas.showUnicorn();
        }

        if (ICanvas != null)
        {
            ICanvas.UpdateScore(highscore.GetCurrentScore());
        }
    }

    //end and player die
    public void Die()
    {
        // pauses game until restart
        generator.Pause();
        generator.generateRandom = false;
        ChangeUICanvas(3);
    }

    public void Play()
    {

        generator.generateRandom = true;
    }


    public void ChangeUICanvas(int id)
    {
        UI_CanvasPrefab[CurrentCanvas].SetActive(false);
        CurrentCanvas = id;
        UI_CanvasPrefab[id].SetActive(true);
        ICanvas = (ICanvasComunication) UI_CanvasPrefab[id].GetComponent(typeof(ICanvasComunication));
        ICanvas.SetGameManager(this);

        ICanvas.UpdateScore(highscore.GetCurrentScore());

        ICanvas.UpdateHighScore(highscore.GetHighScore());


        if (CurrentCanvas == 1 && player.hasUnicorn()){
            IsUnicornAvailable = true;
            ICanvas.showUnicorn();
        }else if(CurrentCanvas == 2)
        {
            Play();
        }
        IsUnicornAvailable = false;
    }

    public void PlayerNotifyUI()
    {
        
        if (CurrentCanvas == 2)
        {
            
            IsUnicornAvailable = false;
            ICanvas.showUnicorn();
            StartCoroutine(RemoveUnicorn(10));
        }
    }

    private IEnumerator RemoveUnicorn(float time)
    {
        hasWaitingDelay = true;
        
        yield return new WaitForSeconds(time);
        hasWaitingDelay = false;

        // Code to execute after the delay
    }

    public void test()
    {
        Debug.Log("ho");
    }
}
