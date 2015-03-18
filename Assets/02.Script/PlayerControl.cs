using UnityEngine;
using System.Collections;



public class PlayerControl : MonoBehaviour {
	
	public enum PlayerState
	{
		Normal,
		Collided,
	}
	
	public static PlayerState PS;
	public PlayerState test_PS = PS;
	
	
	public int Stage_Num = 0;
	
	public GameObject particle;
	
	private bool stageIs3 = false;
	private bool stageIs2 = false;
	
	public Vector2 jumpForce = new Vector2(4, 300);
	public Vector2 run = new Vector2(4,0);
	
	private Vector3 diePos;
	
	private GameObject collidedPen;
	private GameObject collidedPuzzle;
	
	private GameObject M_Cam;
	
	private GameObject magnet;
	
	private Vector2 screenPosition;
	private Vector3 game_cam;
	private Vector3 stage;

	Animator mAnimator;
	Animator boyAnimator;
	
	public static bool finish = false;
	
	//item
	bool boosterShield;
	Vector3 startPos;
	Vector3 boosterEndPos;
	bool shield;
	int shieldCount = 3;
	public static bool MultipleFeather = false;

	private bool isClear;
	private bool isOut;
	private bool isRevival;
	private bool isOver;

	public GameObject finish_popup;

	//sound effect


	public static AudioSource SFX_piece;
	public static AudioSource SFX_obstacle;
	public static AudioSource SFX_die;


	public GameObject puzzleEffect;


	
	
	void Awake()
	{
		M_Cam = GameObject.Find ("Main Camera");
		
		magnet = GameObject.Find ("magnet");
		magnet.gameObject.SetActive(false);
		
		
		PS = PlayerState.Normal;
		Debug.Log ("state : " + PS);

		rigidbody2D.AddForce (new Vector2 (60, 300));
		
		mAnimator = gameObject.GetComponent<Animator> ();
		boyAnimator = GameObject.Find ("boy").GetComponent<Animator> ();

		startPos = this.transform.position;
		
		PS = PlayerState.Normal;
		finishGame.pass =false;
		isClear = false;
		isOut = false;
		isRevival = false;
		isOver = false;
		//GameManager.booster_equip = true;
		//GameManager.paperPlaneState = 0;
	}

	void Start()
	{
		GameManager.magnet_equip = true;

		//sound effect

		
	

		SFX_piece = GameObject.Find ("/SFX/piece").GetComponent<AudioSource> ();
		SFX_piece.GetComponent<AudioSource> ().clip = (AudioClip)Resources.Load ("PieceGet");

		SFX_obstacle = GameObject.Find ("/SFX/obstacle").GetComponent<AudioSource> ();
		SFX_obstacle.GetComponent<AudioSource> ().clip = (AudioClip)Resources.Load ("Plane_hit");

		SFX_die = GameObject.Find ("/SFX/die").GetComponent<AudioSource> ();
		SFX_die.GetComponent<AudioSource> ().clip = (AudioClip)Resources.Load ("GameOver");

	

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
			
			if(transform.position.x<30)
			{
				boosterShield =true;
				boosterEndPos =  new Vector3(30,startPos.y,startPos.z);
				transform.position = Vector3.Lerp(startPos,boosterEndPos,Time.timeSinceLevelLoad);
				this.renderer.material.color = Color.red;
				
			}else{
				boosterShield =false;
				this.renderer.material.color = Color.white;      
				rigidbody2D.AddForce (new Vector2 (60, 400));
				GameManager.booster_equip =false;
				
				
				
			}
		}
		
		

		screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		
		if(PS == PlayerState.Normal)
		{
			if(TouchHandler.Mswiped == true)
			{
				Jump();
			}
			else 
			{
				rigidbody2D.AddForce (run);
			}
		} 
		else if(PS == PlayerState.Collided)
		{
			transform.position = diePos;
		}

		
		//StageChange ();
		
		Die ();
		
