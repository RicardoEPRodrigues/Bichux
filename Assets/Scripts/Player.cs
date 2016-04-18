using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public AnimalTypes status;

    public List<GameObject> animals = null;
    public List<Achievment> achievments = new List<Achievment>() { new UnicornAchievment() };

    private bool locked;

    public bool Locked
    {
        get
        {
            return locked;
        }

        set
        {
            this.locked = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        this.ChangeStatus();
    }

    void PressedKey()
    {
        if (!locked)
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
                if (GameManager.GetInstance().IsUnicornAvailable)
                {
                    GameManager.GetInstance().PlayerNotifyUI();
                    status = AnimalTypes.Unicorn;
                }
                   
            }
            if (Input.anyKeyDown)
            {
                ChangeStatus();
            } 
        }

    }

    void ChangeStatus()
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

        PressedKey();

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
        foreach (Achievment achievment in achievments)
        {
            if (achievment is UnicornAchievment && achievment.HasAchievment())
            {
                return true;
            }
        }
        return false;
    }
}
