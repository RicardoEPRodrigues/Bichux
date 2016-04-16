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
        bunny.SetActive(false);
        elephant.SetActive(false);
        worm.SetActive(false);

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

            elephant.SetActive(true);
            bunny.SetActive(false);
            worm.SetActive(false);

        }
        if (status == AnimalTypes.Bunny)
        {
            elephant.SetActive(false);
            bunny.SetActive(true);
            worm.SetActive(false);

        }
        if (status == AnimalTypes.Worm)
        {
            elephant.SetActive(false);
            bunny.SetActive(false);
            worm.SetActive(true);

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
