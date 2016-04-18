using UnityEngine;
using System.Collections;

public class AnimalAnimation : MonoBehaviour {

	Animator animator;

	void Start()
	{
		animator = GetComponent <Animator>();
	}

	public void PickAnimation(AnimationType colAction)
	{

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
	}

	public void OnDie(){
		GameManager.GetInstance().OnDie();
		switch (GameManager.GetInstance().player.status) {
		case AnimalTypes.Bunny:

			break;
		default:
			break;
		}
	}
}
