using UnityEngine;

public class ProceduralBlock : SelfAwareBehaviour
{

    [SerializeField]
    private AnimalTypes acceptedType;

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

    void OnCollisionBoxEnter(Collision col)
    {
        if (acceptedType != AnimalTypes.None && player && player.gameObject == col.gameObject)
        {
            if (player.currentAnimal == this.acceptedType)
            {
                // Save()
            }
            else
            {
                // Die()
            }
        }
    }
}
