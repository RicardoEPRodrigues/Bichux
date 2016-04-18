using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {

    public GameObject prefab { get; set; }
    public float life { get; set; }

    //private bool fadeInEnable = false;
    //private bool initFadeIn = false;

    private float alphaColor = 1.0f;

    public Cube(GameObject defaultCube, Vector3 pos) {
        this.prefab = Instantiate(defaultCube, pos, Quaternion.identity) as GameObject;
        this.life = Random.Range(5, 7);
    }

    //cycle
    public void lifeCycle(float speed) {

        //1- move cube
        move(speed);

        //2- check if is dead
        if (isDead()) 
            fadeOut();
    }

    //1- move the cube
    private void move(float speed) {
            this.life -= 0.1f;
            this.prefab.transform.position -= new Vector3(speed / 10, 0, 0);
    }

    private bool isDead() {
        //se morri ou sai fora ecra
        if (this.life < 0 || this.prefab.transform.position.x<=-20) {
            return true;
        }
        return false;
    }

    //fade
    private void fadeOut() {
        alphaColor -= Random.Range(0.05f, 0.1f);
        this.prefab.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, alphaColor);

        if (alphaColor < 0)
            resetCube();
    }

    /*
    RESET CUBE
    new life
    new position
    new opacity
    */
    private void resetCube() {
        //reset life
        this.life = Random.Range(5, 7);

        //new position
        newPosition();

        //reset opacity
        this.alphaColor = 1.0f;
        this.prefab.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, alphaColor);
    }

    //generate new position
    private void newPosition() {
        float x, y, z;

        x = Random.Range(-45, 72);
        y = Random.Range(-20, 47);
        z = Random.Range(20, 40);

        //reset position
        this.prefab.transform.position = new Vector3(x, y, z);

        //for the fadeIn
        this.alphaColor = 0.5f;
    }
} 
