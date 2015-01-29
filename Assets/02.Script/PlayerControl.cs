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
	
	public Vector2 jumpForce = new Vector2(0, 100);
	public Vector2 run = new Vector2(5,0);
	

	private GameObject collidedPen;


	public GameObject M_Cam;
	public GameObject bird ;

	public int Stage_Num = 0;

	public PlayerState PS = PlayerState.Normal;

	private Vector2 screenPosition;
	private Vector3 game_cam;
	private	Vector3 stage;



	

	void Start()
	{
		PS = PlayerState.Normal;

		rigidbody2D.AddForce (jumpForce);
	}
	
	
	void Update ()
	{
		bird = GameObject.Find ("bird");

		screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		
		rigidbody2D.AddForce (run);

		Jump();

		StageChange ();

		Die ();
	}


	

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject == bird){

		}

		if (other.gameObject.name == "Quilpen") 
		{
			quilpens++;
			collidedPen =other.gameObject;
			Destroy(collidedPen);
		}

		if (other.gameObject.tag == "Obstacle")
		{
			PS = PlayerState.Collided;
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
