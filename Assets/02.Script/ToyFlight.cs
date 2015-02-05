using UnityEngine;
using System.Collections;

public class ToyFlight : MonoBehaviour {
	private Vector2 screenPosition;

	Animator mAnimator;

	void Start(){
		mAnimator = this.gameObject.GetComponent<Animator> (); 
	}

	void Update(){
		screenPosition = Camera.main.WorldToScreenPoint(transform.position);

		if(screenPosition.x < -1)
		{
			mAnimator.SetTrigger("reset");
			this.gameObject.SetActive(false);
		}
	}
}

