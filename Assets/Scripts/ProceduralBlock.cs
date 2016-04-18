using UnityEngine;

public class ProceduralBlock : SelfAwareBehaviour
{

    [SerializeField]
    private AnimalTypes acceptedType = AnimalTypes.Bunny;
    [SerializeField]
    private ColliderWrapper colliderW = null;

    private Vector3 startPosition;


    public Transform movementTarget;
    public float speed = 1.0f;
    public bool move = true;

    public Player player;
    public float distThreshold = 1.0f;
    private float startTime;
    private float journeyLength;


	//public int colliderAction;
	//private AnimalAnimation animalAnimation;



    void Start()
    {
        startPosition = self.position;
        startTime = Time.time;
        journeyLength = Vector3.Distance(startPosition, movementTarget.position);
        if (colliderW)
        {
            colliderW.onCollisionEnter = this.OnCollisionBoxEnter;
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
        if (acceptedType != AnimalTypes.None && player)
        {
            bool isPlayerCollision = false;
            foreach (GameObject animal in player.animals) {
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
                    // The player is going to die.
                    GameManager.GetInstance().Die();
                }

                this.colliderW.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
}
