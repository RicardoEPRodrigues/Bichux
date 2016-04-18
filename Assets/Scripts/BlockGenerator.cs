using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlockGenerator : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> blocks = null;
    [SerializeField]
    private GameObject defaultBlock = null;
    private GameObject previousBlock;

    public Transform spawnLocation;
    public Transform movementTarget;
    public Player player;

    public float distanceThreshold = 10.0f;

    public bool generate = false;
    public bool generateRandom = true;

    public SpeedChanger speedChanger;

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

    public void Restart()
    {
        speedChanger.Reset();
        ICollection<ProceduralBlock> blocks = GetComponentsInChildren<ProceduralBlock>();
        foreach (ProceduralBlock block in blocks)
        {
            if (block)
            {
                InstantiateBlock(defaultBlock);
                previousBlock.transform.position = block.transform.position;
                Destroy(block.gameObject);
            }
        }
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
        speedChanger.IsUpdating = run;
    }

    void SpawnRandomObject()
    {
        //spawns item in array position between 0 and 100
        int whichItem = Random.Range(0, blocks.Count);

        InstantiateBlock(blocks[whichItem]);
    }

    private void InstantiateBlock(GameObject blockObject)
    {
        GameObject blockObj = Instantiate(blockObject) as GameObject;
        blockObj.transform.SetParent(gameObject.transform);
        previousBlock = blockObj;

        blockObj.transform.position = spawnLocation.position;
        ProceduralBlock block = blockObj.GetComponent<ProceduralBlock>();
        block.movementTarget = movementTarget;
        block.player = player;
        block.speed = this.speedChanger.Speed;
    }

    void Update()
    {
        if (generate && (!previousBlock || !Utilities.WithinDistance(spawnLocation.position, previousBlock.transform.position, distanceThreshold)))
        {
            if (!generateRandom)
            {
                InstantiateBlock(defaultBlock);
                this.speedChanger.IsUpdating = false;
            }
            else
            {
                SpawnRandomObject();
                this.speedChanger.IsUpdating = true;
            }
        }
    }
}
