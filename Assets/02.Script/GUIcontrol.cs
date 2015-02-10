using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIcontrol : MonoBehaviour {

	Text pens;
	Text posts;

	GameObject life1;
	GameObject life2;
	GameObject life3;
	GameObject life4;
	GameObject life5;

	
	public static bool pause =false;


	/*
	private GUIText scoreReference;
	private GUIText itemReference;
	private GUIText puzzleReference;
	*/

	// Use this for initialization
	void Start () {
	
		/*
		scoreReference = GameObject.Find("life").guiText;
		itemReference = GameObject.Find ("items").guiText;
		puzzleReference = GameObject.Find ("puzzles").guiText;
		*/

		pens = GameObject.Find ("quilpens").GetComponent<Text> ();
		posts = GameObject.Find ("postcards").GetComponent<Text> ();


		life1 = GameObject.Find ("life1");
		life2 = GameObject.Find ("life2");
		life3 = GameObject.Find ("life3");
		life4 = GameObject.Find ("life4");
		life5 = GameObject.Find ("life5");
	}
	
	// Update is called once per frame
	void Update () {
		/*
		scoreReference.text = (PlayerControl.life).ToString();
		itemReference.text =(PlayerControl.quilpens).ToString();
		puzzleReference.text = (PlayerControl.puzzles).ToString();
		*/
		pens.text = (PlayerControl.quilpens).ToString();
		posts.text = (PlayerControl.puzzles).ToString();

		if (PlayerControl.life == 4) {
			life1.SetActive(false);
		}else if(PlayerControl.life == 3){
			life2.SetActive(false);
		}else if(PlayerControl.life == 2){
			life3.SetActive(false);
		}else if(PlayerControl.life == 1){
			life4.SetActive(false);
		}else if(PlayerControl.life == 0){
			life5.SetActive(false);
		}
	



	}


	public void setPause()
	{
		Time.timeScale = 0;
		pause = true;
	}



	void OnGUI () {
		if(pause){

			//scoreReference.text = "dead";

			// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
			if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/2-50,100,50), "replay")) {
				//Application.LoadLevel(1);
				pause =false;
				Application.LoadLevel(Application.loadedLevel);
				PlayerControl.life =5;
				PlayerControl.quilpens=0;
				PlayerControl.puzzles=0;
				Time.timeScale=1;
			}
			
			 
			if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/2+20,100,50), "Exit")) {
				Application.Quit();
			}

		}//life<1
	}//onGUI


}//class
