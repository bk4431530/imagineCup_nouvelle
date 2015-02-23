using UnityEngine;
using System.Collections;

public class Logo_time : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("Fadeout", 5.0f);
	}
	
	// Update is called once per frame
	void Fadeout () {
		float fadeTime = GameObject.Find ("Fading").GetComponent<Fading>().BeginFade(1);
		Invoke ("GoToLoad", fadeTime);
	}

	void GoToLoad(){
		Application.LoadLevel ("Loading_Scene");
	}
}
