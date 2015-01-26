using UnityEngine;
using System.Collections;

public enum PlayerState
{
	Normal,
	Catched
}

public class PlayerControl : MonoBehaviour {

	public static int life = 3;
	public static int quilpens = 0;
	
	public Vector2 jumpForce = new Vector2(0, 300);
	public Vector2 run = new Vector2(5,0);
	
	private GUIText scoreReference;
	private GUIText itemReference;
	private GameObject collidedPen;


	public GameObject M_Cam;
	public GameObject bird ;

	public int Stage_Num = 0;

	public PlayerState PS = PlayerState.Normal;

	private Vector2 screenPosition;
	private Vector3 game_cam;
	private Vector3 bonus_cam;
	private	Vector3 stage;
	private Vector3 bonus;


	

	void Start()
	{
	}
	
	
	void Update ()
	{
		bird = GameObject.Find ("bird");
		scoreReference = GameObject.Find("life").guiText;
		itemReference = GameObject.Find ("items").guiText;


		scoreReference.text = (life).ToString();
		itemReference.text =(quilpens).ToString();

		screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		
		rigidbody2D.AddForce (run);

		Jump();

		StageChange ();
		Die ();


							
	}



	void OnCollisionEnter2D(Collision2D other)
	{
		
		if (other.gameObject.name == "obstacle") 
		{
			Die();
		}


	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject == bird){

			rigidbody2D.WakeUp ();
			PS = PlayerState.Catched;
			bonus_cam = new Vector3 (40,7.5f,-10);
			M_Cam.transform.position = bonus_cam;
			bonus = new Vector3 (33.6f, 7.5f, 0);
			this.transform.position = bonus;
		}

		if (other.gameObject.name == "Quilpen") 
		{
			quilpens++;
			collidedPen =other.gameObject;
			Destroy(collidedPen);
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
			
			
		if(PS == PlayerState.Catched)
		{
			if (Application.platform == RuntimePlatform.Android) 
			{		
				if(TouchHandler.touched)
				{
					rigidbody2D.velocity = Vector2.zero;
					rigidbody2D.AddForce (jumpForce);
				}
			}
			else 
			{
				if (Input.GetMouseButton(0)) 
				{
					rigidbody2D.velocity = Vector2.zero;
					rigidbody2D.AddForce (jumpForce);
				}
			}
		}
	}
	}


	void Die()
	{
		if (life < 1) 
		{
			scoreReference.text = "dead";
			Time.timeScale = 0;
		} 
		else if (life > 0 && screenPosition.y > Screen.height || screenPosition.y < 0) 
		{
			stage = new Vector3 (0, 0, 0);
			stage.x = 12.8f * Stage_Num;
			this.transform.position = stage;
			life--;
		}
	}



	void StageChange(){
		//screenPosition = Camera.main.WorldToScreenPoint(transform.position);

		//Stage Change
		if (PS == PlayerState.Normal && screenPosition.x > Screen.width)
		{
			M_Cam.transform.Translate(new Vector3 (12.8f,0,0));
			Stage_Num++;
		}

		
		
		if (PS == PlayerState.Catched && screenPosition.x > Screen.width)
		{
			Destroy (bird);
			Stage_Num++;
			game_cam = new Vector3(12.8f*Stage_Num-6.4f,0,-10);
			M_Cam.transform.position = game_cam;
			
			stage = new Vector3 (0, 0, 0);
			stage.x = 12.8f * Stage_Num;
			this.transform.position = stage;
			
			PS = PlayerState.Normal;
		}
	}



}
