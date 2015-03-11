using UnityEngine;
using System.Collections;

public class Tutorial_SelectScene : MonoBehaviour {


	public GameObject Tut_Canvas;
	public GameObject Tut_bg;
	public GameObject Tut_help1;
	public GameObject Tut_help2;
	public GameObject Tut_help3;



	// Use this for initialization

	void Awake()
	{
		 
	}
	void Start ()
	{
		Tut_Canvas = GameObject.Find ("TutorialCanvas");
		Tut_bg = GameObject.Find ("/TutorialCanvas/Background");
		Tut_help1 = GameObject.Find ("/TutorialCanvas/Background/Help1");
		Tut_help2 = GameObject.Find ("/TutorialCanvas/Background/Help2");
		Tut_help3 = GameObject.Find ("/TutorialCanvas/Background/Help3");

		DisableTutorialCanvas ();

		if(GameManager.Tutorial_SelectScene) //원래값 : true
		{
			//Tutorial Starts

			if(GameManager.Tutorial_SelectScene_PlayIntro == true)
			{	
				StartTutorial();
				EnableHelp3();
			}
			else
			{
				StartTutorial();
				EnableHelp1 ();
			}
			
		}
	}
	
	// Update is called once per frame
	void Update () {
	

	}

	////////////////////////////////////////////////////

	public void StartTutorial()
	{
		Tut_Canvas.SetActive (true);
		Tut_bg.SetActive (true);

		Debug.Log ("StartTutorial() 실행");
	}


	///////////////////////////////////////////////////	

	public void EnableHelp1()
	{
		Tut_help1.SetActive (true);
		Debug.Log ("EnableHelp1() 실행");
	}

	public void DisableHelp1()
	{
		Tut_help1.SetActive (false);
		Debug.Log ("DisableHelp1() 실행");

	}

	public void EnableHelp2()
	{
		Tut_help2.SetActive (true);
		GameManager.Tutorial_SelectScene_PlayIntro = true;
		Debug.Log ("GameManager.Tutorial_SelectScene_PlayIntro 값은 " + GameManager.Tutorial_SelectScene_PlayIntro);
		Debug.Log ("EnableHelp2() 실행");
	}
	
	public void DisableHelp2()
	{
		Tut_help2.SetActive (false);
		Debug.Log ("DisableHelp2() 실행");
		
	}

	public void EnableHelp3()
	{
		Tut_help3.SetActive (true);
		Debug.Log ("EnableHelp3() 실행");
	}
	
	public void DisableHelp3()
	{
		Tut_help3.SetActive (false);
		Debug.Log ("DisableHelp3() 실행");
		
	}


	////////////////////////////////////////////////////////////////	




	public void DisableTutorialCanvas()
	{


		Tut_help1.SetActive (false);
		Tut_help2.SetActive (false);
		Tut_help3.SetActive (false);
		Tut_bg.SetActive (false);
		Tut_Canvas.SetActive (false);

		//playTutorial = false;

		Debug.Log ("DisableTutorialCanvas() 실행");

	}





}

