using UnityEngine;
using System.Collections;

public class CatchedbyCat : MonoBehaviour {
	
	public GameObject cat;
	public GameObject player;
	public GameObject wind;
	
	private int clickCount = 0;
	
	private Vector2 pos;
	private RaycastHit2D hit;
	
	private Vector2 catPos;
	
	
	void Start()
	{
		cat = GameObject.Find ("cat");
		player = GameObject.Find ("player");
	}
	
	
	void Update () 
	{
		rigidbody2D.WakeUp ();
		
		if (PlayerControl.PS == PlayerControl.PlayerState.CatchedByCat)
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
			    && PlayerControl.PS == PlayerControl.PlayerState.CatchedByCat)
			{

				//눌렀을때 마우스 위치에 효고ㅘ 생성
				Vector3 mousePos1 = new Vector3(0,0,0);
				mousePos1 = Input.mousePosition;
				mousePos1.z = 1.0f;
				Vector3 worldPos1 = Camera.main.ScreenToWorldPoint(mousePos1);
				
				Instantiate(wind,worldPos1,Quaternion.identity);
				Destroy(GameObject.Find("wind(Clone)"), 0.1f);
				/*
				if(clickCount < 3){
				//chanege cat color
				cat.GetComponent<SpriteRenderer>().color = Color.red;
				}
				*/
				
				clickCount ++;
				Debug.Log ("clickCount = " + clickCount);   
				
				if (clickCount == 3)
				{				
					//Cat collider is removed
					Destroy(cat.collider2D);				
					
					rigidbody2D.isKinematic = false;
					PlayerControl.PS = PlayerControl.PlayerState.Normal;
					
					clickCount = 0;
					
				}//3count
			}//hit collider
		}//hit null
	}//updarte
	
	
	
	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.name == "cat") 
		{
			PlayerControl.PS = PlayerControl.PlayerState.CatchedByCat;
		}
		
	}//OnTriggerEnter2D
	
	
	
	
}//class