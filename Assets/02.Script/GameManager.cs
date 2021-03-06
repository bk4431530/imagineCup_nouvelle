﻿using UnityEngine;
using System.Collections;


public class GameManager : MonoBehaviour {
	
	public static int quillPen = 0;
	public static int piece = 0;
	public static int stamp = 0;
	
	public static int episode = 0;
	public static int[] paperPlaneState = {0,0,0};


	
	public static int heart_ep1 = 0;
	public static int heart_ep2 = 0;
	public static int heart_ep3 = 0;
	public static int heart_ep4 = 0;
	public static int heart_ep5 = 0;
	
	public static int heart_total = 0;
	
	public static int magnet = 0;
	public static int booster = 0;
	public static int shield = 0;
	public static int mysteryBox = 0;

	
	//option
	public static bool vibration = true;
	public static bool bgm = true;
	public static bool sfx = true;
	
	//temporary
	public static int currentLife = 5;
	public static int currentQuillPen = 0;
	public static int currentPiece = 0;
	public static int currentEpisode = 0;
	
	public static bool magnet_equip = false;
	public static bool booster_equip = false;
	public static bool shield_equip = false;
	public static int mysteryBox_equip = 0;
	
	//price
	public static int openEp_price = 20;
	public static int booster_price = 150;
	public static int magnet_price = 50;
	public static int shield_price = 100;
	public static int mysteryBox_price = 100;
	
	//bgm_setting
	
	public static AudioSource backMusic;
	
	//input
	/* //English Version
	public static string To_name = "nou";
	public static string letter_txt ="Hi, I'm bell \n I think i love you...<3"; */

	//임시로 한글 버전 for 교내전시
	public static string To_name = "제이크";
	public static string letter_txt ="안녕, 나는 벨이라고 해. \n 너를 좋아해...♥♡";

	public static string From_name ="bell";
	
	public static string ZipL ="123";
	public static string ZipR = "456";
	public static string Addr = "Seoul, Donjack-gu, Soongsil university";

	public static int[] postCard = {5,0,0,0,0,0,5,0,5,0};

	
	//Tutorial_SelectScene//////////////////////////////
	public static bool Tutorial_SelectScene = true;
	public static bool Tutorial_SelectScene_PlayIntro = true;
	public static bool Tutorial_SelectScene_Monday = false;
	
	//Tutorial_EquipScene//////////////////////////////
	public static bool Tutorial_EquipScene = true;

	//Tutorial_Game
	public static bool Tutorial_Monday = false;
	
	
	
