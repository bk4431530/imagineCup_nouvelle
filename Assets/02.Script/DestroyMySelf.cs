using UnityEngine;
using System.Collections;

public class DestroyMySelf : MonoBehaviour {
	void Update() {
		/*
		Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		if (screenPosition.y > Screen.height || screenPosition.y < 0)
			Destroy(this.gameObject);
			*/

		Destroy (this.gameObject,1.0f);
	}
}