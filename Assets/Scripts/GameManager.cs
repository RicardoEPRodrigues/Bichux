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

    public GameObject[] UI_CanvasPrefab;
    private int CurrentCanvhhas;
    public bool IsUnicornAvailable { get; set; }
    private bool hasWaitingDelay;


    public void SetQuality(float level)
    {
        QualitySettings.SetQualityLevel((int)level, true);
    }



    public ICanvasComunication ICanvas;

    public Highscore highscore;

    public BlockGenerator generator;
    public Player player;

    public int CurrentCanvas { get; private set; }

    //FORMULA FIB
    private float _baseScore = 500.0f;
    private float _xx = 1;

    void Start()
    {
        highscore = new Highscore();

        // resets current score
        highscore.InitCurrentScore();
        
        generator.Play();
        IsUnicornAvailable = false;
        hasWaitingDelay = false;

        ChangeUICanvas(0);

        if (ICanvas != null)
            ICanvas.SetGameManager(this);

        generator.generateRandom = false;
    }

    //succes and player continues
    public void Save()
    {
        player.save();

        //update highscore
        highscore.AddPoints(500);
        
        if( player.hasUnicorn() && highscore.GetCurrentScore() >= _baseScore && CurrentCanvas == 2 && !IsUnicornAvailable && !hasWaitingDelay )
        {
            IsUnicornAvailable = true;
            ICanvas.showUnicorn();

            //update formula
            _xx += 1.0f;
            _baseScore =+ (_baseScore*_xx);
        }

        if (ICanvas != null)
        {
            ICanvas.UpdateScore(highscore.GetCurrentScore());
        }
        
    }

    //end and player die
	public void Die(AnimationType deathAnimation)
    {
		player.death (deathAnimation);
		if (deathAnimation == AnimationType.Crash)
			OnDie ();
		// pauses game until restart
    }

	public void OnDie(){
		generator.Pause();
		generator.generateRandom = false;
		ChangeUICanvas(3);
	}

    public void Play()
    {
        highscore.InitCurrentScore();
        generator.Restart();
        generator.generate = true;
        generator.generateRandom = true;
        player.respawn();
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
}
