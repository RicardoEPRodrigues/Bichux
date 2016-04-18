using UnityEngine;
using System.Collections;

public class AnimalAnimation : MonoBehaviour {

    public Player player;
	public Animator animator;

	void Start()
	{
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
	}
}
