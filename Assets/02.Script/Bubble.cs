using UnityEngine;
using System.Collections;

public enum BubbleState
{
	Normal,
	Catch
}

public class Bubble : MonoBehaviour {
	
	public BubbleState bubbleState = BubbleState.Normal;
	
	public GameObject Player;

	public Vector2 velocity = new Vector2(-20,0);

	public float bubble_up_speed = 0.05f;

	//public GameObject bubble;



	
	void Start()
	{
		//rigidbody2D.velocity = velocity;
		
		//Player = new GameObject ("player");
	}
	
	void Update(){
		if(bubbleState == BubbleState.Normal)
		{
			transform.Translate (new Vector2 (0, bubble_up_speed));
		} else if (bubbleState == BubbleState.Catch)
		{
			///new code
			transform.Translate (new Vector2 (0, bubble_up_speed));
			///
			
			//		Vector2 newPos = Player.transform.position;
			
			//		newPos.y = newPos.y + 1.2f;
			
			//		transform.position = newPos;
			
			
			///
		}
		Vector2 bubblePos = transform.position;
		//Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		//Debug.Log ("x: " + screenPosition.x + "// y: " + screenPosition.y);
		if (bubblePos.y > + 8) //화면 위로 넘어가면
		{
			Debug.Log ("If scope In");
			//this.transform.Translate (new Vector2 (0,-16));  //저 if조건이 걸리는데에서 상대적으로 얼마나 내려올거냐
			// 맵에 따라서 이거는 다시설정 가능
			Destroy (gameObject);


		} 
		/*
		Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);    
		if (screenPosition.y > Screen.height || screenPosition.y < 0)
		{
			Destroy(this);
		}
		*/


	}

	
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.name == "player")
		{
			bubbleState = BubbleState.Catch;
			//Player = other.gameObject;
			Debug.Log ("collided with bubble - player");
			//transform.Rotate (0,180,0);
		}
	}
}
