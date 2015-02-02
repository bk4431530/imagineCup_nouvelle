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
	
	private bool stageIs3 = false;
	private bool stageIs2 = false;
	
	public Vector2 jumpForce = new Vector2(2, 200);
	public Vector2 run = new Vector2(5,0);
	
	
	private GameObject collidedPen;
	private GameObject collidedPuzzle;
	
	public GameObject M_Cam;
	public GameObject bird;
	public GameObject puzzle;
	public GameObject toyFlight;
	
	public GameObject windEffect;
	
	
	public int Stage_Num = 0;
	
	public PlayerState PS = PlayerState.Normal;
	
	private Vector2 screenPosition;
	private Vector3 game_cam;
	private	Vector3 stage;
	
	
	public Vector3 clickedPos;
	
	Animator mAnimator;
	
	void Start()
	{
		PS = PlayerState.Normal;
		bird.gameObject.SetActive (false);
		puzzle.gameObject.SetActive (false);
		toyFlight.gameObject.SetActive (false);
		rigidbody2D.AddForce (jumpForce);
		mAnimator = gameObject.GetComponent<Animator> ();
	}
	
	
	void Update ()
	{
		screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		
		rigidbody2D.AddForce (run);

		if(PS == PlayerState.Normal && TouchHandler.swiped || Input.GetMouseButtonUp(0))
		{
			Jump();
			clickedPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
			Instantiate(windEffect, clickedPos, Quaternion.identity);
		}else{
			Destroy(GameObject.Find("wind(Clone)"));
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
			stageIs2 = true;
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
		rigidbody2D.velocity = Vector2.zero;
		rigidbody2D.AddForce (jumpForce);
		mAnimator.SetTrigger("up");
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
			
			Vector3 start_toy = new Vector3(17,2,-1);
			toyFlight.transform.position = start_toy;
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
