using UnityEngine;
using System.Collections;

public class ToyFlight : MonoBehaviour {
	private Vector2 screenPosition;
	void Update(){
		screenPosition = Camera.main.WorldToScreenPoint(transform.position);

		transform.Translate (new Vector2 (-0.06f, 0));

		if(screenPosition.x < -1)
		{
			this.gameObject.SetActive(false);
		}
	}
}