	public static void initData()
	{
		Debug.Log ("init Data");

		PlayerPrefs.SetInt ("Quilpen", 0);
		PlayerPrefs.SetInt ("Piece", 0);
		PlayerPrefs.SetInt ("Stamp", 0);
		
		PlayerPrefs.SetInt ("PaperPlaneState1", 0);
		PlayerPrefs.SetInt ("PaperPlaneState2", 0);
		PlayerPrefs.SetInt ("PaperPlaneState3", 0);
		PlayerPrefs.SetInt ("Episode", 0);
		
		PlayerPrefs.SetInt ("Heart_ep1", 0);
		PlayerPrefs.SetInt ("Heart_ep2", 0);
		PlayerPrefs.SetInt ("Heart_ep3", 0);
		PlayerPrefs.SetInt ("Heart_ep4", 0);
		PlayerPrefs.SetInt ("Heart_ep5", 0);
		
		PlayerPrefs.SetInt ("Heart_total", 0);
		
		PlayerPrefs.SetInt ("Magnet", 0);
		PlayerPrefs.SetInt ("Booster", 0);
		PlayerPrefs.SetInt ("Shield", 0);
		PlayerPrefs.SetInt ("MysteryBox", 0);
		
		
		//
		PlayerPrefs.SetString ("To",To_name);
		PlayerPrefs.SetString ("Letter",letter_txt);
		PlayerPrefs.SetString ("From",From_name);
		
		PlayerPrefs.SetString ("ZipL",ZipL);
		PlayerPrefs.SetString ("ZipR",ZipR);
		PlayerPrefs.SetString ("Address",Addr);
		
		
		//collection
		PlayerPrefs.SetInt ("Postcard1",postCard[0]);
		PlayerPrefs.SetInt ("Postcard2",postCard[1]);
		PlayerPrefs.SetInt ("Postcard3",postCard[2]);
		PlayerPrefs.SetInt ("Postcard4",postCard[3]);
		PlayerPrefs.SetInt ("Postcard5",postCard[4]);
		PlayerPrefs.SetInt ("Postcard6",postCard[5]);
		PlayerPrefs.SetInt ("Postcard7",postCard[6]);
		PlayerPrefs.SetInt ("Postcard8",postCard[7]);
		PlayerPrefs.SetInt ("Postcard9",postCard[8]);
		PlayerPrefs.SetInt ("Postcard10",postCard[9]);


		PlayerPrefsX.SetBool ("Vibration", true);
		PlayerPrefsX.SetBool ("BGM", true);


		
		//Tutorial_SelectScene /////////////////////////
		PlayerPrefsX.SetBool ("TutorialSelectScene", true);
		PlayerPrefsX.SetBool ("TutorialSelectScenePlayIntro", true);
		PlayerPrefsX.SetBool ("TutorialSelectSceneMonday", true);

		//Tutorial_EquipScene//////////////////////////////
		PlayerPrefsX.SetBool ("TutorialEquipScene", true);

		//Tutorial_Monday
		PlayerPrefsX.SetBool ("TutorialMonday", false);
		
		/*
      PlayerPrefs.SetInt ("Quilpen", quillPen);
      PlayerPrefs.SetInt ("Piece", piece);
      PlayerPrefs.SetInt ("Stamp", stamp);

      PlayerPrefs.SetInt ("PaperPlaneState", paperPlaneState);
      PlayerPrefs.SetInt ("Episode", episode);

      PlayerPrefs.SetInt ("Heart_ep1", heart_ep1);
      PlayerPrefs.SetInt ("Heart_ep2", heart_ep2);
      PlayerPrefs.SetInt ("Heart_ep3", heart_ep3);
      PlayerPrefs.SetInt ("Heart_ep4", heart_ep4);
      PlayerPrefs.SetInt ("Heart_ep5", heart_ep5);

      PlayerPrefs.SetInt ("Heart_total", heart_total);

      PlayerPrefs.SetInt ("Magnet", magnet);
      PlayerPrefs.SetInt ("Booster", booster);
      PlayerPrefs.SetInt ("Shield", shield);
      PlayerPrefs.SetInt ("MysteryBox", mysteryBox);

      PlayerPrefsX.SetBoolArray ("PostCard1", postCard1);
      PlayerPrefsX.SetBoolArray ("PostCard2", postCard2);
      PlayerPrefsX.SetBoolArray ("PostCard3", postCard3);
      PlayerPrefsX.SetBoolArray ("PostCard4", postCard4);
      PlayerPrefsX.SetBoolArray ("PostCard5", postCard5);
      PlayerPrefsX.SetBoolArray ("PostCard6", postCard6);
      PlayerPrefsX.SetBoolArray ("PostCard7", postCard7);
      PlayerPrefsX.SetBoolArray ("PostCard8", postCard8);
      PlayerPrefsX.SetBoolArray ("PostCard9", postCard9);
      PlayerPrefsX.SetBoolArray ("PostCard10", postCard10);

      PlayerPrefsX.SetBool ("Vibration", vibration);
      PlayerPrefsX.SetBool ("BGM", bgm);
      */


		PlayerPrefs.Save ();
	}
	
	
	public static void getData()
	{
		Debug.Log ("getData");
		quillPen = PlayerPrefs.GetInt ("Quilpen");
		piece = PlayerPrefs.GetInt ("Piece");
		stamp = PlayerPrefs.GetInt ("Stamp");
		
		episode = PlayerPrefs.GetInt ("Episode");
		paperPlaneState[0] = PlayerPrefs.GetInt ("PaperPlaneState1");
		paperPlaneState[1] = PlayerPrefs.GetInt ("PaperPlaneState2");
		paperPlaneState[2] = PlayerPrefs.GetInt ("PaperPlaneState3");


		
		heart_ep1 = PlayerPrefs.GetInt ("Heart_ep1");
		heart_ep2 = PlayerPrefs.GetInt ("Heart_ep2");
		heart_ep3 = PlayerPrefs.GetInt ("Heart_ep3");
		heart_ep4 = PlayerPrefs.GetInt ("Heart_ep4");
		heart_ep5 = PlayerPrefs.GetInt ("Heart_ep5");
		
		
		heart_total =PlayerPrefs.GetInt ("Heart_total");
		
		magnet = PlayerPrefs.GetInt ("Magnet");
		booster = PlayerPrefs.GetInt ("Booster");
		shield = PlayerPrefs.GetInt ("Shield");
		mysteryBox = PlayerPrefs.GetInt ("MysteryBox"); 
		

		
		postCard[0] = PlayerPrefs.GetInt ("Postcard1");
		postCard[1] = PlayerPrefs.GetInt ("Postcard2");
		postCard[2] = PlayerPrefs.GetInt ("Postcard3");
		postCard[3] = PlayerPrefs.GetInt ("Postcard4");
		postCard[4] = PlayerPrefs.GetInt ("Postcard5");
		postCard[5] = PlayerPrefs.GetInt ("Postcard6");
		postCard[6] = PlayerPrefs.GetInt ("Postcard7");
		postCard[7] = PlayerPrefs.GetInt ("Postcard8");
		postCard[8] = PlayerPrefs.GetInt ("Postcard9");
		postCard[9] = PlayerPrefs.GetInt ("Postcard10");
		
		vibration = PlayerPrefsX.GetBool("Vibration");
		bgm = PlayerPrefsX.GetBool("BGM");


		//tutorial - selectscene 변수들 
		Tutorial_SelectScene = PlayerPrefsX.GetBool ("TutorialSelectScene");
		Tutorial_SelectScene_PlayIntro = PlayerPrefsX.GetBool ("TutorialSelectScenePlayIntro");
		Tutorial_SelectScene_Monday = PlayerPrefsX.GetBool ("TutorialSelectSceneMonday");

		// tutoriail- equiscene 변수들
		Tutorial_EquipScene = PlayerPrefsX.GetBool ("TutorialEquipScene");

		// tutorial- Monday
		Tutorial_Monday = PlayerPrefsX.GetBool ("TutorialMonday");

		
		
	}
	
	
	public int target = 80;
	
	void OnEnable(){
		backMusic = GameObject.Find ("BGM").GetComponent<AudioSource> ();
		DontDestroyOnLoad(backMusic.gameObject);
	}
	
	
	void Start () {
		Screen.SetResolution(Screen.width, Screen.width/16*9, true);
		QualitySettings.vSyncCount = 0;
		
		if(backMusic.GetComponent<AudioSource>().clip == null){
			backMusic.GetComponent<AudioSource>().clip = (AudioClip) Resources.Load ("main_sunnyday");
			backMusic.volume = 0.6f;
			backMusic.Play();
		}
	}
	
	void Update(){
		if (target != Application.targetFrameRate) {
			Application.targetFrameRate = target;
		}
	}
	
	
}