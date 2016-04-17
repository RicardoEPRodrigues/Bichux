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
        generator.Speed = 3;
        StartCoroutine(IncreaseSpeed());
        generator.Play();

        ChangeUICanvas(0);

        if (ICanvas != null)
            ICanvas.SetGameManager(this);
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
        /*
        if (highscore.GetCurrentScore() == 1000 && CurrentCanvas == 2 && player.hasUnicorn)
            ICanvas.showUnicorn();
            */

        if (ICanvas != null)
            ICanvas.UpdateScore(highscore.GetCurrentScore());

    }

    //end and player die
    public void Die()
    {
        // resets current score
        highscore.InitCurrentScore();
        // pauses game until restart
        generator.Pause();
    }

    public void ChangeUICanvas(int id)
    {
        UI_CanvasPrefab[CurrentCanvas].SetActive(false);
        CurrentCanvas = id;
        UI_CanvasPrefab[id].SetActive(true);
        ICanvas = (ICanvasComunication) UI_CanvasPrefab[id].GetComponent(typeof(ICanvasComunication));
        ICanvas.SetGameManager(this);


        if(CurrentCanvas == 1 && player.hasUnicorn()){
            ICanvas.showUnicorn();
        }

    }

    public void PlayerNotifyUI()
    {
        if(CurrentCanvas == 2)
            ICanvas.showUnicorn();
    }

    public void test()
    {
        Debug.Log("ho");
    }
}
