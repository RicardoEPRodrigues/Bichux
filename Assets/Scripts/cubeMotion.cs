using UnityEngine;
using System.Collections;

public class cubeMotion : MonoBehaviour {

    public Transform cubeTransform;

    float rx, ry, rz, sum, dir;
    Vector3 pos;
    
   
   void Start()
    {
        Debug.Log("h");
        rx = ry = rz = sum = 0;
        dir = Random.Range(-0.1F, 0.1F);
    }
	// Update is called once per frame
	void Update () {
        cubeTransform.Rotate(rx, 0, rz);
        rz = Time.deltaTime * Random.Range(0.0F, 40.0F); 
        ry = Time.deltaTime * Random.Range(0.0F, 40.0F);
        rx = Time.deltaTime * Random.Range(0.0F, 40.0F);

        pos = cubeTransform.position;
        sum += Time.deltaTime;
        pos.y = pos.y + dir*Mathf.Sin(sum);
        cubeTransform.position = pos;


    }
}
