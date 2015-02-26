using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Loading_anim : MonoBehaviour {

	// Use this for initialization

	Text loadingText;

	int cnt = 0;

	void Start () {
		loadingText = GameObject.Find ("Loading").GetComponent<Text> ();
		InvokeRepeating ("anim", 0.3f, 0.3f);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void anim(){
		if (cnt < 3) {
			loadingText.text += ".";
			cnt++;
		} else {
			loadingText.text = "Loading";
			cnt = 0;
		}
	}
}
