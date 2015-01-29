using UnityEngine;
using System.Collections;



public class PlayerControl : MonoBehaviour {

	public enum PlayerState
	{
		Normal,
		Collided,
		CatchedByCat,
		CatchedByTree,
		CatchedByBubble	
	}

	public static int life = 3;
	public static int quilpens = 0;
	public static int puzzles = 0;

	private bool bp_state = false;

	public Vector2 jumpForce = new Vector2(0, 100);
	public Vector2 run = new Vector2(5,0);
	

	private GameObject collidedPen;
	private GameObject collidedPuzzle;

	public GameObject M_Cam;
	public GameObject bird;
	public GameObject puzzle;

	public int Stage_Num = 0;

	public PlayerState PS = PlayerState.Normal;

	private Vector2 screenPosition;
	private Vector3 game_cam;
	private	Vector3 stage;



	

	void Start()
	{
		PS = PlayerState.Normal;
		bird.gameObject.SetActive (false);
		puzzle.gameObject.SetActive (false);
		rigidbody2D.AddForce (jumpForce);
	}
	
	
	void Update ()
	{
		screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		
		rigidbody2D.AddForce (run);

		Jump();

		StageChange ();

		Die ();

		if (Stage_Num == 2 && !bp_state) {
			bird.gameObject.SetActive (true);
			puzzle.gameObject.SetActive (true);
			bp_state = true;
		}
	}


	

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Quilpen") 
		{
			quilpens++;
			collidedPen = other.gameObject;
			Destroy(collidedPen);
		}

		if (other.gameObject.tag == "Obstacle")
		{
			PS = PlayerState.Collided;
		}

		if (other.gameObject.name == "puzzle") 
		{
			puzzles++;
			collidedPuzzle = other.gameObject;
			Destroy (collidedPuzzle);
		}
	}


	void Jump()
	{
		if(PS == PlayerState.Normal)
		{
			if (Application.platform == RuntimePlatform.Android) 
			{
				if (TouchHandler.swiped) 
				{
					rigidbody2D.velocity = Vector2.zero;
					rigidbody2D.AddForce (jumpForce);
				}
			}
			else 
			{
				if (Input.GetMouseButtonUp(0)) 
				{
					rigidbody2D.velocity = Vector2.zero;
					rigidbody2D.AddForce (jumpForce);
				}
			}
		}
			

	}


	void Die()
	{
		if (life < 1) 
		{
			Time.timeScale = 0;
		} 
		else if ((life > 0 && screenPosition.y > Screen.height || screenPosition.y < 0) || (life > 0 && PS == PlayerState.Collided)) 
		{
			PS = PlayerState.Normal;
			stage = new Vector3 (0, 0, -1);
			stage.x = 12.8f * Stage_Num - 6.4f;
			this.transform.position = stage;
			life--;
		}
	}



	void StageChange(){

		//Stage Change
		if (PS == PlayerState.Normal && screenPosition.x > Screen.width)
		{
			M_Cam.transform.Translate(new Vector3 (12.8f,0,0));
			Stage_Num++;
		}

	}



}
