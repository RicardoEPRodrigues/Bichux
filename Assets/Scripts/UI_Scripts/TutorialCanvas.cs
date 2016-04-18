using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialCanvas : MonoBehaviour, ICanvasComunication
{

    public GameObject SelfContainer;
    public GameObject GameHUDContainer;

    public GameObject[] Buttons;
    public GameObject[] Texts;

    private GameManager gameManager { get; set; }


    private Vector3 pos;
    // Use this for initialization
    void OnEnable()
    {

        gameManager = GameManager.GetInstance();
        if (gameManager.player.hasUnicorn())
            showUnicorn();

        Color color = Buttons[0].GetComponent<Image>().color;
        foreach (GameObject button in Buttons)
        {

            color = button.GetComponent<Image>().color;
            color.a = 1.0f;
            button.GetComponent<Image>().color = color;

            color = button.GetComponent<Outline>().effectColor;
            color.a = 1.0f;
            button.GetComponent<Outline>().effectColor = color;
        }

        foreach (GameObject text in Texts)
        {
            color = text.GetComponent<Text>().color;
            color.a = 1.0f;
            text.GetComponent<Text>().color = color;

            color = text.GetComponent<Outline>().effectColor;
            color.a = 1.0f;
            text.GetComponent<Outline>().effectColor = color;
        }

        
    }

        // Update is called once per frame
        void Update()
    {
        float deltaY;
        foreach (GameObject button in Buttons)
        {
            deltaY = DeltaY();
            pos = button.GetComponent<RectTransform>().position;
            pos.y += deltaY;
            button.GetComponent<RectTransform>().position = pos;

            deltaY *= 0.02f;
            pos = button.GetComponent<Outline>().effectDistance;
            pos.x += deltaY;
            pos.y -= deltaY;
            button.GetComponent<Outline>().effectDistance = pos;
        }

        foreach (GameObject text in Texts)
        {
            deltaY = DeltaY()*0.9f;
            pos = text.GetComponent<RectTransform>().position;
            pos.y += deltaY;
            text.GetComponent<RectTransform>().position = pos;

            deltaY *= 0.017f;
            pos = text.GetComponent<Outline>().effectDistance;
            pos.x += deltaY;
            pos.y -= deltaY;
            text.GetComponent<Outline>().effectDistance = pos;
        }
    }


    IEnumerator Fade() {

        Color color = Buttons[0].GetComponent<Image>().color;
        while (color.a >= 0.001)
        {
            foreach (GameObject button in Buttons)
            {

                color = button.GetComponent<Image>().color;
                color.a -= .8f * Time.deltaTime;
                button.GetComponent<Image>().color = color;

                color = button.GetComponent<Outline>().effectColor;
                color.a -= .8f * Time.deltaTime;
                button.GetComponent<Outline>().effectColor = color;
            }

            foreach (GameObject text in Texts)
            {
                color = text.GetComponent<Text>().color;
                color.a -= .8f * Time.deltaTime;
                text.GetComponent<Text>().color = color;

                color = text.GetComponent<Outline>().effectColor;
                color.a -= .8f * Time.deltaTime;
                text.GetComponent<Outline>().effectColor = color;
            }

            yield return new WaitForSeconds(.005f); 
        }

        gameManager.ChangeUICanvas(2);
    }
                   

    private float DeltaY()
    {
        return Mathf.Sin(Time.fixedTime * 2) * 10.0F * Time.fixedDeltaTime * 2;
    }

    public void OpenLevel()
    {
        StartCoroutine("Fade");
    }


    public void SetGameManager(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    public void UpdateScore(int score)
    {
        //do nothing
    }

    public void UpdateHighScore(int score)
    {
        //do nothing
    }


    public void showUnicorn()
    {
        Buttons[3].SetActive(true);
        Texts[3].SetActive(true);
    }
}
