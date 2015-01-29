using UnityEngine;
using System.Collections;

public class GUIcontrol : MonoBehaviour {

	private GUIText scoreReference;
	private GUIText itemReference;

	// Use this for initialization
	void Start () {
		scoreReference = GameObject.Find("life").guiText;
		itemReference = GameObject.Find ("items").guiText;
	
	}
	
	// Update is called once per frame
	void Update () {
		scoreReference.text = (PlayerControl.life).ToString();
		itemReference.text =(PlayerControl.quilpens).ToString();
	}



	void OnGUI () {
		if(PlayerControl.life<1){

			scoreReference.text = "dead";

			// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
			if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/2-50,100,50), "replay")) {
				//Application.LoadLevel(1);
				Application.LoadLevel(Application.loadedLevel);
				PlayerControl.life =3;
				PlayerControl.quilpens=0;
				Time.timeScale=1;
			}
			
			 
			if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/2+20,100,50), "Exit")) {
				Application.Quit();
			}

		}//life<1
	}//onGUI


}//class
