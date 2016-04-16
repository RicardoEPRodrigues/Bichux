using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    enum animals
    {
        Elephant,
        Bunny,
        Worm
    }
    animals status;

    // Use this for initialization
    void Start () {
	
	}

    void pressedKey()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            status = animals.Elephant;

        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            status = animals.Bunny;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            status = animals.Worm;
        }
    }

    void changeStatus()
    {
        if (status == animals.Elephant)
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        if (status == animals.Bunny)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);

        }
        if (status == animals.Worm)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        }
    }
    void death()
    {

    }
    void save()
    {

    }
    void respawn()
    {

    }
    // Update is called once per frame
    private void Update()
    {
        // Get the axis and jump input.

        pressedKey();

        changeStatus();




    }
}
