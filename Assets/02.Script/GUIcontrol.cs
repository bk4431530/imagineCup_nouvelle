﻿using UnityEngine;
using System.Collections;

public class GUIcontrol : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}



	void OnGUI () {
		if(PlayerControl.life<1){
			// Make a background box
			GUI.Box(new Rect(Screen.width/2-100,Screen.height/2-100,100,90), "Loader Menu");
			
			// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
			if(GUI.Button(new Rect(Screen.width/2-70,Screen.height/2-80,80,20), "replay")) {
				//Application.LoadLevel(1);
				Application.LoadLevel(Application.loadedLevel);
				PlayerControl.life =3;
				Time.timeScale=1;
			}
			
			 
			if(GUI.Button(new Rect(Screen.width/2-70,Screen.height/2-60,80,20), "Exit")) {
				Application.Quit();
			}

		}//life<1
	}//onGUI


}//class
