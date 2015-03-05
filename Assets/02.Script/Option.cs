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
		
		backMusic = GameObject.Find ("Audio Source").GetComponent<AudioSource> ();

	}
	
	void Start () {

		if(GameManager.bgm == true)
		{
			//MusicOn button On
			MusicOn.isOn = true;
			MusicOff.isOn = false;
			backMusic.Play();
			
		}
		else
		{
			//MusicOn button off
			MusicOn.isOn = false;
			MusicOff.isOn = true;
			backMusic.Stop();
		}
		
		if(GameManager.vibration == true)
		{
			// VibOn button on
			VibOn.isOn = true;
			VibOff.isOn = false; 
			
		}
		else
		{
			// VibOn button off
			VibOn.isOn = false;
			VibOff.isOn = true;
		}
		
		
	}
	
	void Update () {
		
	}
	
	
	
	public void music_On()
	{
		if(GameManager.bgm == false)
		{
			GameManager.bgm = true;
			backMusic.Play();
			
		}
	}
	
	public void music_Off()
	{
		if(GameManager.bgm == true)
		{
			GameManager.bgm = false;
			backMusic.Stop();
			
		}
	}
	
	////////////////////////////////////   
	
	
	public void vib_On()
	{
		if(GameManager.vibration == false)
		{
			GameManager.vibration = true; //true로 바꿈
			
		}
	}
	
	public void vib_Off()
	{
		if(GameManager.vibration == true)
		{
			GameManager.vibration = false; //false로 바꿈
			
		}
	}
	
	
}