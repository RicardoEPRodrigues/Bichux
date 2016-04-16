using UnityEngine;
using System.Collections;

public class StartMenuCanvas : MonoBehaviour
{

    public GameObject SelfContainer;
    public GameObject TutorialContainer;

    public GameObject[] Buttons;

    private Vector3 pos;
    private bool hoveringButton;
    private int id;

    // Use this for initialization
    void Start () {
        UpdateHighScore();
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

        Instantiate(TutorialContainer);
        Destroy(SelfContainer);
    }
    public void OpenOptions() { }
    public void OpenCredits() { }

    void UpdateHighScore() { }

}
