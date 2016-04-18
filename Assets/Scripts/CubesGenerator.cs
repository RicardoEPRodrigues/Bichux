using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CubesGenerator : MonoBehaviour
{
    //standard configs
    [SerializeField]
    private GameObject defaultCube;

    [SerializeField]
    private float speed;

    public bool cubesEnable;

    public int numberCubes;

    //cubes container
    private List<Cube> cubes = null; 

	void Start () {
	    cubes = new List<Cube>();
	    createCubes();
	}
    

	void Update () {
	    if (cubesEnable) {
            foreach (Cube cube in cubes) {
                cube.lifeCycle(speed);
            }
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
