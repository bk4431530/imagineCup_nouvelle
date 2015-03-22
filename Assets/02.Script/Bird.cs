using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {
	private Vector2 screenPosition;

	public Rigidbody2D rb;

	public bool RB = true;

	public GameObject player;
	public GameObject puzzle;

	public float player_pos;
	public float drop_pos;

	//sound
	public static AudioSource SFX_bird;

	void Start(){
		player = GameObject.Find ("player");

		SFX_bird = GameObject.Find ("/SFX/bird").GetComponent<AudioSource>();	
		SFX_bird.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("BirdTweet");
		
		
		


	}

	void FixedUpdate(){
		screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		if (player.transform.position.x > player_pos) {
			if (this.transform.position.x > drop_pos) {
				transform.Translate (new Vector3 (-0.12f, 0, 0));
			}
			else if (this.transform.position.x > drop_pos-1.5f) {
				if(RB){
					rb = puzzle.gameObject.AddComponent("Rigidbody2D") as Rigidbody2D;
					rb.gravityScale = 0.5f;
					RB = false;
					BirdSound ();
				}
				transform.Translate (new Vector3 (-0.12f, 0, 0));
			} else {
				transform.Translate (new Vector3 (-0.12f, 0, 0));
			}
			
			if(screenPosition.x < 0 || screenPosition.y > Screen.height+3)
			{
				this.gameObject.SetActive (false);
			}
		}

	}

	
	
	
	
	public void BirdSound()
	{
		if(GameManager.sfx)
		{
			SFX_bird.Play();
			Debug.Log(" BirdSound 함수실행");			
		}
		
	}


}
