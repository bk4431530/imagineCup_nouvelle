using UnityEngine;
using System.Collections;

public enum PlayerState_cat
{
	Free,
	CatchedByCat
	
}

public class CatchedbyCat : MonoBehaviour{
	
	
	public GameObject cat;
	public GameObject player;
	public GameObject wind;
	
	public PlayerState_cat PS_cat = PlayerState_cat.Free;
	
	
	
	public static int clickCount = 0;
	public static bool isDestroyed = false;
	
	private Vector2 pos;
	private RaycastHit2D hit;
	
	private Vector2 catPos;
	
	Animator cat_Animator;
	
	public float catTime;
	
	void Awake()
	{
		catTime = 0.0f;
	}
	
	void Start()
	{
		cat = GameObject.Find ("cat");
		player = GameObject.Find ("player");
		PS_cat = PlayerState_cat.Free;
		
		cat_Animator = cat.gameObject.GetComponent<Animator> ();
	}
	
	
	void Update () 
	{
		rigidbody2D.WakeUp ();
		
		if (PS_cat ==  PlayerState_cat.CatchedByCat)
		{
			cat_Animator.SetTrigger("catch");
			catPos = cat.transform.position;
			transform.position = new Vector3(catPos.x-1 ,catPos.y, -1);         
			rigidbody2D.isKinematic = true;   
		}
		
		
		pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		hit = Physics2D.Raycast(pos, Vector2.zero);
		
		if (hit != null && hit.collider != null && cat.collider2D != null) 
		{
			if (hit.collider.name == cat.collider2D.name
			    && Input.GetMouseButtonDown(0) == true
			    &&  PS_cat ==  PlayerState_cat.CatchedByCat)
			{
				//Vibration -duration: 1 second
				//*****************************
				Handheld.Vibrate ();
				//*****************************
				cat_Animator.SetTrigger("tap");
				clickCount ++;
				Debug.Log ("clickCount = " + clickCount);   
				
			}//hit collider
		}//hit null
		
		if (clickCount == 3)
		{   
			cat.gameObject.GetComponent<catSprite>().oldFrame = cat.gameObject.GetComponent<catSprite>().curFrame;
			
			PS_cat =  PlayerState_cat.Free;
			cat.gameObject.GetComponent<catSprite>().catState= CatState.Normal;
			
			Debug.Log("PlayerState : " + PS_cat + "/ CatState : " + cat.gameObject.GetComponent<catSprite>().catState);
			
			cat_Animator.SetTrigger("free");
			
			rigidbody2D.isKinematic = false;
			
			//일단 주석 //catState = CatState.Free;
			//Cat collider is removed
			//Destroy(cat.collider2D);   
			//Debug.Log("cat.collider2D 제거됨");
			
			//isDestroyed = true;
			//Debug.Log ("isDestroyed = true됨");
			
			
			for(int index = 0 ; index < cat.gameObject.GetComponent<catSprite>().catImages.Length; index++)
			{
				cat.gameObject.GetComponent<catSprite>().olFrameColliders[index].enabled = false;
				//            Debug.Log ("disabled" + (index+1) );
			}
			
			//clickCount초기화
			clickCount = 0;
			Debug.Log ("clickCount = " + CatchedbyCat.clickCount + "초기화됨");
			
			//catTime초기화 
			//         catTime = Time.time;
			catTime = 0.0f;
			Debug.Log ("catTime = " + catTime + " 로 초기화됨");
			
			//cat에서 비행기 Free되고 나서(catState.Normal) catSprite 2초 후에 다시 생성하기
			Invoke ("init_Frames", 2.0f);
		}//3count
		
		if (PS_cat == PlayerState_cat.CatchedByCat 
		    && Time.time - catTime < 3.0f) //3seconds
		{
			Debug.Log ("잡힌지" + (Time.time - catTime) + "경과");
			
			
		} else if(PS_cat == PlayerState_cat.CatchedByCat 
		          && Time.time - catTime > 3.0f)
		{
			rigidbody2D.isKinematic = false;
			PS_cat = PlayerState_cat.Free;
			cat.gameObject.GetComponent<catSprite>().catState= CatState.Normal;
			this.GetComponent<PlayerControl>().whenDie ();
			clickCount = 0;
			Debug.Log ("clickCount = " + CatchedbyCat.clickCount + "초기화됨");
			
		}
		
	}//update
	
	void init_Frames(){
		cat.gameObject.GetComponent<catSprite>().curFrame = 0;
		cat.gameObject.GetComponent<catSprite>().oldFrame = -1;
	}
	
	
	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.name == "cat") 
		{
			
			if(PS_cat == PlayerState_cat.Free)
			{
				catTime = Time.time;// - startTime;
				Debug.Log ("잡힌시간: catTime = " + catTime);
			}
			
			PS_cat =  PlayerState_cat.CatchedByCat;
		}
		
	}//OnTriggerEnter2D
	
	
	
	
}//class