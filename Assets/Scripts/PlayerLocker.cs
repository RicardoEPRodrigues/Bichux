using UnityEngine;
using System.Collections;
using System;

public class PlayerLocker : MonoBehaviour
{
    public ColliderWrapper startLockWrapper;
    public ColliderWrapper stopLockWrapper;
    // Use this for initialization
    void Start()
    {
        if (startLockWrapper)
        {
            startLockWrapper.onCollisionEnter = startCollision;
        }
        if (stopLockWrapper)
        {
            stopLockWrapper.onCollisionEnter = stopCollision;
        }
    }

    private void startCollision(Collider colissionInfo)
    {
        Player player = GameManager.GetInstance().player;
        if (player)
        {
            bool isPlayerCollision = false;
            foreach (GameObject animal in player.animals)
            {
                if (colissionInfo.gameObject == animal)
                {
                    isPlayerCollision = true;

                    /*
                    animalAnimation = col.gameObject.GetComponent<AnimalAnimation>();
                    animalAnimation.PickAnimation(colliderAction);
                    */

                }
            }
            if (isPlayerCollision)
            {
                player.Locked = true;
            }
        }
    }

    private void stopCollision(Collider colissionInfo)
    {
        Player player = GameManager.GetInstance().player;
        if (player)
        {
            bool isPlayerCollision = false;
            foreach (GameObject animal in player.animals)
            {
                if (colissionInfo.gameObject == animal)
                {
                    isPlayerCollision = true;

                    /*
                    animalAnimation = col.gameObject.GetComponent<AnimalAnimation>();
                    animalAnimation.PickAnimation(colliderAction);
                    */

                }
            }
            if (isPlayerCollision)
            {
                player.Locked = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
