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

	public  static int clickCount = 0;
	public static bool isDestroyed = false;
	
	private Vector2 pos;
	private RaycastHit2D hit;
	
	private Vector2 catPos;
	
	
	void Start()
	{
		cat = GameObject.Find ("cat");
		player = GameObject.Find ("player");
		PS_cat = PlayerState_cat.Free;
	}
	
	
	void Update () 
	{
		rigidbody2D.WakeUp ();
		
		if (PS_cat ==  PlayerState_cat.CatchedByCat)
		{
			catPos = cat.transform.position;
			transform.position = new Vector3(catPos.x-1 ,catPos.y, -1);         
			rigidbody2D.isKinematic = true;	
		}

		
		pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		hit = Physics2D.Raycast(pos, Vector2.zero);
		
		if (hit != null && hit.collider != null) 
		{
			if (hit.collider.name == cat.collider2D.name
			    && Input.GetMouseButtonDown(0) == true
			    &&  PS_cat ==  PlayerState_cat.CatchedByCat)
			{
				
				clickCount ++;
				Debug.Log ("clickCount = " + clickCount);   

			}//hit collider
		}//hit null

		if (clickCount == 3)
		{	
			PS_cat =  PlayerState_cat.Free;


			//일단 주석 //catState = CatState.Free;
			//Cat collider is removed
			Destroy(cat.collider2D);	
			Debug.Log("cat.collider2D 제거됨");
			
			isDestroyed = true;
			Debug.Log ("isDestroyed = true됨");
			

		}//3count

		if (PS_cat == PlayerState_cat.Free) 
		{
			Debug.Log ("PS_Cat: " + PS_cat +" 로 바뀜");
			rigidbody2D.isKinematic = false;			
			Debug.Log ("player의 isKinematic상태:  " + rigidbody2D.isKinematic +" 로 바뀜");
		}

	}//updarte
	
	
	
	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.name == "cat") 
		{
			PS_cat =  PlayerState_cat.CatchedByCat;
		}
		
	}//OnTriggerEnter2D
	
	
	
	
}//class