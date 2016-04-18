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


		case AnimationType.Special: //transposeobstacle
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
}
