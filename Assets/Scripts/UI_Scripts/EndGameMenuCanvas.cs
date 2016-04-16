using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndGameMenuCanvas : MonoBehaviour {


    public GameObject SelfContainer;
    public GameObject GameHUDCanvas;
    public GameObject StartMenuCanvas;


    public Text UI_MyScore;
    public Text UI_HighScore;
    public Image UI_Star;

    // Use this for initialization
    void Start()
    {
        ChangeMyScoreDisplay();
        ChangeHighScoreDisplay();
    }
	// Update is called once per frame
	void Update () {

        Color c = UI_Star.color;
        c.a += 0.7F * Time.deltaTime;
        UI_Star.color = c;
    }

    public void RestartGame()
    {

        Instantiate(GameHUDCanvas);
        Destroy(SelfContainer);
    }

    public void OpenStartMenu()
    {

        Instantiate(StartMenuCanvas);
        Destroy(SelfContainer);
    }

    void ChangeMyScoreDisplay()
    {
        UI_MyScore.text = "1";
    }

    void ChangeHighScoreDisplay()
    {
        UI_HighScore.text = "2";
    }
}
