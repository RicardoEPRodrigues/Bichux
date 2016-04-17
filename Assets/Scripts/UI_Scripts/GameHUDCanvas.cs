using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class GameHUDCanvas : MonoBehaviour, ICanvasComunication
{

    public GameObject selfContainer;
    public GameObject endGameMenuContainer;
    public GameObject UnicornPowerUp;
    public GameObject UnicornTextPowerUp;

    private GameObject prefabCopy;

    private GameManager gameManager { get; set; }

    private bool isArrowPressed;
    private float hue;
    private Color color;

    public Text UI_MyScore;

    // Use this for initialization
    void Start()
    {
        hue = 0;
        isArrowPressed = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (!isArrowPressed)
        {
            hue += 50 * Time.deltaTime;
            color = ColorFromHSV(hue, 1.0f, 1.0f);
            color.a = 1.0f;
            UnicornPowerUp.GetComponent<Outline>().effectColor = color;
            UnicornTextPowerUp.GetComponent<Outline>().effectColor = color;
            UnicornTextPowerUp.GetComponent<Text>().color = color;


        }
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

    public void showUnicorn()
    {
        if (isArrowPressed)
        {
            isArrowPressed = false;
            UnicornPowerUp.SetActive(true);
            UnicornTextPowerUp.SetActive(true);
        }
        else
        {
            isArrowPressed = true;
            UnicornPowerUp.SetActive(false);
            UnicornTextPowerUp.SetActive(false);
        }
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
