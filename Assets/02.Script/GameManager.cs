using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static int quillPen = 0;
	public static int piece = 0;
	public static int stamp = 0;

	public static int episode = 0;
	public static int paperPlaneState = 0;

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
	
	public static bool[][] postCard = new bool[10][];

	/*
	public static bool[] postCard1 = new bool[6];
	public static bool[] postCard2 = new bool[6];
	public static bool[] postCard3 = new bool[6];
	public static bool[] postCard4 = new bool[6];
	public static bool[] postCard5 = new bool[6];
	public static bool[] postCard6 = new bool[6];
	public static bool[] postCard7 = new bool[6];
	public static bool[] postCard8 = new bool[6];
	public static bool[] postCard9 = new bool[6];
	public static bool[] postCard10 = new bool[6];
`	*/

	//option
	public static bool vibration = true;
	public static bool bgm = true;

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
	public static string To_name = "nou";
	public static string letter_txt ="Hi, I'm bell \n I think i love you...<3";
	public static string From_name ="bell";
	
	public static string ZipL ="123";
	public static string ZipR = "456";
	public static string Addr = "Seoul, Donjack-gu, Soongsil university";

	public static void initData()
	{
		PlayerPrefs.SetInt ("Quilpen", 0);
		PlayerPrefs.SetInt ("Piece", 0);
		PlayerPrefs.SetInt ("Stamp", 0);
		
		PlayerPrefs.SetInt ("PaperPlaneState", 0);
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

		//각각 컬렉션마다 5조각
		for (int i = 0; i < postCard.Length; i++) {
			postCard[i] = new bool[5];
		}

		for (int i = 0; i < postCard.Length; i++) {
			for (int j = 0; j < postCard[i].Length; j++) {
				postCard[i][j] = false;
			}
		}

		PlayerPrefsX.SetBoolArray ("PostCard1", postCard[0]);
		PlayerPrefsX.SetBoolArray ("PostCard2", postCard[1]);
		PlayerPrefsX.SetBoolArray ("PostCard3", postCard[2]);
		PlayerPrefsX.SetBoolArray ("PostCard4", postCard[3]);
		PlayerPrefsX.SetBoolArray ("PostCard5", postCard[4]);
		PlayerPrefsX.SetBoolArray ("PostCard6", postCard[5]);
		PlayerPrefsX.SetBoolArray ("PostCard7", postCard[6]);
		PlayerPrefsX.SetBoolArray ("PostCard8", postCard[7]);
		PlayerPrefsX.SetBoolArray ("PostCard9", postCard[8]);
		PlayerPrefsX.SetBoolArray ("PostCard10", postCard[9]);
		
		PlayerPrefsX.SetBool ("Vibration", true);
		PlayerPrefsX.SetBool ("BGM", true);


		
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

		quillPen = PlayerPrefs.GetInt ("Quilpen");
		piece = PlayerPrefs.GetInt ("Piece");
		stamp = PlayerPrefs.GetInt ("Stamp");
		
		episode = PlayerPrefs.GetInt ("Episode");
		paperPlaneState = PlayerPrefs.GetInt ("PaperPlaneState");
		
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

		/*
		postCard1 = PlayerPrefsX.GetBoolArray ("Postcard1");
		postCard2 = PlayerPrefsX.GetBoolArray ("Postcard2");
		postCard3 = PlayerPrefsX.GetBoolArray ("Postcard3");
		postCard4 = PlayerPrefsX.GetBoolArray ("Postcard4");
		postCard5 = PlayerPrefsX.GetBoolArray ("Postcard5");
		postCard6 = PlayerPrefsX.GetBoolArray ("Postcard6");
		postCard7 = PlayerPrefsX.GetBoolArray ("Postcard7");
		postCard8 = PlayerPrefsX.GetBoolArray ("Postcard8");
		postCard9 = PlayerPrefsX.GetBoolArray ("Postcard9");
		postCard10 = PlayerPrefsX.GetBoolArray ("Postcard10");
		*/

		postCard[0] = PlayerPrefsX.GetBoolArray ("Postcard1");
		postCard[1] = PlayerPrefsX.GetBoolArray ("Postcard2");
		postCard[2] = PlayerPrefsX.GetBoolArray ("Postcard3");
		postCard[3] = PlayerPrefsX.GetBoolArray ("Postcard4");
		postCard[4] = PlayerPrefsX.GetBoolArray ("Postcard5");
		postCard[5] = PlayerPrefsX.GetBoolArray ("Postcard6");
		postCard[6] = PlayerPrefsX.GetBoolArray ("Postcard7");
		postCard[7] = PlayerPrefsX.GetBoolArray ("Postcard8");
		postCard[8] = PlayerPrefsX.GetBoolArray ("Postcard9");
		postCard[9] = PlayerPrefsX.GetBoolArray ("Postcard10");
		
		vibration = PlayerPrefsX.GetBool("Vibration");
		bgm = PlayerPrefsX.GetBool("Bgm");
		
		/*temporary
		life = 5;
		public static bool magnet_equip = false;
		public static bool booster_equip = false;
		public static bool shield_equip = false;
		public static int mysteryBox_equip = 0;
		*/


	}


	void Awake(){
		backMusic = GameObject.Find ("BGM").GetComponent<AudioSource> ();
		DontDestroyOnLoad(backMusic.gameObject);
	}


	// Use this for initialization
	void Start () {
		Screen.SetResolution(Screen.width, Screen.width/16*9, true);
		if(backMusic.GetComponent<AudioSource>().clip == null){
			backMusic.GetComponent<AudioSource>().clip = (AudioClip) Resources.Load ("main_sunnyday");
			backMusic.Play();
		}
	}
	

}
