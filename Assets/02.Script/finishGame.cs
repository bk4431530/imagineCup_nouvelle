using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class finishGame : MonoBehaviour {

	GameObject life1;
	GameObject life2;
	GameObject life3;
	GameObject life4;
	GameObject life5;

	Text pens;
	Text quilpens;
	Text posts;


	void Start () 
	{
		pens = GameObject.Find ("quil").GetComponent<Text> ();
		quilpens = GameObject.Find ("quilpens").GetComponent<Text> ();
		posts = GameObject.Find ("posts").GetComponent<Text> ();
		/*
		life1 = GameObject.Find ("life1");
		life2 = GameObject.Find ("life2");
		life3 = GameObject.Find ("life3");
		life4 = GameObject.Find ("life4");
		life5 = GameObject.Find ("life5");
		*/

	
	}
	
	// Update is called once per frame
	void Update () 
	{
		pens.text = (GameManager.quillPen).ToString();
		quilpens.text = (GameManager.quillPen).ToString();
		posts.text = (GameManager.piece).ToString();

		/*
		if (PlayerControl.life == 4) {
			life1.SetActive(false);
		}else if(PlayerControl.life == 3){
			life2.SetActive(false);
		}else if(PlayerControl.life == 2){
			life3.SetActive(false);
		}else if(PlayerControl.life == 1){
			life4.SetActive(false);
		}else if(PlayerControl.life == 0){
			life5.SetActive(false);
		}
		*/


	}


	public void homeBtn()
	{
		Debug.Log ("click home");
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
		Application.LoadLevel("scene1");

	}

}