		//pass
		if (isClear && !finish) 
		{
			transform.position = diePos;
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
			gameObject.GetComponent<PolygonCollider2D>().enabled = false;
			Invoke("clearGame",4.0f);
			boyAnimator.SetTrigger ("ending");
		}
		
		
	}
	
	
	
	
	void OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.gameObject.tag == "Obstacle" && !isRevival)
		{
			//Vibration -duration: 1 second
			//*****************************
			if(GameManager.vibration == true)
			{
				Handheld.Vibrate ();

			}
			//sound
			ObstacleSound();
			//*****************************
			if(shield){
				this.renderer.material.color = Color.blue;
				PS = PlayerState.Normal;
				shieldCount--;
				Debug.Log(shieldCount);
			}else if(boosterShield){
				PS = PlayerState.Normal;
			}
			else{
				PS = PlayerState.Collided;
				diePos = transform.position;
				this.GetComponent<PolygonCollider2D> ().enabled = false;
				mAnimator.SetTrigger("collid");
				Invoke("whenDie", 0.8f);
			}
		}else{
			PS = PlayerState.Normal;
			this.renderer.material.color = Color.white;
			
		}
		
		if (other.gameObject.tag == "Puzzle") 
		{
			GameManager.currentPiece++;
			collidedPuzzle = other.gameObject;
			Instantiate (particle, collidedPuzzle.transform.position, collidedPuzzle.transform.rotation);
			//Destroy(particle,0.5f);
			collidedPuzzle.SetActive(false);
			PieceSound();
		}

		if (other.gameObject.name == "finish_collider") 
		{
			diePos = transform.position;
			Debug.Log("finish collided");
			isClear = true;
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
			if(!isOver){
				DieSound();
				isOver = true;
			}
			Time.timeScale = 0;
			finish=true;
		} 
		else if ((GameManager.currentLife > 0 && screenPosition.y > Screen.height || screenPosition.y < 0) && !isOut)//|| (life > 0 && PS == PlayerState.Collided)) 
		{
			PS = PlayerState.Collided;
			diePos = transform.position;
			mAnimator.SetTrigger("collid");
			Invoke("whenDie", 0.8f);
			isOut = true;
		}
	}

	Vector3 diePlanePos;

	public void whenDie()
	{
		isOut = false;
		diePlanePos = transform.position;
		PS = PlayerState.Normal;
		/*
		stage = new Vector2 (0, 0);
		stage.x = 12.8f * Stage_Num;
		if(Stage_Num == 0){ stage.x -= 5.5f; } else { stage.x -= 6.4f; }
		stage.y = -0.35f;
		*/

		Vector3 repos = new Vector3 (diePlanePos.x,0.5f , 5);
		this.transform.position = repos;
		GameManager.currentLife--;
		this.renderer.material.color = Color.white;

		this.GetComponent<PolygonCollider2D> ().enabled = true;

		rigidbody2D.isKinematic = true;
		rigidbody2D.isKinematic = false;
		rigidbody2D.AddForce (new Vector2 (0, 300));

		isRevival = true;
		Invoke ("Revival", 1.5f);
	}
	
	void Revival(){
		isRevival = false;
	}
	
	/*
	void StageChange(){
		
		//Stage Change
		if (PS == PlayerState.Normal && screenPosition.x > Screen.width)
		{
			//M_Cam.transform.Translate(new Vector3 (12.8f,0,-10));
			Stage_Num++;
		}
		
	}
	*/
	void clearGame(){
		finishGame.pass =true;
		Time.timeScale = 0;
		finish = true;
		isClear = false;
	}

	//Soundeffect

	/*
	 * 
	 * 	public static AudioSource SFX_bird;
	public static AudioSource SFX_cat;
	public static AudioSource SFX_quillpen;
	public static AudioSource SFX_piece;
	public static AudioSource SFX_obstacle;
	public static AudioSource SFX_die;
	public static AudioSource SFX_popup;

*/






	public void PieceSound()
	{
		if(GameManager.sfx)
		{
			SFX_piece.Play();
			Debug.Log(" PieceSound 함수실행");			
		}
		
	}

	public void ObstacleSound()
	{
		if(GameManager.sfx)
		{
			SFX_obstacle.Play();
			Debug.Log("서 ObstacleSound 함수실행");			
		}
		
	}

	public void DieSound()
	{
		if(GameManager.sfx)
		{
			SFX_die.Play();
			Debug.Log(" DieSound 함수실행");
			
		}
		
	}

}


