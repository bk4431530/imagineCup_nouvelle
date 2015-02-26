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

	//pause
	GameObject pauseScreen;

	public Sprite[] soundImg;
	public static bool sound = true;
	public GameObject soundBtn;

	public Sprite[] musicImg;
	public GameObject musicBtn;

	public Sprite[] vibImg;
	public static bool vib = true;
	public GameObject vibBtn;

	public AudioSource backMusic;



	void Start () {

		pens = GameObject.Find ("quilpenQty").GetComponent<Text> ();
		posts = GameObject.Find ("postcardQty").GetComponent<Text> ();
		pauseScreen = GameObject.Find ("pausePanel");


		life1 = GameObject.Find ("life1");
		life2 = GameObject.Find ("life2");
		life3 = GameObject.Find ("life3");
		life4 = GameObject.Find ("life4");
		life5 = GameObject.Find ("life5");


		pauseScreen.SetActive (false);

	}
	

	void Update () {

		
		if (PlayerControl.MultipleFeather) 
		{
			pens.text = (GameManager.currentQuillPen*2).ToString();
			pens.color= Color.red;
		}else{
			pens.text = (GameManager.currentQuillPen).ToString();
		}

		posts.text = (GameManager.currentPiece).ToString();

		if (GameManager.currentLife == 4) {
			life1.SetActive(false);
		}else if(GameManager.currentLife == 3){
			life2.SetActive(false);
		}else if(GameManager.currentLife == 2){
			life3.SetActive(false);
		}else if(GameManager.currentLife == 1){
			life4.SetActive(false);
		}else if(GameManager.currentLife == 0){
			life5.SetActive(false);
		}
	


	}


	public void setPause()
	{
		Time.timeScale = 0;
		pauseScreen.SetActive (true);

	}

	public void continueBtn()
	{
		pauseScreen.SetActive (false);
		Time.timeScale = 1;
	}

	public void sound_OnOff()
	{
		if(sound == true)
		{
			soundBtn.GetComponent<Image>().sprite = soundImg[0];
			sound = false;

		}else
		{
			soundBtn.GetComponent<Image>().sprite = soundImg[1];
			sound = true;
		}
	}



	public void music_OnOff()
	{
		if(GameManager.bgm == true)
		{
			musicBtn.GetComponent<Image>().sprite = musicImg[0];
			GameManager.bgm = false;
			backMusic.Stop();

			
		}else
		{
			musicBtn.GetComponent<Image>().sprite = musicImg[1];
			GameManager.bgm = true;
			backMusic.Play();

		}
	}


	public void vib_OnOff()
	{
		if(GameManager.vibration == true)
		{
			vibBtn.GetComponent<Image>().sprite = vibImg[0];
			GameManager.vibration = false; //false로 바꿈
			
		}else
		{
			vibBtn.GetComponent<Image>().sprite = vibImg[1];
			GameManager.vibration = true; //true 로 바꿈 
		}
	}

	public void homeBtn()
	{
		Application.LoadLevel ("Select_Scene");
		Time.timeScale = 1;

	}






	/*
	void OnGUI () {
		if(pause){

			//scoreReference.text = "dead";

			// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
			if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/2-50,100,50), "replay")) {
				//Application.LoadLevel(1);
				pause =false;
				Application.LoadLevel(Application.loadedLevel);
				GameManager.currentLife =5;
				GameManager.currentQuillPen=0;
				GameManager.currentPiece=0;
				Time.timeScale=1;
			}
			
			 
			if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/2+20,100,50), "Exit")) {
				Application.Quit();
			}

		}//life<1
	}//onGUI
**/

}//class
