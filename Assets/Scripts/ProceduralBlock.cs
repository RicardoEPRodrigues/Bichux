using System;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralBlock : SelfAwareBehaviour
{

    [SerializeField]
    private AnimalTypes acceptedType = AnimalTypes.Bunny;
    [SerializeField]
    private List<ColliderWrapper> colliderW = null;

    private Vector3 startPosition;


    public Transform movementTarget;
    public float speed = 1.0f;
    public bool move = true;

    public Player player;
    public float distThreshold = 1.0f;
    private float startTime;
    private float journeyLength;
    public AnimationType deathAnimation = AnimationType.Fall;


    //public int colliderAction;
    //private AnimalAnimation animalAnimation;



    void Start()
    {
        startPosition = self.position;
        startTime = Time.time;
        journeyLength = Vector3.Distance(startPosition, movementTarget.position);
        if (colliderW != null)
        {
            if (colliderW.Count > 0)
            {
                colliderW[0].onCollisionEnter = this.OnCollisionBoxEnter;
            }
            if (colliderW.Count > 1)
            {
                colliderW[1].onCollisionEnter = this.OnCollisionBoxEnterDeath;
            }
        }
    }

    void Update()
    {
        if (movementTarget && move)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            self.position = Vector3.Lerp(startPosition, movementTarget.position, fracJourney);

            // instead of deleting, one can instead disable and reuse stage when needed
            if (Utilities.WithinDistance(self.position, movementTarget.position, distThreshold))
            {
                Destroy(selfObj);
            }
        }
    }

    public void OnCollisionBoxEnter(Collider col)
    {
        if (acceptedType != AnimalTypes.None && acceptedType != AnimalTypes.Unicorn && player)
        {
            bool isPlayerCollision = false;
            foreach (GameObject animal in player.animals)
            {
                if (col.gameObject == animal)
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
                if (player.status == this.acceptedType)
                {
                    // The player can keep going.
                    GameManager.GetInstance().Save();
                }
                else
                {
                    if (colliderW.Count == 1)
                    {
                        // The player is going to die.
                        GameManager.GetInstance().Die(deathAnimation);
                    }
                }

                this.colliderW[0].GetComponent<BoxCollider>().enabled = false;
            }
        }
    }

    private void OnCollisionBoxEnterDeath(Collider colissionInfo)
    {
        if (acceptedType != AnimalTypes.None && acceptedType != AnimalTypes.Unicorn && player)
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
                if (player.status != this.acceptedType)
                {
                    // The player is going to die.
                    GameManager.GetInstance().Die(deathAnimation);
                }

                this.colliderW[1].GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
}
