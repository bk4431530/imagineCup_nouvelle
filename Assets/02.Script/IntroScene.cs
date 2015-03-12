using UnityEngine;
using System.Collections;

using UnityEngine.UI;


public class IntroScene : MonoBehaviour {

	public GameObject guide;
	public GameObject letter;
	public GameObject letterGuide;
	public GameObject to;

	//Totorial
	public GameObject Tut_Canvas;
	public GameObject Tut_bg;
	public GameObject Tut_girl;
	public GameObject Tut_text;
	//public GameManager Tut_girl_button;

	public bool tutorial= true;


	public GameObject textview;
	public GameObject onLetter;

	private Vector2 ray;
	private RaycastHit2D hit;

	Text viewTxt;
	Text toTxt;
	Text letterTxt;
	string inputMenu;


	bool letterbox_ison = false;
	bool input_isfocused = false;

	GameObject back;
	GameObject next;

	bool isTutorialOn;

	//bgm_setting
	
	public static AudioSource backMusic;

	// Use this for initialization
	void OnEnable ()
	{
		backMusic = GameObject.Find ("BGM").GetComponent<AudioSource> ();

		
		guide = GameObject.Find("/Canvas/Panel/Guide");
		guide.SetActive (false);

		letterGuide = GameObject.Find ("/Canvas/LetterGuide");
		textview = GameObject.Find("View");
		letter = GameObject.Find("/Canvas/View/TextInput");
		onLetter = GameObject.Find ("/Canvas/LetterText");
		to = GameObject.Find ("/Canvas/toText");

		//Totorial
		Tut_Canvas = GameObject.Find ("TutorialCanvas");
		Tut_bg = GameObject.Find ("/TutorialCanvas/Panel/Tutorial_bg");
		Tut_girl = GameObject.Find ("/TutorialCanvas/Panel/TutorialObj/TutorialGirl");
		Tut_text = GameObject.Find ("/TutorialCanvas/Panel/TutorialObj/TutorialText");
		Debug.Log ("Tutoraial_bg : " + Tut_bg);
		//Tut_girl_button=GameObject.Find ("/Canvas/Tutorial/TutorialGirl").GetComponent<Button>;

		back = GameObject.Find ("back");
		next = GameObject.Find ("next");

		viewTxt = GameObject.Find ("TextView").GetComponent<Text> ();
		toTxt = GameObject.Find ("toText").GetComponent<Text> ();
		letterTxt = GameObject.Find ("LetterText").GetComponent<Text> ();

		textview.SetActive (false);
		letterGuide.SetActive (false);
		onLetter.SetActive (false);
		to.SetActive (false);

		//Tutorial
	/*	Tut_bg.SetActive (false);
		Tut_girl.SetActive (false);
		Tut_text.SetActive (false);
	*/

		isTutorialOn = false;

		//for Test
		GameManager.bgm = true;

		if (GameManager.bgm) {
			//backMusic.volume = 0.5f;
			backMusic.Play();
			Debug.Log("BGM played");
		}
	//	letterBox = GameObject.Find ("letterInput").GetComponent<Text> ();
	//	Debug.Log("letterTxt is (" + letterInput + " )");

		
	}
	
