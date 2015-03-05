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
	public GameObject pauseScreen;
	
	Sprite soundImg_on;
	Sprite soundImg_off;
	bool sound = true;
	GameObject soundBtn;

	Sprite musicImg_on;
	Sprite musicImg_off;
	GameObject musicBtn;

	Sprite vibImg_on;
	Sprite vibImg_off;
	public static bool vib = true;
	GameObject vibBtn;
	
	AudioSource backMusic;
	


	
	 GameObject booster;
	 GameObject magnet;
	 GameObject sheild;
	 GameObject mysterybox;
	
	
	void Awake(){

		backMusic = GameManager.backMusic;

	}

	void Start()
	{
		pauseScreen = GameObject.Find ("Pause");
		pauseScreen.SetActive (false);

		pens = GameObject.Find ("quilpenQty").GetComponent<Text> ();
		posts = GameObject.Find ("postcardQty").GetComponent<Text> ();

		
		booster = GameObject.Find("booster");
		magnet = GameObject.Find("magnet");
		sheild = GameObject.Find("sheild");
		mysterybox = GameObject.Find("mysterybox");
		
		
		life1 = GameObject.Find ("play_life1");
		life2 = GameObject.Find ("play_life2");
		life3 = GameObject.Find ("play_life3");
		life4 = GameObject.Find ("play_life4");
		life5 = GameObject.Find ("play_life5");
		
		
		soundBtn = GameObject.Find ("sound");
		musicBtn = GameObject.Find ("music");
		vibBtn = GameObject.Find ("vibration");
		
		soundImg_off = (Sprite) Resources.Load ("button_sound-off");
		musicImg_on =(Sprite) Resources.Load ("button_music-on");
		musicImg_off = (Sprite) Resources.Load ("button_music-off");
		vibImg_on =(Sprite) Resources.Load ("button_vibrate-on");
		vibImg_off = (Sprite) Resources.Load ("button_vibrate-off");


		booster.SetActive (false);
		magnet.SetActive (false);
		sheild.SetActive (false);
		mysterybox.SetActive (false);


		
		//pause
		if(GameManager.bgm == true)
		{
			musicBtn.GetComponent<Image>().sprite = musicImg_on;
			backMusic.Play();
			
		}
		else
		{
			musicBtn.GetComponent<Image>().sprite = musicImg_off;
			backMusic.Stop();
			
		}


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

	
		if (GameManager.booster_equip) {
			booster.SetActive(true);
		}else if(GameManager.magnet_equip){
			magnet.SetActive(true);
		}else if(GameManager.shield_equip){
			sheild.SetActive(true);
		}else if(GameManager.mysteryBox > 0){
			mysterybox.SetActive(true);
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
			soundBtn.GetComponent<Image>().sprite = soundImg_off;
			sound = false;
			
		}else
		{
			soundBtn.GetComponent<Image>().sprite = soundImg_on;
			sound = true;
		}
	}
	
	
	
	public void music_OnOff()
	{
		if(GameManager.bgm == true)
		{
			GameManager.bgm = false;
			musicBtn.GetComponent<Image>().sprite = musicImg_off;
			backMusic.Stop();
			
			
		}else
		{
			GameManager.bgm = true;
			musicBtn.GetComponent<Image>().sprite = musicImg_on;
			backMusic.Play();
		}
	}
	
	
	
	
	
	public void vib_OnOff()
	{
		if(GameManager.vibration == true)
		{
			vibBtn.GetComponent<Image>().sprite = vibImg_off;
			GameManager.vibration = false; //false로 바꿈
			
		}else
		{
			vibBtn.GetComponent<Image>().sprite = vibImg_on;
			GameManager.vibration = true; //true 로 바꿈 
		}
	}
	
	
	
	
	
	public void homeBtn()
	{
		pauseScreen.SetActive (false);
		PlayerControl.finish = true;
		finishGame.pause2home = true;
		//Application.LoadLevel ("Select_Scene");
		
	}
	
	
	
	
	
	
	
	
}//class
