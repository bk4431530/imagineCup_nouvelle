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
	
	public CircleCollider2D collided_bubble_collider;
	
	private Vector3 pos;
	private RaycastHit2D hit;

	private Vector2 catPos;
	private Vector2 bubblePos;



	void Start () {
		PS = PlayerState.Normal;
		bubble = GameObject.Find ("Scripts_bubbles");
	}


	void Update () {

		pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		hit = Physics2D.Raycast(pos, Vector2.zero);



		escape ();
		catched ();
	
	}//update

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "cat") 
		{
			PS = PlayerState.CatchedByCat;
			Debug.Log ("player state is " + PS + "// Collided with Cat");
		}
		else if(other.gameObject.name == "tree")
		{
			PS = PlayerState.CatchedByTree;
			Debug.Log ("player state is " + PS + "// Collided with Tree");
			rigidbody2D.isKinematic = true;
		}
		else if(other.gameObject.name == "bubble(Clone)")
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
		
	}//trigger



	void catched()
	{
		if (PS == PlayerState.CatchedByCat)
		{
			catPos = cat.transform.position;
			catPos.y = catPos.y - 2.0f;
			this.transform.position = catPos;
		}
		else if(PS == PlayerState.CatchedByTree)
		{                                
			speed = 0.0f;
			rigidbody2D.isKinematic = true;
			Debug.Log(rigidbody2D.velocity);
		}
		else if(PS == PlayerState.CatchedByBubble) //bubble
		{
			bubblePos = collided_bubble.transform.position;
			this.transform.position = bubblePos;
			rigidbody2D.isKinematic = true;
		}
	}//void catched



	void escape()
	{
		if (hit != null && hit.collider != null) {
			Debug.Log ("Mouse is on + <"+hit.collider.name + "> collider");

			//Player catched by the obstacle : Cat
			//&& When touched 5 times, player -> released from the obstacle 
			if(hit.collider.name == cat.collider2D.name && Input.GetMouseButtonDown(0)==true && PS==PlayerState.CatchedByCat)
			{
				escapeCat();
			}

			//Player catched by the Tree 
			//&& When touched 5 times, player -> released from the obstacle 
			else if(hit.collider.name == tree.collider2D.name && Input.GetMouseButtonDown(0)==true && PS == PlayerState.CatchedByTree)
			{
				escapeTree();
			}
			//Player catched by Bubble
			//&& When touched 5 times, player -> released from the obstacle
			else if(hit.collider.name == "bubble(Clone)" && Input.GetMouseButtonDown(0)==true && PS == PlayerState.CatchedByBubble)
			{
				escapeBubble();
			}
		}//hit something
	}//void detection
	



	void escapeCat()
	{
			PS = PlayerState.CatchedByCat;
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
				Debug.Log ("hit = "  + hit);
			}//click
	}//detectCat

	void escapeTree()
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


	void escapeBubble()
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


}//class
