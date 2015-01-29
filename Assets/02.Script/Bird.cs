﻿using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {

	void Update(){
		if (this.transform.position.x > 25.6) {
			transform.Translate (new Vector2 (0.06f, 0));
		}
		else {
			transform.Translate (new Vector2 (0.02f, 0.02f));
		}
	}
}
