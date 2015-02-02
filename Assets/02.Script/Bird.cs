using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {
	private Vector2 screenPosition;

	void Update(){
		screenPosition = Camera.main.WorldToScreenPoint(transform.position);

		if (this.transform.position.x > 25.6) {
			transform.Translate (new Vector2 (-0.06f, 0));
		}
		else {
			transform.Translate (new Vector2 (-0.02f, 0.02f));
		}

		if(screenPosition.x < 0 || screenPosition.y > Screen.height+3)
		{
			this.gameObject.SetActive (false);
		}
	}
}
