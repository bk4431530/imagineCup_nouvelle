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
	
	public static int life = 5;
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
	
	public int Stage_Num = 0;

	public GameObject line2;
	public GameObject line3;

	public PlayerState PS = PlayerState.Normal;
	
	private Vector2 screenPosition;
	private Vector3 game_cam;
	private   Vector3 stage;
	
	public Vector3 clickedPos;
	
	public LineRenderer lineRender;
	private int numberOfPoints = 0;
	
	
	Animator mAnimator;
	Animator line2_Animator;
	Animator line3_Animator;

	void Start()
	{
		M_Cam = GameObject.Find ("Main Camera");
		bird = GameObject.Find ("bird");
		puzzle = GameObject.Find ("puzzle");
		toyFlight = GameObject.Find ("toyFlight");

		line2 = GameObject.Find("2nd_line");
		line3 = GameObject.Find("3rd_line");

		PS = PlayerState.Normal;
		bird.gameObject.SetActive (false);
		puzzle.gameObject.SetActive (false);
		toyFlight.gameObject.SetActive (false);
		rigidbody2D.AddForce (jumpForce);

		mAnimator = gameObject.GetComponent<Animator> ();
		line2_Animator = line2.gameObject.GetComponent<Animator> ();
		line3_Animator = line3.gameObject.GetComponent<Animator> ();
	}
	
	
	void Update ()
	{
		screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		

		if(PS == PlayerState.Normal && TouchHandler.swiped || Input.GetMouseButton(0))
		{
			numberOfPoints++;
			lineRender.SetVertexCount( numberOfPoints );
			Vector3 mousePos = new Vector3(0,0,0);
			mousePos = Input.mousePosition;
			mousePos.z = 1.0f;
			Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
			lineRender.SetPosition(numberOfPoints - 1, worldPos);
		}else if(PS == PlayerState.Normal && TouchHandler.ended || Input.GetMouseButtonUp(0)) {
			Jump();
		}else{
			rigidbody2D.AddForce (run);
			
			numberOfPoints = 0;
			lineRender.SetVertexCount(0);
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
		line2_Animator.SetTrigger ("up");
		line3_Animator.SetTrigger ("up");
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