using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class finishGame : MonoBehaviour {
	
	public GameObject failed;
	public GameObject clear;
	
	public GameObject[] lifes;
	public GameObject[] pieces;
	
	public Sprite offPiece;
	
	
	public Text quilpenQty;
	public static bool pass;
	public static bool pause2home;
	public GameObject finish_popup;
	
	
	void Start () 
	{
		finish_popup.SetActive (false);
		pass = false;

	}
	
	
	void Update()
	{
		if (PlayerControl.finish) 
		{
			finish_popup.SetActive(true);
			
			
			quilpenSave();
			pieceSave();
			
			
			//failed && succed
			if (pass) 
			{
				failed.SetActive(false);
				clear.SetActive(true);
				
				lifeSave();
			}
			else{
				failed.SetActive (true);
				clear.SetActive(false);

				
			}
			
			
			
			
			
		} 
		
		
		
		
		
		
		
		
		
		
	}
	
	
	
	
	void quilpenSave()
	{
		GameManager.quillPen = GameManager.quillPen + GameManager.currentQuillPen;
		PlayerPrefs.SetInt ("Quilpen",GameManager.quillPen);
		PlayerPrefs.Save ();
		//GameManager.getData ();
		
		quilpenQty.text = (GameManager.currentQuillPen).ToString ();
		
		
	}
	
	void pieceSave()
	{
		GameManager.piece = GameManager.piece + GameManager.currentPiece;
		PlayerPrefs.SetInt ("Piece",GameManager.piece);
		PlayerPrefs.Save ();
		
		for(int i=0; i<3-GameManager.currentPiece; i++)
		{	
			pieces[i].GetComponent<Image>().sprite = offPiece;
		}
		
	}
	
	void lifeSave()
	{
		GameManager.heart_ep1 = GameManager.heart_ep1 + GameManager.currentLife;
		PlayerPrefs.SetInt ("Heart_ep1",GameManager.heart_ep1);
		PlayerPrefs.Save ();
		
		
		for(int i=0; i<5-GameManager.currentLife; i++)
		{
			lifes[i].SetActive(false);
		}
	}
	
	
	
	
	
	//button
	public void homeBtn()
	{
		PlayerControl.finish = false;
		finish_popup.SetActive (false);

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
		PlayerControl.finish = false;
		Time.timeScale=1;
		
		finish_popup.SetActive (false);
		
	}
	
}
