using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class finishGame : MonoBehaviour {

	GameObject failed;
	GameObject clear;

	public GameObject[] lifes;

	Text pens;
	Text quilpens;
	Text posts;

	public static bool pass;

	void Start () 
	{
		GameManager.quillPen = GameManager.quillPen + GameManager.currentQuillPen;
		PlayerPrefs.SetInt ("Quilpen",GameManager.quillPen);
		PlayerPrefs.Save ();
		GameManager.getData ();

		pens = GameObject.Find ("quil").GetComponent<Text> ();
		quilpens = GameObject.Find ("quilpens").GetComponent<Text> ();
		posts = GameObject.Find ("posts").GetComponent<Text> ();

		failed = GameObject.Find("failed");
		clear = GameObject.Find("clear");


		pens.text = (GameManager.quillPen).ToString();
		quilpens.text = (GameManager.currentQuillPen).ToString();
		posts.text = (GameManager.currentPiece).ToString();


		if (pass) 
		{
			failed.SetActive(false);

			clear.SetActive(true);

			GameObject.Find("lifes").SetActive(false);
			for(int i=0; i<GameManager.currentLife; i++)
			{
				lifes[i].SetActive(true);
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
