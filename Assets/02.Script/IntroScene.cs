using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class IntroScene : MonoBehaviour {

	public GameObject guide;
	public GameObject letter;
	public GameObject letterGuide;


	private Vector2 ray;
	private RaycastHit2D hit;

	Text letterBox;

	string letterInput;


	// Use this for initialization
	void Start ()
	{
		guide = GameObject.Find("/Canvas/Panel/Guide");
		guide.SetActive (false);

		letter = GameObject.Find ("/Canvas/Input");
		letter.SetActive (false);

		letterGuide = GameObject.Find ("Canvas/LetterGuide");
		letterGuide.SetActive (false);




	//	letterBox = GameObject.Find ("letterInput").GetComponent<Text> ();
	//	Debug.Log("letterTxt is (" + letterInput + " )");

		
	}
	
	// Update is called once per frame
	void Update ()
	{
		Debug.Log("Script: IntroScene.cs // _currentItemIndex = " + LevelMenu2D._currentItemIndex );

		ray = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Debug.Log (ray);
		hit = Physics2D.Raycast (ray, Vector2.zero);

		// Scene5_writing letter Input

		if(LevelMenu2D._currentItemIndex ==4)
		{		
			Invoke ("EnableLetterBox", 1.0f);


			//letterBox = GameObject.Find ("/Canvas/letter_box/letterInput").GetComponent<Text> ();
			//Debug.Log("letterTxt is (" + letterInput + " )");
		}
		else if(LevelMenu2D._currentItemIndex != 4)
		{
			DisableLetterBox();

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

	public void GoToSelectScene()
	{
		LevelMenu2D._currentItemIndex = 0;
		Debug.Log("Go to Select Scene");

		Application.LoadLevel ("Select_Scene");

	}

	public void FadeOut ()
	{
		float fadeTime = GameObject.Find ("Fading").GetComponent<Fading>().BeginFade(1);

		Invoke ("GoToSelectScene", fadeTime);

	}

	public void EnableLetterBox()
	{
		letter.SetActive(true);
		letterGuide.SetActive(true);

		letterBox = GameObject.Find ("/Canvas/Input").GetComponent<Text> ();
		Debug.Log("letterTxt is (" + letterInput + " )");
		letterInput = letterBox.text;
	}


	public void DisableLetterBox()
	{
		letter.SetActive(false);
		letterGuide.SetActive(false);
	}






}
