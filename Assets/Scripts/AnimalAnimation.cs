using UnityEngine;
using System.Collections;

public class AnimalAnimation : MonoBehaviour {

	Animator animator;

	void Start()
	{
		animator = GetComponent <Animator>();

	}

	public void PickAnimation(int colAction)
	{

		switch (colAction)
		{

		case 1: //normalmovement
			animator.SetTrigger("Run");
			break;


		case 2: //transposeobstacle
			animator.SetTrigger("TransposeObstacle");
			break;


		case 3: //die
			animator.SetTrigger("Die");
			break;

		default:
			break;

		}

	}
}
