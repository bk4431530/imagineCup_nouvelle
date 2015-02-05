using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {
	private Vector2 screenPosition;

	public Rigidbody2D rb;

	public bool RB = true;

	public GameObject puzzle;

	void Start(){
		puzzle = GameObject.Find ("puzzle");
	}

	void Update(){
		screenPosition = Camera.main.WorldToScreenPoint(transform.position);

		if (this.transform.position.x > 26.6) {
			transform.Translate (new Vector2 (-0.075f, 0));
		}
		else if (this.transform.position.x > 25.6) {
			if(RB){
				rb = puzzle.gameObject.AddComponent("Rigidbody2D") as Rigidbody2D;
				rb.gravityScale = 0.5f;
				RB = false;
			}
			transform.Translate (new Vector2 (-0.075f, 0));
		} else {
			transform.Translate (new Vector2 (-0.02f, 0.02f));
		}

		if(screenPosition.x < 0 || screenPosition.y > Screen.height+3)
		{
			this.gameObject.SetActive (false);
		}
	}
}
