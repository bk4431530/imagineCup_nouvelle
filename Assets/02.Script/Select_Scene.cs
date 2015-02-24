using UnityEngine;
using System.Collections;

public class Select_Scene : MonoBehaviour {
	
	//public string selectedEp;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void Fadeout () {
		float fadeTime = GameObject.Find ("Fading").GetComponent<Fading>().BeginFade(1);
		//selectedEp.Substring(0,selectedEp.Length-1);
		Invoke ("GoToEquip", fadeTime);
	}

	//top_menu
	public void ClickedCollection(){
		Debug.Log ("Collection Button Clicked");
	}
	
	public void ClickedSetting(){
		Debug.Log ("Setting Button Clicked");
	}

	//episode_select
	public void ClickedMonday(){
		Debug.Log ("Monday Selected");
		//selectedEp = "Monday";
		Fadeout ();
	}


	void GoToEquip(){
		Application.LoadLevel ("Equip_Scene");
	}
}
