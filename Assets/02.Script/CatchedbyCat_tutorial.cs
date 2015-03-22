using UnityEngine;
using System.Collections;

public class CatchedbyCat_tutorial : MonoBehaviour{
	
	
	public GameObject cat;
	public GameObject player;
	public GameObject wind;
	
	public PlayerState_cat PS_cat = PlayerState_cat.Free;
	
	
	
	public static int clickCount = 0;
	public static bool isDestroyed = false;
	
	private Vector2 catPos;
	
	Animator cat_Animator;
	
	public float catTime;

	//sound
	public static AudioSource SFX_cat;
	
	void Awake()
	{
		catTime = 0.0f;
	}
	
	void Start()
	{
		cat = GameObject.Find ("cat1");
		player = GameObject.Find ("player");
		PS_cat = PlayerState_cat.Free;
		
		cat_Animator = cat.gameObject.GetComponent<Animator> ();

		//sound
		
		SFX_cat = GameObject.Find ("/SFX/cat").GetComponent<AudioSource> ();
		SFX_cat.GetComponent<AudioSource> ().clip = (AudioClip)Resources.Load ("Cat_basic");
		

	}
	

	void Update () 
	{
		rigidbody2D.WakeUp ();
		
		if (PS_cat ==  PlayerState_cat.CatchedByCat)
		{
			cat_Animator.SetTrigger("catch");
			catPos = cat.transform.position;
			transform.position = new Vector3(catPos.x-3.8f ,catPos.y-2.0f, 5.0f);         
			rigidbody2D.isKinematic = true;   
		}
		
		
		Vector3 pos = Input.mousePosition;
		pos.z = transform.position.z - Camera.main.transform.position.z;
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos), Vector2.zero);
		
		/*
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
      Plane aa = new Plane(new Vector3(0, 1, 0), 0); 
      float h_len = 0; 
      aa.Raycast(ray, out h_len);
*/
		
		if ( hit.collider != null && cat.collider2D != null) 
		{
			if (hit.collider.name == cat.collider2D.name
			    && Input.GetMouseButtonDown(0) == true
			    &&  PS_cat ==  PlayerState_cat.CatchedByCat)
			{
				//Vibration -duration: 1 second
				//*****************************
				if(GameManager.vibration == true)
				{
					Handheld.Vibrate ();
				}
				//sound
				CatSound();
				//*****************************
				cat_Animator.SetTrigger("tap");
				clickCount ++;
				Debug.Log ("clickCount = " + clickCount);   
				
			}//hit collider
		}//hit null
		
		if (clickCount == 3)
		{   
			cat.gameObject.GetComponent<catSprite_tutorial>().oldFrame = cat.gameObject.GetComponent<catSprite_tutorial>().curFrame;
			
			cat.gameObject.GetComponent<catSprite_tutorial>().catState= CatState.Normal;
			
			Debug.Log("PlayerState : " + PS_cat + "/ CatState : " + cat.gameObject.GetComponent<catSprite_tutorial>().catState);
			
			cat_Animator.SetTrigger("free");
			
			rigidbody2D.isKinematic = false;
			
			//일단 주석 //catState = CatState.Free;
			//Cat collider is removed
			//Destroy(cat.collider2D);   
			//Debug.Log("cat.collider2D 제거됨");
			
			//isDestroyed = true;
			//Debug.Log ("isDestroyed = true됨");
			
			
			for(int index = 0 ; index < 11; index++)
			{
				cat.gameObject.GetComponent<catSprite_tutorial>().olFrameColliders[index].enabled = false;
				//            Debug.Log ("disabled" + (index+1) );
			}
			
			//clickCount초기화
			clickCount = 0;
			Debug.Log ("clickCount = " + CatchedbyCat_tutorial.clickCount + "초기화됨");
			
			//catTime초기화 
			//         catTime = Time.time;
			catTime = 0.0f;
			Debug.Log ("catTime = " + catTime + " 로 초기화됨");
			
			//cat에서 비행기 Free되고 나서(catState.Normal) catSprite1 2초 후에 다시 생성하기
			//Invoke ("init_Frames", 5.0f);
		}//3count
		
		if (PS_cat == PlayerState_cat.CatchedByCat 
		    && Time.time - catTime < 3.0f) //3seconds
		{
			//         Debug.Log ("잡힌지" + (Time.time - catTime) + "경과");
			
			
		} else if(PS_cat == PlayerState_cat.CatchedByCat 
		          && Time.time - catTime > 3.0f)
		{
			rigidbody2D.isKinematic = false;
			PS_cat = PlayerState_cat.Free;
			cat.gameObject.GetComponent<catSprite_tutorial>().catState= CatState.Normal;
			this.GetComponent<PlayerControl_tutorial>().whenDie ();
			clickCount = 0;
			Debug.Log ("clickCount = " + CatchedbyCat_tutorial.clickCount + "초기화됨");
			
		}
		
	}//update
	
	void init_Frames(){
		/*
		cat.gameObject.GetComponent<catSprite_tutorial>().curFrame = 0;
		cat.gameObject.GetComponent<catSprite_tutorial>().oldFrame = -1;
		*/
	}
	
	
	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.name == "cat1") 
		{
			CatSound();
			
			if(PS_cat == PlayerState_cat.Free)
			{
				catTime = Time.time;// - startTime;
				Debug.Log ("잡힌시간: catTime = " + catTime);
			}
			
			PS_cat =  PlayerState_cat.CatchedByCat;
		}
		
	}//OnTriggerEnter2D


	public void CatSound()
	{
		if(GameManager.sfx)
		{
			SFX_cat.Play();
			Debug.Log(" CatSound 함수실행");			
		}
		
	}
	
	
	
}//class