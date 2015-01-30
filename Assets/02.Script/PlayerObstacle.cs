using UnityEngine;
using System.Collections;


public class PlayerObstacle : PlayerControl {
	
	public GameObject cat;
	public GameObject tree;
	public GameObject bubble;
	public GameObject player;
	
	private GameObject collided_bubble;
	
	private int clickCount = 0;
	public float speed = 0.1f;
	
	private Vector2 pos;
	private RaycastHit2D hit;
	
	public CircleCollider2D collided_bubble_collider;
	
	//private Vector3 pos;
	//private RaycastHit2D hit;
	
	private Vector2 catPos;
	private Vector2 bubblePos;
	
	
	
	void Start () {
		PS = PlayerState.Normal;
		//bubble = GameObject.Find ("Scripts_bubbles");
		
	}
	
	
	void Update () {
		
		
		rigidbody2D.WakeUp ();
		
		///여기로 옮겨짐 
		if (PS == PlayerState.CatchedByCat)
		{
			
			//Debug.Log("CatchedByCat() 들어옴 ");
			
			catPos = cat.transform.position;
			transform.position = new Vector3(catPos.x-2 ,catPos.y, -1);         
			rigidbody2D.isKinematic = true;
			
			
		}
		
		//Debug.Log("고양이 좌표 : " + catPos);
		
		/*      else if(PS == PlayerState.CatchedByTree)
      {
         CatchedByTree();
      }
      else if(PS == PlayerState.CatchedByBubble)
      {
         CatchedByBubble();
      }
*/
		
		pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		hit = Physics2D.Raycast(pos, Vector2.zero);
		
		
		if (hit != null && hit.collider != null) {
			Debug.Log ("hit 값은 : " + hit);
			Debug.Log ("pos 값은 : " + pos);
			Debug.Log ("인풋 마우스좌표는 : " + Input.mousePosition);
			Debug.Log ("hit.collider.name 값은 : " + hit.collider.name);
			
			Debug.Log ("마우스 + <" + hit.collider.name + "> collider가 위에 있음");
			Debug.Log ("부딪 콜라이더 이름 : " + hit.collider.name);
			
			
			if (hit.collider.name == cat.collider2D.name
			    && Input.GetMouseButtonDown (0) == true
			    && PS == PlayerState.CatchedByCat)
			{
				Debug.Log ("EscapeCat() 들어옴");
				//PS = PlayerState.CatchedByCat;
				Debug.Log ("cat.collider2D.name  is = " + cat.collider2D.name);
				Debug.Log ("Player is = " + PlayerState.CatchedByCat);
				
				clickCount ++;
				Debug.Log ("clickCount = " + clickCount);   
				
				if (clickCount == 5)
				{
					rigidbody2D.isKinematic = false;
					PS = PlayerState.Normal;
					
					clickCount = 0;
					Debug.Log ("clickCount = " + clickCount + " initiated");
					Debug.Log ("hit = " + hit);
				}
			}
		}
		
		/* else if(other.gameObject.name == "tree")
      {
         PS = PlayerState.CatchedByTree;
         Debug.Log ("player state is " + PS + "// Collided with Tree");
         rigidbody2D.isKinematic = true;
      } 

         //Player catched by Bubble
         //&& When touched 5 times, player -> released from the obstacle
         else if(hit.collider.name == "bubble(Clone)"
                 && Input.GetMouseButtonDown(0)==true
                 && PS == PlayerState.CatchedByBubble)
         {
            EscapeBubble();
         } 
      //Player catched by the Tree 
      //&& When touched 5 times, player -> released from the obstacle 
      else if(hit.collider.name == tree.collider2D.name 
              && Input.GetMouseButtonDown(0)==true
              && PS == PlayerState.CatchedByTree)
      {
         EscapeTree();
      } */
		
		
		
		
		
		
		
		//Escape (); //잡히지도 않았는데 escape계속 되서 주석
		//Catched (); //여기에 그대로 두면 잡히지 않았는데 catched들어감
		
		
		
	}//update
	
	
	// OnTriggerEnger2D Function : Change Player State on Collision
	
