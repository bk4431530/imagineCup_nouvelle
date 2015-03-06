using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class pauseGame : MonoBehaviour {

	GameObject pauseScreen;

	public GameObject soundBtn;
	public GameObject musicBtn;
	public GameObject vibBtn;


	public Sprite soundImg_on;
	public Sprite soundImg_off;
	bool sound = true;

	public Sprite musicImg_on;
	public Sprite musicImg_off;

	public Sprite vibImg_on;
	public Sprite vibImg_off;
	public static bool vib = true;

	
	AudioSource backMusic;


	void Awake(){
		backMusic = GameObject.Find ("BGM").GetComponent<AudioSource> ();
		backMusic = GameManager.backMusic;
		
	}

	// Use this for initialization
	void Start () {
		pauseScreen = GameObject.Find ("Pause");
		pauseScreen.SetActive (false);

		//music
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


	//start

	
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
	


}
