using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CubesGenerator : MonoBehaviour
{
    //standard prefab
    [SerializeField]
    private GameObject defaultCube;

    //cubes number
    public int numberCubes;

    //refernece to manager
    private GameManager manager;

    //cubes container
    private List<Cube> cubes = null;
    private List<Color> colours = null;

    void Start()
    {
        //init moving cubes
        cubes = new List<Cube>();
        colours = new List<Color>();

        createColours();
        createCubes();

        //reference to manager
        manager = GameManager.GetInstance();
    }


    void Update()
    {
        foreach (Cube cube in cubes)
        {
            cube.lifeCycle(manager.generator.speedChanger.Speed);
        }
    }

    private void createCubes()
    {
        float x, y, z;
        for (int i = 0; i < numberCubes; i++)
        {
            x = Random.Range(-45, 72);
            y = Random.Range(-20, 47);
            z = Random.Range(20, 40);

            cubes.Add(new Cube(defaultCube, new Vector3(x, y, z), colours[Random.Range(0, colours.Count)]));
        }
    }

    private void createColours()
    {
        Color colour1 = new Color(0.56f, 0.56f, 0.56f, 1.0f);
        Color colour2 = new Color(1.0f, 1.0f, 0.33f, 1.0f);
        Color colour3 = new Color(0.92f, 0.42f, 0.6f, 1.0f);

        colours.Add(colour1);
        colours.Add(colour2);
        colours.Add(colour3);
    }
}
