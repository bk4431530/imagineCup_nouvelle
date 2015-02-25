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

	public static bool[] postCard1;
	public static bool[] postCard2;
	public static bool[] postCard3;
	public static bool[] postCard4;
	public static bool[] postCard5;
	public static bool[] postCard6;
	public static bool[] postCard7;
	public static bool[] postCard8;
	public static bool[] postCard9;
	public static bool[] postCard10;

	public static bool vibration = false;
	public static bool bgm = false;

	//temporary
	public static int currentLife = 5;
	public static int currentQuillPen = 0;
	public static int currentPiece = 0;
	public static int currentEpisode = 0;

	public static bool magnet_equip = false;
	public static bool booster_equip = false;
	public static bool shield_equip = false;
	public static int mysteryBox_equip = 0;




	//player preference

	public static void initData()
	{
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

		//temporary
		//PlayerPrefs.SetInt ("Life", life);
		PlayerPrefsX.SetBool ("Magnet_equip", magnet_equip);
		PlayerPrefsX.SetBool ("Booster_equip", booster_equip);
		PlayerPrefsX.SetBool ("Shield_equip", shield_equip);
		PlayerPrefs.SetInt ("MysteryBox_equip", mysteryBox_equip);

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

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
