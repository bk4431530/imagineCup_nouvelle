using UnityEngine;
using System.Collections;

public class ButtonControl : MonoBehaviour {
	
	string selectedEp;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Fadeout () {
		float fadeTime = GameObject.Find ("Fading").GetComponent<Fading>().BeginFade(1);
		selectedEp.Substring(0,selectedEp.Length-1);
		Invoke (selectedEp, fadeTime);
	}

	public void ClickedCollection(){
		Debug.Log ("Collection Button Clicked");
	}

	public void ClickedSetting(){
		Debug.Log ("Setting Button Clicked");
	}

	public void ClickedMonday(){
		Debug.Log ("Monday Selected");
		selectedEp = "GoToMonday";
		Fadeout ();
	}

	public void GoToMonday(){
		Application.LoadLevel ("scene1");
	}
}
