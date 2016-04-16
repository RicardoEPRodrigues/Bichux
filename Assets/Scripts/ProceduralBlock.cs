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

    // Use this for initialization
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

    // Update is called once per frame
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
            }
        }
    }
}
