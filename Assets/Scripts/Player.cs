using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    
    public AnimalTypes status;

    // Use this for initialization
    void Start () {
	
	}

    void pressedKey()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            status = AnimalTypes.Elephant;

        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            status = AnimalTypes.Bunny;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            status = AnimalTypes.Worm;
        }
    }

    void changeStatus()
    {
        if (status == AnimalTypes.Elephant)
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        if (status == AnimalTypes.Bunny)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);

        }
        if (status == AnimalTypes.Worm)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        }
    }
    // Update is called once per frame
    private void Update()
    {
        // Get the axis and jump input.

        pressedKey();

        changeStatus();




    }
}
