using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public AnimalTypes status;
    private GameManager gameManager;
    public List<Achievment> achievmentArray = new List<Achievment>() { new UnicornAchievment() };

    public List<GameObject> animals = null;
    


    // Use this for initialization
    void Start()
    {
    }

    void pressedKey()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            status = AnimalTypes.Worm;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            status = AnimalTypes.Bunny;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            status = AnimalTypes.Elephant;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            status = AnimalTypes.Unicorn;
            if (hasUnicorn()) {
               // gameManager.PlayerNotifyUI();
            }
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
        else if (status == AnimalTypes.Unicorn && animals[3])
        {
            animals[3].SetActive(true);
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

    public bool hasUnicorn()
    {
        foreach (Achievment achievment in achievmentArray)
        {
            if (achievment is UnicornAchievment)
            {
                return true;
            }
        }
        return false;
    }
}
