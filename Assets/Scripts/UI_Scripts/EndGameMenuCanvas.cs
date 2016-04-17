using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndGameMenuCanvas : MonoBehaviour, ICanvasComunication
{


    public GameObject SelfContainer;
    public GameObject GameHUDCanvas;
    public GameObject StartMenuCanvas;


    private GameManager gameManager { get; set; }


    public Text UI_MyScore;
    public Text UI_HighScore;
    public Image UI_Star;

    // Use this for initialization
    void Start()
    {
    }
	// Update is called once per frame
	void Update () {

        Color c = UI_Star.color;
        c.a += 0.7F * Time.deltaTime;
        UI_Star.color = c;
    }

    public void RestartGame()
    {
        gameManager.ChangeUICanvas(2);
    }

    public void OpenStartMenu()
    {
        gameManager.ChangeUICanvas(0);
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
        UI_HighScore.text = score.ToString();
    }

}
