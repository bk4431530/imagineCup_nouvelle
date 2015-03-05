using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class finishGame : MonoBehaviour {
	
	GameObject failed;
	GameObject clear;
	
	GameObject[] lifes  = new GameObject[5];
	GameObject[] pieces = new GameObject[3];
	
	Sprite offPiece;
		
	Text quilpenQty;
	GameObject finish_popup;

	public static bool pass;
	public static bool pause2home;

	AudioSource backMusic;

	void Start(){
		finish_popup = GameObject.Find ("Finish");
		finish_popup.SetActive (false);


		failed = GameObject.Find ("failed");
		clear = GameObject.Find ("clear");

		lifes[0] = GameObject.Find ("life1");
		lifes[1] = GameObject.Find ("life2");
		lifes[2] = GameObject.Find ("life3");
		lifes[3] = GameObject.Find ("life4");
		lifes[4] = GameObject.Find ("life5");

		pieces [0] = GameObject.Find ("postcard1");
		pieces [1] = GameObject.Find ("postcard2");
		pieces [2] = GameObject.Find ("postcard3");

		quilpenQty = GameObject.Find ("quilpenQty").GetComponent<Text> ();
	
		offPiece = (Sprite) Resources.Load ("post-n");

		backMusic = GameManager.backMusic;

		pass = false;
	}
	

	
	
	void Update()
	{
		if (PlayerControl.finish) 
		{
			finish_popup.SetActive(true);

			quilpenQty.text = (GameManager.currentQuillPen).ToString ();

			for(int i=0; i<3-GameManager.currentPiece; i++)
			{	
				pieces[i].GetComponent<Image>().sprite = offPiece;
			}




			
			//failed && succed
			if (pass) 
			{
				failed.SetActive(false);
				clear.SetActive(true);

				for(int i=0; i<5-GameManager.currentLife; i++)
				{
					lifes[i].SetActive(false);
				}
				
			}
			else{
				failed.SetActive (true);
				clear.SetActive(false);

				
			}
			
			
			
			
			
		} 
		
		
		
		
		
		
		
		
		
		
	}
	
	
	
	
	void Save()
	{
		GameManager.quillPen = GameManager.quillPen + GameManager.currentQuillPen;
		PlayerPrefs.SetInt ("Quilpen",GameManager.quillPen);
		PlayerPrefs.Save ();
		//GameManager.getData ();
			
	
		GameManager.piece = GameManager.piece + GameManager.currentPiece;
		PlayerPrefs.SetInt ("Piece",GameManager.piece);
		PlayerPrefs.Save ();
		

		GameManager.heart_ep1 = GameManager.heart_ep1 + GameManager.currentLife;
		PlayerPrefs.SetInt ("Heart_ep1",GameManager.heart_ep1);
		PlayerPrefs.Save ();
		
		

	}
	
	
	
	
	
	//button
	public void homeBtn()
	{
		Time.timeScale=0;

		PlayerControl.finish = false;
		finish_popup.SetActive (false);

		Debug.Log ("click home");
		Save ();
		GameManager.currentLife =5;
		GameManager.currentQuillPen=0;
		GameManager.currentPiece=0;
		backMusic.GetComponent<AudioSource>().clip = null;
		Application.LoadLevel("Select_Scene");

		Time.timeScale=1;

	}
	
	public void collectionBtn()
	{
		Debug.Log ("click collection");
	}
	
	public void postcardBtn()
	{
		Debug.Log ("click postcard");
	}
	
	public void settingBtn()
	{
		Debug.Log ("click setting");
	}
	
	public void tryAgainBtn()
	{
		Debug.Log ("tryAgain");
		GameManager.currentLife =5;
		GameManager.currentQuillPen=0;
		GameManager.currentPiece=0;
		Application.LoadLevel("Monday");
		PlayerControl.finish = false;
		Time.timeScale=1;
		
		finish_popup.SetActive (false);
		
	}
	
}
