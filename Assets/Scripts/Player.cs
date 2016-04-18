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
        this.ChangeStatus(status, true);
    }

    void PressedKey()
    {
        if (!locked)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ChangeStatus(AnimalTypes.Worm);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                ChangeStatus(AnimalTypes.Bunny);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                ChangeStatus(AnimalTypes.Elephant);
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                if (hasUnicorn())//&& GameManager.GetInstance().IsUnicornAvailable)
                {
                    GameManager.GetInstance().PlayerNotifyUI();
                    ChangeStatus(AnimalTypes.Unicorn);
                }

            }
        }

    }

    void ChangeStatus(AnimalTypes type, bool force = false)
    {
        if (!force && status == type)
        {
            return;
        }
        status = type;
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

    public void death(AnimationType type)
    {
        AnimalAnimation animalAnimation = animals[(int)status].GetComponent<AnimalAnimation>();
        if (animalAnimation)
        {
            animalAnimation.PickAnimation(type);
        }
    }
    public void save()
    {
        if (this.status == AnimalTypes.Bunny)
        {
            AnimalAnimation animalAnimation = animals[(int)status].GetComponent<AnimalAnimation>();
            if (animalAnimation)
            {
                animalAnimation.PickAnimation(AnimationType.Special);
            }
        }
    }
    public void respawn()
    {
        locked = false;
        AnimalAnimation animalAnimation = animals[(int)status].GetComponent<AnimalAnimation>();
        if (animalAnimation)
        {
            animalAnimation.PickAnimation(AnimationType.Run);
        }
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
