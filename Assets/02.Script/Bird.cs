using UnityEngine;
using System.Collections;

public enum BirdState
{
	Normal,
	Catch
}

public class Bird : MonoBehaviour {

	public BirdState BS = BirdState.Normal;

	public GameObject Player;

	void Update(){
		if(BS == BirdState.Normal)
		{
			transform.Translate (new Vector2 (0.05f, 0));
		} 
		else if (BS == BirdState.Catch)
		{
			Vector3 newPos = Player.transform.position;
			newPos.y = newPos.y + 1.2f;
			newPos.z = newPos.z -2;
			transform.position = newPos;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
			BS = BirdState.Catch;
			Player = other.gameObject;
			transform.Rotate (0,180,0);
	}
}
