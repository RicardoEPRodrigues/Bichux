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
    private int CurrentCanvas;


    private ICanvasComunication ICanvas;

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

        ChangeUICanvas(0);
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

        if (ICanvas != null)
            ICanvas.SetGameManager(this);


        //update highscore
        highscore.AddPoints(500);

        if (ICanvas != null)
            ICanvas.UpdateScore(highscore.GetHighScore());
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

    public void ChangeUICanvas(int id)
    {
        UI_CanvasPrefab[CurrentCanvas].SetActive(false);
        CurrentCanvas = id;
        UI_CanvasPrefab[id].SetActive(true);
        ICanvas = (ICanvasComunication) UI_CanvasPrefab[id].GetComponent(typeof(ICanvasComunication));
        ICanvas.SetGameManager(this);

    }

    public void test()
    {
        Debug.Log("ho");
    }
}
