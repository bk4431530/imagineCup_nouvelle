using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tutorial_Monday : MonoBehaviour {
	
	public GameObject Tut_Canvas;
	public GameObject Tut_bg;
	public GameObject Tut_help1;
	public GameObject Tut_help1_2;
	public GameObject Tut_help2;
	public GameObject Tut_help3;
	public GameObject Tut_help4;	

	private int help_num = 0;
	private bool help1_2 = false;
	private bool help2 = false;
	private bool help3 = false;
	private bool help4 = false;

	public GameObject player;
	public GameObject circle;
	public GameObject puzzle;
	public GameObject cat;

	public GameObject loadingScreen;
	AudioSource backmusic;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.Find ("player");
		Tut_Canvas = GameObject.Find ("TutorialCanvas");
		//Tut_bg = GameObject.Find ("/TutorialCanvas/Background");
		Tut_help1 = GameObject.Find ("/TutorialCanvas/Help1");
		Tut_help1_2 = GameObject.Find("/TutorialCanvas/Help1_2");
		Tut_help2 = GameObject.Find ("/TutorialCanvas/Help2");
		Tut_help3 = GameObject.Find ("/TutorialCanvas/Help3");
		Tut_help4 = GameObject.Find ("/TutorialCanvas/Help4");

		circle = GameObject.Find ("circle");
		puzzle = GameObject.Find ("puzzle");

		loadingScreen = GameObject.Find ("Loading_Screen");

		backmusic = GameManager.backMusic;
		if (GameManager.bgm) {
			backmusic.Play ();		
		}
		DisableTutorialCanvas ();

		circle.SetActive (false);
		loadingScreen.SetActive (false);

		StartTutorial();
		EnableHelp1 ();

		//Invoke ("Timezero", 1.0f);
		Timezero ();
		PlayerControl_tutorial.PSpause = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(TouchHandler.Mswiped == true && help_num == 1)
		{
			DisableHelp1();
			PauseFalse();
			player.rigidbody2D.velocity = Vector2.zero;
			player.rigidbody2D.AddForce (new Vector2(150, 300));
		}

		if(player.transform.position.x > 0 && help_num == 0 && !help1_2)
		{
			EnableHelp1_2();
			PlayerControl_tutorial.PSpause = true;
			help1_2 = true;
		}

		if(TouchHandler.Mswiped == true && help_num == 10 && help1_2)
		{
			DisableHelp1_2();
			PauseFalse();
			player.rigidbody2D.velocity = Vector2.zero;
			player.rigidbody2D.AddForce (new Vector2(150, 300));
		}

		if (player.transform.position.x > 11.5 && player.transform.position.x < 12.5 && help_num == 0 && !help2) {
			EnableHelp2();
			PlayerControl_tutorial.PSpause = true;
			help2 = true;
		}
		/*
		if (TouchHandler.Mswiped == true && help_num == 2) {
			help_num = 0;
			Invoke("DisableHelp2",1.0f);
			//DisableHelp2 ();
			PlayerControl_tutorial.PSpause = false;
		}
		*/
		if (player.GetComponent<CatchedbyCat_tutorial> ().PS_cat == PlayerState_cat.CatchedByCat && help_num == 0 && !help3) {
			EnableHelp3();
			PlayerControl_tutorial.PSpause = true;
			help3 = true;
		}

		if (player.GetComponent<CatchedbyCat_tutorial> ().PS_cat == PlayerState_cat.Free && help_num == 3 && help3) {
			DisableHelp3 ();
			//PauseFalse();
		}

		if (PlayerControl_tutorial.isClear && !help4) {
			EnableHelp4();
			help4 = true;
		}
	}

	/////////
	void Timezero(){
		Time.timeScale = 0;
	}

	void PauseFalse(){
		PlayerControl_tutorial.PSpause = false;
		player.rigidbody2D.isKinematic = true;
		player.rigidbody2D.isKinematic = false;
	}

	/////////////////////////////////
	
	public void DisableTutorialCanvas()
	{
		
		
		Tut_help1.SetActive (false);
		Tut_help1_2.SetActive(false);
		Tut_help2.SetActive (false);
		Tut_help3.SetActive (false);
		Tut_help4.SetActive (false);

		//Tut_bg.SetActive (false);
		Tut_Canvas.SetActive (false);
		
		//playTutorial = false;
		
		Debug.Log ("DisableTutorialCanvas() 실행");
		
	}
	
	////////////////////////////////////////////////////
	
	public void StartTutorial()
	{
		Tut_Canvas.SetActive (true);
		//Tut_bg.SetActive (true);
		Debug.Log ("StartTutorial() 실행");
	}
	
	
	///////////////////////////////////////////////////   
	
	/// help1
	public void EnableHelp1()
	{
		Tut_help1.SetActive (true);
		Debug.Log ("EnableHelp1() 실행");
		help_num = 1;
	}
	
	public void DisableHelp1()
	{
		Time.timeScale = 1;	
		Tut_help1.SetActive (false);
		Debug.Log ("DisableHelp1() 실행");
		help_num = 0;
	}

	public void EnableHelp1_2()
	{
		Timezero ();
		Tut_help1_2.SetActive (true);
		Debug.Log ("EnableHelp1_2() 실행");
		help_num = 10;
	}

	public void DisableHelp1_2()
	{
		Time.timeScale = 1;
		Tut_help1_2.SetActive (false);
		Debug.Log ("DisableHelp1_2() 실행");
		help_num = 0;
	}
	
	// help2
	public void EnableHelp2()
	{
		Timezero ();
		circle.SetActive (true);
		Tut_help2.SetActive (true);
		Debug.Log ("EnableHelp2() 실행");
		help_num = 2;
	}
	
	public void DisableHelp2()
	{
		Time.timeScale = 1;
		circle.SetActive (false);
		Tut_help2.SetActive (false);
		Debug.Log ("DisableHelp2() 실행");
		PauseFalse ();
		player.rigidbody2D.AddForce (new Vector2(10, 400));
		help_num = 0;
	}
	
	//help3
	public void EnableHelp3()
	{
		Invoke ("Timezero", 0.5f);
		Tut_help3.SetActive (true);
		Debug.Log ("EnableHelp3() 실행");
		help_num = 3;
	}
	
	public void DisableHelp3()
	{
		Time.timeScale = 1;
		Tut_help3.SetActive (false);
		Debug.Log ("DisableHelp3() 실행");
		PauseFalse ();
		player.rigidbody2D.AddForce (new Vector2(150, 300));
		help_num = 0;
	}
	
	//help4
	public void EnableHelp4()
	{
		Tut_help4.SetActive (true);
		Debug.Log ("EnableHelp4() 실행");
		help_num = 4;
	}
	
	public void DisableHelp4()
	{
		Debug.Log ("DisableHelp4() 실행");
		help_num = 0;
		loadingScreen.SetActive (true);
		GoToGame ();
	}

	
	/////SkipButton  
	public void SkipButtonClicked()
	{
		loadingScreen.SetActive (true);
		GoToGame ();
	}

	public void GoToGame(){
		Time.timeScale = 1;

		GameManager.Tutorial_Monday = false;
		PlayerPrefsX.SetBool ("TutorialMonday", GameManager.Tutorial_Monday);

		GameManager.currentLife = 5;

		Application.LoadLevel ("Monday");
	}
	
	
}