	void OnTriggerEnter2D(Collider2D other) 
	{
		///////임시 주석 //////hit = Physics2D.Raycast(pos, Vector2.zero);  ////////////update에서 계속 null에러나서 옮김 여기 놔도 되나?
		
		if (other.gameObject.name == "cat") 
		{
			PS = PlayerState.CatchedByCat;
			Debug.Log ("player state is " + PS + "// Collided with Cat");
			Debug.Log ("비행기는 고양이 콜라이더를 감지함: "+ other.collider2D.name);
			
		}
		
		/*   else if(other.gameObject.name == "bubble(Clone)")
      {
         collided_bubble = other.gameObject;
         Debug.Log ("player state is " + PS);
         Debug.Log ("// Collided with << "+ other.gameObject.name +" >>");
         
         PS = PlayerState.CatchedByBubble;
   
         Debug.Log ("Player State changed to " + PS);
         collided_bubble_collider = collided_bubble.GetComponent<CircleCollider2D>();
         collided_bubble_collider.radius = 6.0f;
         Debug.Log("collided_bubble_collider.radius = " + collided_bubble_collider.radius);
      }

      else if(other.gameObject.name == "Tree")
      {


      }
      */
		
		
		
		
		
	}//OnTriggerEnter2D
	
	
	void CatchedByCat()
	{
		
		
	} 
	
	
	
	
	
	
	/*   void CatchedByTree()
      {                                
         speed = 0.0f;
         rigidbody2D.isKinematic = true;
         Debug.Log(rigidbody2D.velocity);
      }
   void CatchedByBubble() //bubble
   {
      bubblePos = collided_bubble.transform.position;
      this.transform.position = bubblePos;
      rigidbody2D.isKinematic = true;
   }
*/
	
	/*
   void EscapeCat()
   {
      Debug.Log("EscapeCat() 들어옴");
         //PS = PlayerState.CatchedByCat;
         Debug.Log ("cat.collider2D.name  is = " + cat.collider2D.name);
         Debug.Log ("Player is = " + PlayerState.CatchedByCat);
         
         clickCount ++;
         Debug.Log ("clickCount = " + clickCount);   
         
         if(clickCount == 5)
         {
            rigidbody2D.isKinematic = false;
            PS = PlayerState.Normal;
            
            clickCount = 0;
            Debug.Log ("clickCount = " + clickCount  +" initiated");

         }//click



   }//EscapeCat()






*/
	
	
	
	
	
	
	/*void EscapeTree()
   {
         PS = PlayerState.CatchedByTree;
         Debug.Log ("tree.collider2D.name  is = " + tree.collider2D.name);
         Debug.Log ("Player is = " + PlayerState.CatchedByTree);
         
         clickCount ++;
         Debug.Log ("clickCount = " + clickCount);   
         
         if(clickCount == 5)
         {
            speed = 0.1f;
            rigidbody2D.isKinematic = false;
            PS = PlayerState.Normal;
            
            
            clickCount = 0;
            Debug.Log ("clickCount = " + clickCount  +" initiated");
            Debug.Log ("hit = "  + hit);
            
         }

   }//detectTree  


   void EscapeBubble()
   {
         PS = PlayerState.CatchedByBubble;
         Debug.Log ("bubble.collider2D.name  is = " + bubble.collider2D.name);
         Debug.Log ("Player is = " + PlayerState.CatchedByBubble);
         
         clickCount ++;
         Debug.Log ("clickCount = " + clickCount);   
         
         if(clickCount == 3)
         {
            speed = 0.1f;
            rigidbody2D.isKinematic = false;
            PS = PlayerState.Normal;
            
            clickCount = 0;
            Debug.Log ("clickCount = " + clickCount  +" become zero");
            //Debug.Log ("hit = "  + hit);
            Destroy (collided_bubble);
            //isBubble = false;
            ////////////Destroy 한 다음에 만들어놔야될거 같은데 ... else if에서 오류나서..
         }//click 3times
   }//detectBubble

   */
	
	
}//class