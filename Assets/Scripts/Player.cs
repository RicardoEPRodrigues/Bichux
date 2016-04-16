using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    
    public AnimalTypes status;
    private Renderer render;
    public GameObject bunny;
    public GameObject elephant;
    public GameObject worm;
    Renderer[] renderers;
    // Use this for initialization
    void Start () {
        renderers = GetComponentsInChildren<Renderer>();
        foreach (var r in renderers)
        {
            // Do something with the renderer here...
            r.enabled = false; // like disable it for example. 
        }
    }

    void pressedKey()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            status = AnimalTypes.Elephant;

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            status = AnimalTypes.Bunny;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            status = AnimalTypes.Worm;
        }
        
    }

    void changeStatus()
    {
        if (status == AnimalTypes.Elephant)
        {
           renderers[0].GetComponent<Renderer>().enabled = true;
           renderers[1].GetComponent<Renderer>().enabled = false;
           renderers[2].GetComponent<Renderer>().enabled = false;
        }
        if (status == AnimalTypes.Bunny)
        {
            renderers[0].GetComponent<Renderer>().enabled = false;
            renderers[1].GetComponent<Renderer>().enabled = true;
            renderers[2].GetComponent<Renderer>().enabled = false;

        }
        if (status == AnimalTypes.Worm)
        {
            renderers[0].GetComponent<Renderer>().enabled = false;
            renderers[1].GetComponent<Renderer>().enabled = false;
            renderers[2].GetComponent<Renderer>().enabled = true;

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
