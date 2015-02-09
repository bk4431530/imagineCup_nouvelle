using UnityEngine;
using System.Collections;



public class PlayerControl : MonoBehaviour {
	
	public enum PlayerState
	{
		Normal,
		Collided
	}
	
	public static int life = 5;
	public static int quilpens = 0;
	public static int puzzles = 0;

	public static PlayerState PS;
	public PlayerState test_PS = PS;

	public int Stage_Num = 0;

	
	private bool stageIs3 = false;
	private bool stageIs2 = false;
	
	public Vector2 jumpForce = new Vector2(4, 300);
	public Vector2 run = new Vector2(4,0);

	private GameObject collidedPen;
	private GameObject collidedPuzzle;
	
	private GameObject M_Cam;
	private GameObject bird;
	private GameObject puzzle;
	private GameObject toyFlight;

	private GameObject line2;
	private GameObject line3;
	
	private Vector2 screenPosition;
	private Vector3 game_cam;
	private Vector3 stage;

	private LineRenderer lineRender;
	private int numberOfPoints = 0;
	
	
	Animator mAnimator;
	Animator line2_Animator;
	Animator line3_Animator;

	Animator toyFlight_Animator;

	void Start()
	{
		M_Cam = GameObject.Find ("Main Camera");
		bird = GameObject.Find ("bird");
		puzzle = GameObject.Find ("puzzle");
		toyFlight = GameObject.Find ("toyFlight");

		line2 = GameObject.Find("2nd_line");
		line3 = GameObject.Find("3rd_line");

		PS = PlayerState.Normal;
		Debug.Log ("state : " + PS);

		bird.gameObject.SetActive (false);
		puzzle.gameObject.SetActive (false);
		toyFlight.gameObject.SetActive (false);
		rigidbody2D.AddForce (new Vector2 (60, 300));

		mAnimator = gameObject.GetComponent<Animator> ();
		line2_Animator = line2.gameObject.GetComponent<Animator> ();
		line3_Animator = line3.gameObject.GetComponent<Animator> ();
		toyFlight_Animator = toyFlight.gameObject.GetComponent<Animator> ();
		lineRender = GameObject.Find ("lineRenderer").GetComponent<LineRenderer> ();

		PS = PlayerState.Normal;
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
			toyFlight_Animator.SetTrigger("show");
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
		}else{
			PS = PlayerState.Normal;
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
		life--;
		
		rigidbody2D.isKinematic = true;
		rigidbody2D.isKinematic = false;
		rigidbody2D.AddForce (new Vector2 (0, 300));
		
		toyFlight_Animator.SetTrigger("reset");
		toyFlight_Animator.SetTrigger("show");
		Vector3 start_toy = new Vector3(19.2f,3,0);
		toyFlight.transform.position = start_toy;
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