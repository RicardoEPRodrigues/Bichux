using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CubesGenerator : MonoBehaviour
{
    //standard prefab
    [SerializeField] private GameObject _cubePrefab;

    //cubes number
    public int NumberCubes;

    //refernece to manager
    private GameManager _manager;

    //cubes container
    private List<Cube> _cubes = null;
    [SerializeField] private List<Color> _colours = null;

    void Start()
    {
        if (_colours == null || _colours.Count == 0)
        {
            _colours = new List<Color>();
            _colours.Add(new Color(0.56f, 0.56f, 0.56f, 1.0f));
            _colours.Add(new Color(1.0f, 1.0f, 0.33f, 1.0f));
            _colours.Add(new Color(0.92f, 0.42f, 0.6f, 1.0f));
        }

        _cubes = new List<Cube>();
        CreateCubes();

        //reference to manager
        _manager = GameManager.GetInstance();
    }


    void Update()
    {
        foreach (Cube cube in _cubes)
        {
            cube.LifeCycle(_manager.generator.speedChanger.Speed);
        }
    }

    private void CreateCubes()
    {
        float x, y, z;
        for (int i = 0; i < NumberCubes; i++)
        {
            x = Random.Range(-45, 72);
            y = Random.Range(-20, 47);
            z = Random.Range(20, 40);

            _cubes.Add(new Cube(_cubePrefab, new Vector3(x, y, z), _colours[Random.Range(0, _colours.Count)],
                gameObject.transform));
        }
    }
}