using UnityEngine;
using System.Collections;



public class PlayerControl : MonoBehaviour {
	
	public enum PlayerState
	{
		Normal,
		Collided,
		Boostered
	}
	
	public static PlayerState PS;
	public PlayerState test_PS = PS;
	
	
	public int Stage_Num = 0;
	
	public GameObject particle;
	
	private bool stageIs3 = false;
	private bool stageIs2 = false;
	
	public Vector2 jumpForce = new Vector2(4, 300);
	public Vector2 run = new Vector2(4,0);
	
	private Vector2 diePos;
	
	private GameObject collidedPen;
	private GameObject collidedPuzzle;
	
	private GameObject M_Cam;
	private GameObject bird;
	private GameObject puzzle;
	private GameObject toyFlight;
	
	private GameObject magnet;
	
	private Vector2 screenPosition;
	private Vector3 game_cam;
	private Vector3 stage;
	
	
	Animator mAnimator;
	
	
	Animator toyFlight_Animator;
	
	public static bool finish = false;
	
	//item
	bool boosterShield;
	Vector3 startPos;
	Vector3 boosterEndPos;
	bool shield;
	int shieldCount = 3;
	public static bool MultipleFeather = false;
	
	
	public GameObject finish_popup;
	
	
	void Start()
	{
		M_Cam = GameObject.Find ("Main Camera");
		bird = GameObject.Find ("bird");
		puzzle = GameObject.Find ("puzzle");
		toyFlight = GameObject.Find ("toyFlight");
		
		magnet = GameObject.Find ("magnet");
		magnet.gameObject.SetActive(false);
		
		
		PS = PlayerState.Normal;
		Debug.Log ("state : " + PS);
		
		bird.gameObject.SetActive (false);
		puzzle.gameObject.SetActive (false);
		toyFlight.gameObject.SetActive (false);
		rigidbody2D.AddForce (new Vector2 (60, 300));
		
		mAnimator = gameObject.GetComponent<Animator> ();
		toyFlight_Animator = toyFlight.gameObject.GetComponent<Animator> ();
		
		startPos = this.transform.position;
		
		PS = PlayerState.Normal;
		finishGame.pass =false;

	}
	
	
	void Update ()
	{
		/******************************************************bokyung's fixing part************************************************/
		

		
		
		if(GameManager.magnet_equip)
		{
			magnet.gameObject.SetActive(true);
		}else{
			magnet.gameObject.SetActive(false);
			
		}
		
		if(GameManager.shield_equip)
		{
			if(shieldCount>0){
				//sheildEffect.SetActive(true);
			}else if(shieldCount <= 0){
				//sheildEffect.SetActive(false);
				shield = false;
			}
		}
		
		
		if (GameManager.booster_equip) 
		{
			if(M_Cam.transform.position.x<40)
			{
				boosterShield =true;
				boosterEndPos =  new Vector3(40,startPos.y,startPos.z);
				transform.position = Vector3.Lerp(startPos,boosterEndPos,Time.time);
				this.renderer.material.color = Color.red;
				
			}else{
				boosterShield =false;
				this.renderer.material.color = Color.white;		
				rigidbody2D.AddForce (new Vector2 (60, 400));
				GameManager.booster_equip =false;


				
			}
		}
		
		
		/******************************************************bokyung's fixing part************************************************/
		
		
		screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		
		if(PS == PlayerState.Normal)
		{
			if(TouchHandler.Mswiped == true)
			{
				Jump();
			}else{
				rigidbody2D.AddForce (run);
			}
		} 
		else if(PS == PlayerState.Collided)
		{
			transform.position = diePos;
		}
		
		
		
		
		StageChange ();
		
		Die ();
		
		if (Stage_Num == 2 && !stageIs3) {
			bird.gameObject.SetActive (true);
			puzzle.gameObject.SetActive (true);
			stageIs3 = true;
		}
		
		if (Stage_Num == 1 && !stageIs2) {
			toyFlight.gameObject.SetActive (true);
			toyFlight_Animator.SetTrigger("show");
			stageIs2 = true;
		}
		
		
		
		
		
		
		
		//pass
		if (Stage_Num > 5 && GameManager.currentLife > 0) 
		{
			finishGame.pass =true;
			Time.timeScale = 0;
			finish = true;
			finishGame.pass = true;
			
		}
		
		
	}
	
	
	
	
	void OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.gameObject.tag == "Obstacle")
		{
			//Vibration -duration: 1 second
			//*****************************
			if(GameManager.vibration == true)
			{
				Handheld.Vibrate ();
			}
			//*****************************
			if(shield){
				this.renderer.material.color = Color.blue;
				PS = PlayerState.Normal;
				shieldCount--;
				Debug.Log(shieldCount);
			}else if(boosterShield){
				PS = PlayerState.Boostered;
			}
			else{
				PS = PlayerState.Collided;
				diePos = transform.position;
				mAnimator.SetTrigger("collid");
				Invoke("whenDie", 0.8f);
			}
		}else{
			PS = PlayerState.Normal;
			this.renderer.material.color = Color.white;
			
		}
		
		if (other.gameObject.name == "puzzle") 
		{
			GameManager.currentPiece++;
			collidedPuzzle = other.gameObject;
			Destroy (collidedPuzzle);
		}
	}
	
	void Jump()
	{
		rigidbody2D.velocity = Vector2.zero;
		rigidbody2D.AddForce (jumpForce);
		
		mAnimator.SetTrigger("up");
		
	}
	
	
	void Die()
	{
		if (GameManager.currentLife < 1) 
		{
			Time.timeScale = 0;
			finish=true;
		} 
		else if ((GameManager.currentLife > 0 && screenPosition.y > Screen.height || screenPosition.y < 0))//|| (life > 0 && PS == PlayerState.Collided)) 
		{
			whenDie ();
		}
	}
	
	public void whenDie()
	{
		PS = PlayerState.Normal;
		stage = new Vector2 (0, 0);
		stage.x = 12.8f * Stage_Num;
		if(Stage_Num == 0){ stage.x -= 5.5f; } else { stage.x -= 6.4f; }
		stage.y = -0.35f;
		this.transform.position = stage;
		GameManager.currentLife--;
		this.renderer.material.color = Color.white;
		
		
		rigidbody2D.isKinematic = true;
		rigidbody2D.isKinematic = false;
		rigidbody2D.AddForce (new Vector2 (0, 300));
		
		toyFlight.gameObject.SetActive (true);
		Vector3 start_toy = new Vector3(19.2f,3,0);
		toyFlight.transform.position = start_toy;
		toyFlight_Animator.SetTrigger("reset");
		toyFlight_Animator.SetTrigger("show");
	}
	
	
	
	
	void StageChange(){
		
		//Stage Change
		if (PS == PlayerState.Normal && screenPosition.x > Screen.width)
		{
			//M_Cam.transform.Translate(new Vector3 (12.8f,0,-10));
			Stage_Num++;
		}
		
	}
	
	
	
}



