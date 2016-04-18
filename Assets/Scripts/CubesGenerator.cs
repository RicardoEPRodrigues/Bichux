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

	void Start () {
        //init moving cubes
	    cubes = new List<Cube>();
	    createCubes();

        //reference to manager
	    manager = GameManager.GetInstance();
	}
    

	void Update () {
        foreach (Cube cube in cubes) {
            cube.lifeCycle(manager.generator.Speed);
        }
    }

    private void createCubes() {
        float x, y, z;
        for (int i = 0; i < numberCubes; i++) {
            x = Random.Range(-45, 72);
            y = Random.Range(-20, 47);
            z = Random.Range(20, 40);

            cubes.Add(new Cube(defaultCube, new Vector3(x, y, z)));
        }
    }
}