	// Update is called once per frame
	void Update ()
	{
		toTxt.text = GameManager.To_name;
		letterTxt.text = GameManager.letter_txt;

//		Debug.Log("Script: IntroScene.cs // _currentItemIndex = " + LevelMenu2D._currentItemIndex );

		ray = Camera.main.ScreenToWorldPoint (Input.mousePosition);
//		Debug.Log (ray);
		hit = Physics2D.Raycast (ray, Vector2.zero);

		// Scene5_writing letter Input

		if(LevelMenu2D._currentItemIndex == 4)
		{		
			if(letterbox_ison == false)
			{
				Invoke ("EnableLetterBox", 1.0f);
				letterbox_ison = true;
			}

			if(tutorial && !isTutorialOn)
			{
				isTutorialOn = true;
				Invoke("EnableTutorial",1.0f);
			}


			//letterBox = GameObject.Find ("/Canvas/letter_box/letterInput").GetComponent<Text> ();
			//Debug.Log("letterTxt is (" + letterInput + " )");
		} else if(LevelMenu2D._currentItemIndex != 4)
		{
			DisableTutorial();
			//DisableTutorial();
			if(letterbox_ison == true){
				DisableLetterBox();
			
				letterbox_ison = false;
			}
		}

		if (letter.GetComponent<InputField> ().isFocused) {
			if(input_isfocused == false)
			{
				input_isfocused = true;
			}
		}

		if (input_isfocused == true) {
			if (letter.GetComponent<InputField> ().isFocused == false){
				if (inputMenu == "to") 
				{
					GameManager.To_name = viewTxt.text;

				}else if(inputMenu == "letter"){
					GameManager.letter_txt = viewTxt.text;

				}
				EnableButtons();
				textview.SetActive(false);
				input_isfocused = false;
			}
		} 


		//Scene8_ guide set activve
		if( LevelMenu2D._currentItemIndex == 8)
		{
			Debug.Log("In");
			guide.SetActive(true);
			//Debug.Log(hit.collider);
			//Debug.Log (guide.collider2D);
			/*
			if(	hit.collider.name == guide.collider2D.name && Input.GetMouseButtonDown(0) == true)
			{

				Debug.Log("Level Count Reset : " + LevelMenu2D._currentItemIndex );
				FadeOut();
			}*/
		} 
		else
		{
			guide.SetActive(false);
		}
	}

	public void clickedWrite(string i){
		back.GetComponent<ClickTouchScript> ().enabled = false;
		next.GetComponent<ClickTouchScript> ().enabled = false;
		back.GetComponent<BoxCollider> ().enabled = false;
		next.GetComponent<BoxCollider> ().enabled = false;
		textview.SetActive (true);
		letter.GetComponent<InputField>().text 	= " "; 
		inputMenu = i;
		DisableTutorial ();

	}

	public void GoToSelectScene()
	{
		LevelMenu2D._currentItemIndex = 0;
		Debug.Log("Go to Select Scene");
		backMusic.GetComponent<AudioSource>().clip = (AudioClip) Resources.Load (null);
		Application.LoadLevel ("Select_Scene");

	}

	public void FadeOut ()
	{
		float fadeTime = GameObject.Find ("Fading").GetComponent<Fading>().BeginFade(1);

		Invoke ("GoToSelectScene", fadeTime);

	}

	public void EnableLetterBox()
	{
		letterGuide.SetActive (true);
		onLetter.SetActive (true);
		to.SetActive (true);

		//Debug.Log("letterTxt is (" + letterInput + " )");

	}


	public void DisableLetterBox()
	{
		textview.SetActive (false);
		letterGuide.SetActive (false);
		onLetter.SetActive (false);
		to.SetActive (false);
	}

	public void EnableTutorial()
	{
		DisableButtons ();
		Tut_Canvas.SetActive (true);
		Tut_bg.SetActive (true);
		Tut_girl.SetActive (true);
		Tut_text.SetActive (true);
		tutorial = false;
		Debug.Log ("enable tutorial됨");
		Debug.Log ("tutorial boolean is " + tutorial);

	}

	public void DisableTutorial()
	{
		Tut_bg.SetActive (false);
		Tut_girl.SetActive (false);
		Tut_text.SetActive (false);
		Tut_Canvas.SetActive (false);
//		Debug.Log ("disable tutorial 실행됨");

	}

	public void TutorialBoolMakeTrue()
	{
		tutorial = true;
	}

	public void DisableButtons(){
		back.GetComponent<ClickTouchScript> ().enabled = false;
		next.GetComponent<ClickTouchScript> ().enabled = false;
		back.GetComponent<BoxCollider> ().enabled = false;
		next.GetComponent<BoxCollider> ().enabled = false;
	}


	public void EnableButtons(){
		back.GetComponent<ClickTouchScript> ().enabled = true;
		next.GetComponent<ClickTouchScript> ().enabled = true;
		back.GetComponent<BoxCollider> ().enabled = true;
		next.GetComponent<BoxCollider> ().enabled = true;
	}


}
