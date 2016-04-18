using UnityEngine;
using System.Collections;

public class BolderCollision : MonoBehaviour {

    public ColliderWrapper colliderWrapper = null;
    public Animator boulderAnimator = null;


	// Use this for initialization
	void Start () {
        colliderWrapper.onCollisionEnter = this.OnCollisionBoxEnter;
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void OnCollisionBoxEnter(Collider col)
    {
        Player player = GameManager.GetInstance().player;
        if (player && (player.status == AnimalTypes.Elephant || player.status == AnimalTypes.Unicorn))
        {
            bool isPlayerCollision = false;
            foreach (GameObject animal in player.animals)
            {
                if (col.gameObject == animal)
                {
                    isPlayerCollision = true;

                    /*
                    animalAnimation = col.gameObject.GetComponent<AnimalAnimation>();
                    animalAnimation.PickAnimation(colliderAction);
                    */

                }
            }
            if (isPlayerCollision)
            {
                boulderAnimator.SetTrigger("Destroy");

                this.colliderWrapper.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }

    public void OnEndAnimation()
    {
        gameObject.SetActive(false);
    }

}
