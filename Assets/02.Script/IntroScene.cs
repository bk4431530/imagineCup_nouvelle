using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class IntroScene : MonoBehaviour {

	public GameObject guide;
	public GameObject letter;
	public GameObject letterGuide;

	public GameObject textview;
	public GameObject onLetter;

	private Vector2 ray;
	private RaycastHit2D hit;

	Text letterText;
	Text onletterText;

	string letterInput;
	string context;

	bool letterbox_ison = false;
	bool input_isfocused = false;

	//bgm_setting
	
	public static AudioSource backMusic;

	// Use this for initialization
	void OnEnable ()
	{
		letterGuide = GameObject.Find ("LetterGuide");
		textview = GameObject.Find("View");
		letter = GameObject.Find("TextInput");
		onLetter = GameObject.Find ("LetterText");

		letterText = GameObject.Find ("TextView").GetComponent<Text> ();
		onletterText = GameObject.Find ("LetterText").GetComponent<Text> ();

		textview.SetActive (false);
		letterGuide.SetActive (false);
		onLetter.SetActive (false);

		guide = GameObject.Find("/Canvas/Panel/Guide");
		guide.SetActive (false);


		//backMusic = GameObject.Find ("BGM").GetComponent<AudioSource> ();
		if (GameManager.bgm) {
			//backMusic.Play();		
		}
	//	letterBox = GameObject.Find ("letterInput").GetComponent<Text> ();
	//	Debug.Log("letterTxt is (" + letterInput + " )");

		
	}
	
	// Update is called once per frame
	void Update ()
	{
		letterInput = letterText.text;
		onletterText.text =letterText.text;

		Debug.Log("Script: IntroScene.cs // _currentItemIndex = " + LevelMenu2D._currentItemIndex );

		ray = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Debug.Log (ray);
		hit = Physics2D.Raycast (ray, Vector2.zero);

		// Scene5_writing letter Input

		if(LevelMenu2D._currentItemIndex == 4)
		{		
			if(letterbox_ison == false){
				Invoke ("EnableLetterBox", 1.0f);
				letterbox_ison = true;
			}

			//letterBox = GameObject.Find ("/Canvas/letter_box/letterInput").GetComponent<Text> ();
			//Debug.Log("letterTxt is (" + letterInput + " )");
		} else if(LevelMenu2D._currentItemIndex != 4)
		{
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
	}

	public void clickedWrite(){
		textview.SetActive (true);
	}

	public void GoToSelectScene()
	{
		LevelMenu2D._currentItemIndex = 0;
		Debug.Log("Go to Select Scene");
		//backMusic.GetComponent<AudioSource>().clip = (AudioClip) Resources.Load (null);
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
		//Debug.Log("letterTxt is (" + letterInput + " )");

	}


	public void DisableLetterBox()
	{
		textview.SetActive (false);
		letterGuide.SetActive (false);
		onLetter.SetActive (false);
	}






}
