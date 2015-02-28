using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Option : MonoBehaviour {


	public Toggle MusicOn;
	
	public AudioSource backMusic;


	void Start () {

		
		if(GameManager.bgm == true)
		{
			MusicOn.isOn = true;//toggle on
			backMusic.Play();
			
		}
		else
		{
			MusicOn.isOn = false;//toggle off
			backMusic.Stop();
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
	
	
	/*
	public void vib_OnOff()
	{
		if(GameManager.vibration == true)
		{
			GameManager.vibration = false; //false로 바꿈
			
		}else
		{
			GameManager.vibration = true; //true 로 바꿈 
		}
	}
*/

}
