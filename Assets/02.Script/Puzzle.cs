using UnityEngine;
using System.Collections;

public class Puzzle : MonoBehaviour {
	public Rigidbody2D rb;
	private Vector2 screenPosition;

	public GameObject player;

	public bool RB = true;

	public float player_pos;
	public float drop_pos;

	void Start(){
		player = GameObject.Find ("player");
	}

	void Update(){
		screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		if (player.transform.position.x > player_pos) {
			if (this.transform.position.x > drop_pos) {
				transform.Translate (new Vector3 (-0.12f, 0, 0));
			}

			else if(RB) {
				//rb = this.gameObject.AddComponent("Rigidbody2D") as Rigidbody2D;
				//rb.gravityScale = 0.5f;
				
				RB = false;
			}
		}

		if(screenPosition.y < -1)
		{
			this.gameObject.SetActive (false);
		}
	}
}