using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class finishGame : MonoBehaviour {

	GameObject failed;
	GameObject clear;

	public GameObject[] lifes;
	public GameObject[] pieces;



	Text quilpens;


	public static bool pass;



	void Start () 
	{
		GameManager.quillPen = GameManager.quillPen + GameManager.currentQuillPen;
		PlayerPrefs.SetInt ("Quilpen",GameManager.quillPen);
		PlayerPrefs.Save ();
		GameManager.getData ();

		quilpens = GameObject.Find ("quilpens").GetComponent<Text> ();

		failed = GameObject.Find("failed");
		clear = GameObject.Find("clear");

		
		quilpens.text = (GameManager.currentQuillPen).ToString();


		for(int i=0; i<3-GameManager.currentPiece; i++)
		{	
			pieces[i].GetComponent<Image>().color = Color.gray;
		}


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
	}

}
