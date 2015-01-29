using UnityEngine;
using System.Collections;

public class Puzzle : MonoBehaviour {
	public Rigidbody2D rb;
	private Vector2 screenPosition;

	public bool RB = true;

	void Update(){
		screenPosition = Camera.main.WorldToScreenPoint(transform.position);

		if (this.transform.position.x > 25.6) {
			transform.Translate (new Vector2 (0.06f, 0));
		}
		else if(RB) {
			rb = this.gameObject.AddComponent("Rigidbody2D") as Rigidbody2D;
			rb.gravityScale = 0.5f;

			RB = false;
		}

		if(screenPosition.y < -1)
		{
			this.gameObject.SetActive (false);
		}
	}
}