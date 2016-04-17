using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class GameHUDCanvas : MonoBehaviour, ICanvasComunication
{
    
    public GameObject selfContainer;
    public GameObject endGameMenuContainer;

    private GameObject prefabCopy;

    private GameManager gameManager { get; set; }

    public Text UI_MyScore;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {


    }

    void OpenEndGameWindow()
    {
        gameManager.ChangeUICanvas(3);
    }

    public void SetGameManager(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    public void UpdateScore(int score)
    {
        UI_MyScore.text = score.ToString();
    }

    public void UpdateHighScore(int score)
    {
        //nothing
    }

}
