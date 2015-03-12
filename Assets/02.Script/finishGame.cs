using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class finishGame : MonoBehaviour {
	
	public GameObject failed;
	public GameObject clear;
	
	public GameObject[] lifes  = new GameObject[5];

	public GameObject[] pieces = new GameObject[3];
	public GameObject[] postPiecies = new GameObject[3];

	public Sprite[] postcards;
			
	public Text quilpenQty;
	GameObject finish_popup;

	public static bool pass;
	public static bool pause2home;

	int rand_postcard;
	int rand_piece;

	AudioSource backMusic;

	private bool isClear;



	//sound
		public static AudioSource SFX_popup;
	public static AudioSource SFX_button;
	public static AudioSource SFX_piece;

	void Start(){
		finish_popup = GameObject.Find ("Finish");
		finish_popup.SetActive (false);

		/*
		postPiecies [0] = GameObject.Find ("postcard1_Img");
		postPiecies [1] = GameObject.Find ("postcard2_Img");
		postPiecies [2] = GameObject.Find ("postcard3_Img");
*/
		postPiecies [0].SetActive (false);
		postPiecies [1].SetActive (false);
		postPiecies [2].SetActive (false);

		/*
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
		*/

		backMusic = GameManager.backMusic;

		pass = false;

		isClear = true;
		//sound
		
		
		
		SFX_popup = GameObject.Find ("/SFX/popup").GetComponent<AudioSource> ();
		SFX_popup.GetComponent<AudioSource> ().clip = (AudioClip)Resources.Load ("ScorePopup");

		SFX_button = GameObject.Find ("/SFX/Button").GetComponent<AudioSource>();	
		SFX_button.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("ButtonClick");
		
		
		SFX_piece = GameObject.Find ("/SFX/piece").GetComponent<AudioSource> ();
		SFX_piece.GetComponent<AudioSource> ().clip = (AudioClip)Resources.Load ("PieceGet");
		
		

	}
	

	
	
	void Update()
	{
		if (PlayerControl.finish) 
		{
			if(GameManager.paperPlaneState == 8){
				PostcardEffect.flareLayer.enabled = false;
			}

			finish_popup.SetActive(true);
			quilpenQty.text = (GameManager.currentQuillPen).ToString ();

			for(int i=0; i<3-GameManager.currentPiece; i++)
			{	
				pieces[i].SetActive(false);
			}



			//failed && succed
			if (pass) 
			{
				if(isClear)
				{
					PopupSound();
					isClear = false;
				}
				Debug.Log("clear");

				failed.SetActive(false);
				clear.SetActive(true);

				for(int i=0; i<5-GameManager.currentLife; i++)
				{
					lifes[i].SetActive(false);
				}
				
			}
			else{
				Debug.Log("failed");

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


		PlayerPrefs.SetInt ("Postcard1",GameManager.postCard[0]);
		PlayerPrefs.SetInt ("Postcard2",GameManager.postCard[1]);
		PlayerPrefs.SetInt ("Postcard3",GameManager.postCard[2]);
		PlayerPrefs.SetInt ("Postcard4",GameManager.postCard[3]);
		PlayerPrefs.SetInt ("Postcard5",GameManager.postCard[4]);
		PlayerPrefs.SetInt ("Postcard6",GameManager.postCard[5]);
		PlayerPrefs.SetInt ("Postcard7",GameManager.postCard[6]);
		PlayerPrefs.SetInt ("Postcard8",GameManager.postCard[7]);
		PlayerPrefs.SetInt ("Postcard9",GameManager.postCard[8]);
		PlayerPrefs.SetInt ("Postcard10",GameManager.postCard[9]);


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
	
	public void nextEpisodeBtn()
	{
		Debug.Log ("click nextEpisode");
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


	
	public void openPiece(int i)
	{
		rand_postcard = (int)Random.Range (0, 10);


		postPiecies [i].SetActive (true);
		postPiecies[i].GetComponent<Image>().sprite = postcards[rand_postcard];

		GameManager.postCard [i] += 1;
		
	}

	
	public void PopupSound()
	{
		if(GameManager.sfx)
		{
			SFX_popup.Play();
			Debug.Log(" PopupSound 함수실행");
			
		}
		
	}

	public void ButtonSound()
	{
		if(GameManager.sfx)
		{
			//SFX_button.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("ButtonClick");
			SFX_button.Play();
			Debug.Log("Equip.cs에서 ButtonSound 함수실행");
			
		}
		
	}

	public void PieceSound()
	{
		if(GameManager.sfx)
		{
			SFX_piece.Play();
			Debug.Log(" PieceSound 함수실행");			
		}
		
	}

	public void setNew(){
		GameManager.Tutorial_EquipScene = false;
		GameManager.Tutorial_SelectScene = false;
		GameManager.Tutorial_SelectScene_PlayIntro = false;
	}
}
