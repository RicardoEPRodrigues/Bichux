using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public AnimalTypes status;

    public List<GameObject> animals = null;

    // Use this for initialization
    void Start()
    {
        this.changeStatus();
    }

    void pressedKey()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            status = AnimalTypes.Worm;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            status = AnimalTypes.Bunny;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            status = AnimalTypes.Elephant;

        }

    }

    void changeStatus()
    {
        foreach (GameObject animal in animals)
        {
            animal.SetActive(false);
        }
        if (status == AnimalTypes.Worm)
        {
            animals[0].SetActive(true);
        }
        if (status == AnimalTypes.Bunny)
        {
            animals[1].SetActive(true);
        }
        if (status == AnimalTypes.Elephant)
        {
            animals[2].SetActive(true);
        }
    }
    // Update is called once per frame
    private void Update()
    {
        // Get the axis and jump input.

        pressedKey();

        changeStatus();

    }

    public void death()
    {

    }
    public void save()
    {

    }
    public void respawn()
    {

    }
}
