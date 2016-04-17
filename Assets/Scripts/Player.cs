﻿using System.Collections.Generic;
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

        if (Input.anyKeyDown)
        {
            changeStatus();
        }

    }

    void changeStatus()
    {
        foreach (GameObject animal in animals)
        {
            if (animal)
            {
                animal.SetActive(false);
            }
        }
        if (status == AnimalTypes.Worm && animals[0])
        {
            animals[0].SetActive(true);
        }
        else if (status == AnimalTypes.Bunny && animals[1])
        {
            animals[1].SetActive(true);
        }
        else if (status == AnimalTypes.Elephant && animals[2])
        {
            animals[2].SetActive(true);
        }
    }
    // Update is called once per frame
    private void Update()
    {
        // Get the axis and jump input.

        pressedKey();

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
