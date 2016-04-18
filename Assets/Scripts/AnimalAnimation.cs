using UnityEngine;
using System.Collections;

public class AnimalAnimation : MonoBehaviour {

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
        player.Locked = true;
        switch (colAction)
		{

		case AnimationType.Run: //normalmovement
			animator.SetTrigger("Run");
			break;


		case AnimationType.Special: //special
			animator.SetTrigger("Special");
			break;


		case AnimationType.Crash: //crash
			animator.SetTrigger("Crash");
			break;

		case AnimationType.Fall: //fall
			animator.SetTrigger("Fall");
			break;

		default:
			break;

		}

	}

	public void Landed(){
		animator.SetTrigger("Run");
        player.Locked = false;
	}

	public void OnDie(){
		GameManager.GetInstance().OnDie();


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
			
		deathParticles.Emit(Vector3.zero, Vector3.up, 0.2f, 2f, Color.yellow);
	}
}
