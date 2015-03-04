using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class finishGame : MonoBehaviour {

	GameObject failed;
	GameObject clear;

	public GameObject[] lifes;
	public GameObject[] pieces;

	public Sprite offPiece;

	
	public Text quilpenQty;
	public static bool pass;
	public GameObject finish_popup;


	void Start () 
	{
		finish_popup.SetActive (false);





		failed = GameObject.Find("failed");
		clear = GameObject.Find("clear");
	
	}


	void Update()
	{
		if (PlayerControl.finish) 
		{
			finish_popup.SetActive(true);
		} 


		for(int i =0; i<GameManager.currentQuillPen; i++) 
		{
			quilpenQty.text = (i).ToString ();
		}

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



		//if pause->home





	}




	void quilpenSave()
	{
		GameManager.quillPen = GameManager.quillPen + GameManager.currentQuillPen;
		PlayerPrefs.SetInt ("Quilpen",GameManager.quillPen);
		PlayerPrefs.Save ();
		GameManager.getData ();
	}

	void pieceSave()
	{
	}

	void lifeSave()
	{
	}



	public void homeBtn()
	{
		Debug.Log ("click home");
		GameManager.currentLife =5;
		GameManager.currentQuillPen=0;
		GameManager.currentPiece=0;
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
		Time.timeScale=1;

		finish_popup.SetActive (false);

	}

}
