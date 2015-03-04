using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIcontrol : MonoBehaviour {

	Text pens;
	Text posts;

	public GameObject life1;
	public GameObject life2;
	public GameObject life3;
	public GameObject life4;
	public GameObject life5;

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
		pauseScreen = GameObject.Find ("Pause_PopUp");


		pauseScreen.SetActive (false);


		//pause
		if(GameManager.bgm == true)
		{
			musicBtn.GetComponent<Image>().sprite = musicImg[1];
			backMusic.Play();
			
		}
		else
		{
			musicBtn.GetComponent<Image>().sprite = musicImg[0];
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
			GameManager.bgm = false;
			musicBtn.GetComponent<Image>().sprite = musicImg[0];
			backMusic.Stop();

			
		}else
		{
			GameManager.bgm = true;
			musicBtn.GetComponent<Image>().sprite = musicImg[1];
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
		pauseScreen.SetActive (false);
		PlayerControl.finish = true;
		//Application.LoadLevel ("Select_Scene");
		Time.timeScale = 1;

	}








}//class
