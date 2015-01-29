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
	//dshjkfhjk



	
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
			transform.Translate (new Vector2 (0, bubble_up_speed));
		}
		Vector2 bubblePos = transform.position;
		if (bubblePos.y > + 8) //화면 위로 넘어가면
		{
			Debug.Log ("If scope In");
			Destroy (gameObject);
		} 


	}

	
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.name == "player")
		{
			bubbleState = BubbleState.Catch;
			Debug.Log ("collided with bubble - player");
		}
	}
}
