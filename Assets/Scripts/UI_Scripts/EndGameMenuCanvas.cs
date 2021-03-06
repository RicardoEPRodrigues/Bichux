﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndGameMenuCanvas : MonoBehaviour, ICanvasComunication
{


    public GameObject SelfContainer;
    public GameObject GameHUDCanvas;
    public GameObject StartMenuCanvas;

    public GameObject UnicornPowerUp;
    public GameObject UnicornTextPowerUp;


    private GameManager gameManager { get; set; }
    private bool NewBest { get; set; }
    public static bool NewUnlock;


    public Text UI_MyScore;
    public Text UI_HighScore;
    public Image UI_Star;


    private float hue;
    private Color color;

    // Use this for initialization

    void OnEnable()
    {
        
        NewBest = false;
        NewUnlock = false;
        CheckForAchievments();
        if (NewUnlock)
        {
            UnicornPowerUp.SetActive(true);

        }

    }

	// Update is called once per frame
	void Update () {
        
        if (NewBest)
        {

            Color c = UI_Star.color;
            c.a += 0.7F * Time.deltaTime;
            UI_Star.color = c;
        }

        if (NewUnlock) {
            hue += 50 * Time.deltaTime;
            color = ColorFromHSV(hue, 1.0f, 1.0f);
            color.a = 1.0f;
            UnicornPowerUp.GetComponent<Image>().color = color;
            UnicornTextPowerUp.GetComponent<Outline>().effectColor = color;
            UnicornTextPowerUp.GetComponent<Text>().color = color;
        }
        
    }

    public void RestartGame()
    {
        gameManager.highscore.InitCurrentScore();
        NewBest = false;
        NewUnlock = false;
        Color c = UI_Star.color;
        c.a = 0.0f;
        UI_Star.color = c;
        UnicornPowerUp.SetActive(false);
        gameManager.ChangeUICanvas(2);
        gameManager.Play();
    }

    public void OpenStartMenu()
    {
        gameManager.highscore.InitCurrentScore();
        NewBest = false;
        NewUnlock = false;
        Color c = UI_Star.color;
        c.a = 0.0f;
        UI_Star.color = c;
        UnicornPowerUp.SetActive(false);
        gameManager.ChangeUICanvas(0);
    }

    private void CheckForAchievments()
    {
        gameManager = GameManager.GetInstance();
        gameManager.player.achievments[0].CheckAchievment();
        if (gameManager.player.achievments[0].HasAchievment() && !gameManager.player.achievments[0].HasShowedAchievment())
        {
            gameManager.player.achievments[0].ShowAchievment();            // como só há um achievment. Usar um ciclo for break para o caso contrário
            NewUnlock = true;
        }
    }


    public void SetGameManager(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    public void UpdateScore(int score)
    {
        UI_MyScore.text = score.ToString();


        if (score == gameManager.highscore.GetHighScore())
        {
            NewBest = true;
        }
    }

    public void UpdateHighScore(int score)
    {
        UI_HighScore.text = score.ToString();
    }

    public void showUnicorn() {
        //usar isto para oa chievment
    }


    public Color ColorFromHSV(float h, float s, float v, float a = 1)
    {

        // no saturation, we can return the value across the board (grayscale)
        if (s == 0)
            return new Color(v, v, v, a);

        // which chunk of the rainbow are we in?
        float sector = h / 60;
        if (sector < 0)
            h = 6 - (-h % 6);
        sector %= 6;

        // split across the decimal (ie 3.87 into 3 and 0.87)
        int i = (int)sector;
        float f = sector - i;

        float p = v * (1 - s);
        float q = v * (1 - s * f);
        float t = v * (1 - s * (1 - f));

        // build our rgb color
        Color color = new Color(0, 0, 0, a);

        switch (i)
        {
            case 0:
                color.r = v;
                color.g = t;
                color.b = p;
                break;

            case 1:
                color.r = q;
                color.g = v;
                color.b = p;
                break;

            case 2:
                color.r = p;
                color.g = v;
                color.b = t;
                break;

            case 3:
                color.r = p;
                color.g = q;
                color.b = v;
                break;

            case 4:
                color.r = t;
                color.g = p;
                color.b = v;
                break;

            default:
                color.r = v;
                color.g = p;
                color.b = q;
                break;
        }

        return color;
    }

}
