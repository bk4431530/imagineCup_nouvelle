using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Option : MonoBehaviour {
	
	
	Toggle MusicOn;
	Toggle MusicOff;
	
	Toggle VibOn;
	Toggle VibOff;
	
	AudioSource backMusic;

	void Awake(){
		MusicOn = GameObject.Find ("MusicOn").GetComponent<Toggle> ();
		MusicOff = GameObject.Find ("MusicOff").GetComponent<Toggle> ();
		
		VibOn = GameObject.Find ("VibOn").GetComponent<Toggle> ();
		VibOff = GameObject.Find ("VibOff").GetComponent<Toggle> ();

		backMusic = GameObject.Find ("BGM").GetComponent<AudioSource> ();
	}
	
	void Start () {

		if(GameManager.bgm == true)
		{
			//MusicOn button On
			MusicOn.isOn = true;
			MusicOff.isOn = false;

			if(backMusic.GetComponent<AudioSource>().clip == null){
				backMusic.GetComponent<AudioSource>().clip = (AudioClip) Resources.Load ("main_sunnyday");
				backMusic.Play();
			}


			Debug.Log("Music_on_start");

		}
		else if(GameManager.bgm == false)
		{
			//MusicOn button off
			MusicOn.isOn = false;
			MusicOff.isOn = true;
			backMusic.Stop();
			Debug.Log("Music_off_start");
		}
		
		if(GameManager.vibration == true)
		{
			// VibOn button on
			VibOn.isOn = true;
			VibOff.isOn = false; 
			
		}
		else if(GameManager.vibration == false)
		{
			// VibOn button off
			VibOn.isOn = false;
			VibOff.isOn = true;
		}
		
		
	}
	
	void Update () {
		
	}
	
	//setting function

	public void music_On()
	{
		if(GameManager.bgm == false)
		{
			GameManager.bgm = true;
			backMusic.Play();
			Debug.Log("Music_On");	 
		}
	}
	
	public void music_Off()
	{
		if(GameManager.bgm == true)
		{
			GameManager.bgm = false;
			backMusic.Stop();
			Debug.Log("Music_Off");	 
		}
	}




	
	
	public void vib_On()
	{
		if(GameManager.vibration == false)
		{
			GameManager.vibration = true; //true로 바꿈
			//vibrate once
			Handheld.Vibrate();
			Debug.Log("vib_On");	
						
		}
	}
	
	public void vib_Off()
	{
		if(GameManager.vibration == true)
		{
			GameManager.vibration = false; //false로 바꿈
			Debug.Log("vib_Off");	
		}
	}

	///////////////////////////////////


	public void SFX_On()
	{
		if(GameManager.sfx == false)
		{
			GameManager.sfx = true; // true로 바꿈
			Debug.Log("SFX_On");	
		}
	}

	public void SFX_Off()
	{
		if(GameManager.sfx == true)
		{
			GameManager.sfx = false; // true로 바꿈
			Debug.Log("SFX_Off");
		}

	}

	///////////////////////////////////////

	public void clickedInit(){
		PlayerPrefs.DeleteAll ();

		PlayerPrefsX.SetBool ("TutorialSelectScene", true);
		PlayerPrefsX.SetBool ("TutorialSelectScenePlayIntro", true);
		PlayerPrefsX.SetBool ("TutorialSelectSceneMonday", true);

		Debug.Log ("초기화 되었습니다.");

		Debug.Log (GameManager.Tutorial_SelectScene);
		Debug.Log ("PlayerPrefsX.GetBool (TutorialSelectScene) = " + PlayerPrefsX.GetBool ("TutorialSelectScene"));
		Debug.Log ("PlayerPrefsX.GetBool(TutorialSelectSceneMonday) = " + PlayerPrefsX.GetBool("TutorialSelectSceneMonday"));

		Debug.Log ("test = " + PlayerPrefsX.GetBool("TutorialSelectSceneblahblah"));



		Debug.Log ("Init Data");

	}




	public void ContactMail()
	{

	}


	public void ContactFacebook()
	{
		Application.OpenURL ("https://www.facebook.com/nouvelle2015");
	}

	public void ContactTwitter()
	{
		
	}


	
}