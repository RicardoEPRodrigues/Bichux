using UnityEngine;
using System.Collections;

public class AnimalAnimation : MonoBehaviour
{

    public Player player;
	public Animator animator;
	public ParticleSystem deathParticles;
	public GameObject partObj;
	private int particleInt;

	void Start()
	{
		deathParticles = partObj.GetComponent<ParticleSystem> ();
	}

    public void PickAnimation(AnimationType colAction)
    {
        switch (colAction)
        {

            case AnimationType.Run: //normalmovement
                animator.SetTrigger("Run");
                break;


            case AnimationType.Special: //special
                player.Locked = true;
                animator.SetTrigger("Special");
                break;


            case AnimationType.Crash: //crash
                player.Locked = true;
                animator.SetTrigger("Crash");
                break;

            case AnimationType.Fall: //fall
                player.Locked = true;
                animator.SetTrigger("Fall");
                break;

            default:
                break;

        }

    }

    public void Landed()
    {
        animator.SetTrigger("Run");
        player.Locked = false;
    }
    
	public void OnDie(){
		GameManager.GetInstance().OnDie();
		deathParticles.Emit (particleInt);


		switch (GameManager.GetInstance().player.status) {

		case AnimalTypes.Worm:
			particleInt = 5;
			break;

		case AnimalTypes.Bunny:
			particleInt = 15;
			break;

		case AnimalTypes.Elephant:
			particleInt = 30;
			break;

		default:
			break;
		}
	}
}
