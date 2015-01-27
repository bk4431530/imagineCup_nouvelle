using UnityEngine;
using System.Collections;

public enum CatState
{
	Normal,
	Catch
}

public class Cat : MonoBehaviour {

	public CatState catState = CatState.Normal;

	public GameObject Player;

	public Vector2 velocity = new Vector2(-20,0);

	public float cat_speed = 0.05f;

	void Start()
	{
		//rigidbody2D.velocity = velocity;

		Player = new GameObject ("player");
	}

	void Update(){
		if(catState == CatState.Normal)
		{
			transform.Translate (new Vector2 (cat_speed, 0));
		} else if (catState == CatState.Catch)
		{
			///new code
			transform.Translate (new Vector2 (cat_speed, 0));
			///

	//		Vector2 newPos = Player.transform.position;
			 
	//		newPos.y = newPos.y + 1.2f;

	//		transform.position = newPos;


			///
		}

		if (transform.position.x < -10)
		{
			this.transform.Translate (new Vector2 (-20,0));
		} 
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.name == "player")
		{
			catState = CatState.Catch;
			Player = other.gameObject;
	
		}
	}
}
