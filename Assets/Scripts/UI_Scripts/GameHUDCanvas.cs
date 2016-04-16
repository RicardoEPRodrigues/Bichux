using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameHUDCanvas : MonoBehaviour {
    
    public GameObject SelfContainer;
    public GameObject EndGameMenuContainer;

    public Text UI_MyScore;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {


    }

    void OpenEndGameWindow()
    {
        Instantiate(EndGameMenuContainer);
        Destroy(SelfContainer);
    }

    void ChangeMyScoreDisplay()
    {
        UI_MyScore.text = "1";
    }

}
