using UnityEngine;
using System.Collections;

public class Cube {

    public GameObject GameObject { get; set; }
    public float Life { get; set; }
    public Color Color { get; set; }

    private float _alphaColor = 1.0f;

    public Cube(GameObject cubePrefab, Vector3 pos, Color cl, Transform parent = null) {
        this.GameObject = Object.Instantiate(cubePrefab, pos, Quaternion.identity);
        if (GameObject && parent)
        {
            GameObject.transform.SetParent(parent);
        }
        this.Life = Random.Range(5, 7);
        this.Color = cl;
    }

    //cycle
    public void LifeCycle(float speed) {

        //1- move cube
        Move(speed);

        //2- check if is dead
        if (IsDead()) 
            FadeOut();
    }

    //1- move the cube
    private void Move(float speed) {
            this.Life -= 10f * Time.deltaTime;
        this.GameObject.transform.position -= new Vector3(speed *2* Time.deltaTime, 0, 0);
    }

    private bool IsDead() {
        //se morri ou sai fora ecra
        if (this.Life < 0 || this.GameObject.transform.position.x<=-20) {
            return true;
        }
        return false;
    }

    //fade
    private void FadeOut() {
        _alphaColor -= Random.Range(0.05f, 0.1f);
        this.GameObject.GetComponent<Renderer>().material.color = new Color(Color.r, Color.r, Color.b, _alphaColor);

        if (_alphaColor < 0)
            ResetCube();
    }

    /*
    RESET CUBE
    new life
    new position
    new opacity
    */
    private void ResetCube() {
        //reset life
        this.Life = Random.Range(5, 7);

        //new position
        NewPosition();

        //reset opacity
        this._alphaColor = 1.0f;
        this.GameObject.GetComponent<Renderer>().material.color = new Color(Color.r, Color.r, Color.b, _alphaColor);
    }

    //generate new position
    private void NewPosition() {
        float x, y, z;

        x = Random.Range(-45, 72);
        y = Random.Range(-20, 47);
        z = Random.Range(20, 40);

        //reset position
        this.GameObject.transform.position = new Vector3(x, y, z);

        //for the fadeIn
        this._alphaColor = 0.5f;
    }
} 
