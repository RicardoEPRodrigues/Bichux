using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialCanvas : MonoBehaviour
{

    public GameObject SelfContainer;
    public GameObject GameHUDContainer;

    public GameObject[] Buttons;
    public GameObject[] Texts;

    private Vector3 pos;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
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

    private float DeltaY()
    {
        return Mathf.Sin(Time.fixedTime * 2) * 10.0F * Time.fixedDeltaTime * 2;
    }

    public void OpenLevel()
    {
        Instantiate(GameHUDContainer);
        Destroy(SelfContainer);
    }
}
