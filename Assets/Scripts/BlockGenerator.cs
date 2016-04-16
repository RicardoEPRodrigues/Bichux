using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlockGenerator : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> blocks = null;

    private GameObject previousBlock;
    [SerializeField]
    private float speed= 0.1f;

    public Transform spawnLocation;
    public Transform movementTarget;
    public Player player;

    public float distanceThreshold = 10.0f;

    public bool generate = false;

    public float Speed
    {
        get
        {
            return speed;
        }

        set
        {
            this.speed = value;
            //foreach (ProceduralBlock block in GetComponentsInChildren<ProceduralBlock>())
            //{
            //    if (block)
            //    {
            //        block.speed = value;
            //    }
            //}
        }
    }


    // Use this for initialization
    void Start()
    {
    }

    public void Play()
    {
        Control(true);
    }

    public void Pause()
    {
        Control(false);
    }

    private void Control(bool run)
    {
        generate = run;
        foreach (ProceduralBlock block in GetComponentsInChildren<ProceduralBlock>())
        {
            if (block)
            {
                block.move = run;
            }
        }
    }

    void SpawnRandomObject()
    {
        //spawns item in array position between 0 and 100
        int whichItem = Random.Range(0, blocks.Count);


        GameObject blockObj = Instantiate(blocks[whichItem]) as GameObject;
        blockObj.transform.SetParent(gameObject.transform);
        previousBlock = blockObj;

        blockObj.transform.position = spawnLocation.position;
        ProceduralBlock block = blockObj.GetComponent<ProceduralBlock>();
        block.movementTarget = movementTarget;
        block.player = player;
        block.speed = this.speed;
    }

    void Update()
    {
        if (generate && (!previousBlock || !Utilities.WithinDistance(spawnLocation.position, previousBlock.transform.position, distanceThreshold)))
        {
            SpawnRandomObject();
        }
    }
}
