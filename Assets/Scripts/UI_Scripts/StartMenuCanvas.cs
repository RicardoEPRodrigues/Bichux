using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartMenuCanvas : MonoBehaviour, ICanvasComunication
{

    public GameObject SelfContainer;
    public GameObject TutorialContainer;

    public GameObject[] Buttons;

    public Text UI_HighScore;

    public GameManager gameManager { get; set; }


    private Vector3 pos;
    private bool hoveringButton;
    private int id;


    // Use this for initialization
    void Start () {
	}
    void FixedUpdate()
    {
        if (hoveringButton)
        {
            float deltaY;

            GameObject button = Buttons[id];

            deltaY = DeltaY();
            pos = button.GetComponent<RectTransform>().position;
            pos.y += deltaY*1.2f;
            button.GetComponent<RectTransform>().position = pos;
        }

    }

   public  void OnMouseEnter(int id)
    {
        hoveringButton = true;
        this.id = id;
    }

    public void OnMouseExit()
    {
        hoveringButton = false;
    }

    private float DeltaY()
    {
        return Mathf.Sin(Time.fixedTime * 2) * 10.0F * Time.fixedDeltaTime * 2;
    }

    public void OpenTutorial() {
        this.gameManager.ChangeUICanvas(1);
    }

    public void OpenOptions() { }
    public void OpenCredits() { }



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
        UI_HighScore.text = score.ToString();
    }

}
