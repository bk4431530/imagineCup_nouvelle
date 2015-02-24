using UnityEngine;
using System.Collections;

public class Equip_Scene : MonoBehaviour {

	public string selectedEp = "Monday";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Fadeout () {
		float fadeTime = GameObject.Find ("Fading").GetComponent<Fading>().BeginFade(1);
		Invoke ("GoToGame", fadeTime);
	}

	public void StartClicked(){
		Debug.Log ("Start Button Clicked");
		Fadeout ();
	}

	void GoToGame(){
		selectedEp.Substring(0,selectedEp.Length-1);
		Application.LoadLevel (selectedEp);
	}
}
