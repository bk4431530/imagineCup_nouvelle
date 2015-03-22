using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Equip_Scene : MonoBehaviour {
	
	GameObject booster;
	GameObject magnet;
	GameObject shield;
	GameObject mysteryBox;
	
	int item_cnt = 0;
	
	GameObject buyItem_popup;
	GameObject loading_screen;
	
	int items;
	Text itemTxt;
	public GameObject randomItem;

	Text booster_cnt;
	Text magnet_cnt;
	Text shield_cnt;
	Text mysteryBox_cnt;
	
	AudioSource backMusic;
	
	
	string selectedScene;
	//GameObject thumbnail;
	GameObject effect;
	//public Sprite[] thumbnail_Img;
	public Sprite[] effect_Img;
	public Sprite[] item_Img;


	//bgm
	string audio_name;

	//sound effect
	public static AudioSource SFX_button;
	public static AudioSource SFX_equipitem;
	public static AudioSource SFX_itemBuy;
	
	public int money;

	void Start () {
		booster = GameObject.Find ("Booster");
		magnet = GameObject.Find ("Magnet");
		shield = GameObject.Find ("Shield");
		mysteryBox = GameObject.Find ("MysteryBox");
		buyItem_popup = GameObject.Find ("Popup_buyItem");
		loading_screen = GameObject.Find ("Loading_Screen");
		//thumbnail = GameObject.Find ("Canvas/leftMenu/Image");
		effect = GameObject.Find ("Canvas/leftMenu/effectsBar/mask1/effect1");

		backMusic = GameManager.backMusic;
		itemTxt = GameObject.Find ("ItemTxt").GetComponent<Text> ();
		
		booster_cnt = booster.transform.FindChild("count").GetComponent<Text> ();
		magnet_cnt = magnet.transform.FindChild("count").GetComponent<Text> ();
		shield_cnt = shield.transform.FindChild("count").GetComponent<Text> ();
		mysteryBox_cnt = mysteryBox.transform.FindChild("count").GetComponent<Text> ();
		
		buyItem_popup.SetActive (false);
		loading_screen.SetActive (false);
		
		GameManager.quillPen = 1000;
		GameManager.currentEpisode = 1;

		//sound effect
		SFX_button = GameObject.Find ("/SFX/button").GetComponent<AudioSource>();	
		SFX_button.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("ButtonClick");

		SFX_equipitem = GameObject.Find ("/SFX/equipItem").GetComponent<AudioSource> ();
		SFX_equipitem.GetComponent<AudioSource> ().clip = (AudioClip)Resources.Load ("Equip");

		SFX_itemBuy = GameObject.Find ("/SFX/itemBuy").GetComponent<AudioSource> ();
		SFX_itemBuy.GetComponent<AudioSource> ().clip = (AudioClip)Resources.Load ("ItemBuy");
		
		//수정중
	/*	
		booster_cnt.text = GameManager.booster.ToString();
		Debug.Log ("booster_cnt.text = " + booster_cnt.text);

		magnet_cnt.text = GameManager.magnet.ToString();
		Debug.Log ("magnet_cnt.text = " + magnet_cnt.text);

		shield_cnt.text = GameManager.shield.ToString();
		Debug.Log ("shield_cnt.text = " + shield_cnt.text);

		mysteryBox_cnt.text = GameManager.mysteryBox.ToString();
		Debug.Log ("mysteryBox_cnt.text = " + mysteryBox_cnt.text); */

		switch (GameManager.currentEpisode) {
		case 1:
			Debug.Log("monday");
			selectedScene = "Monday";
			//thumbnail.GetComponent<Image>().sprite = thumbnail_Img[0];
			audio_name="BGM_Monday";
			break;
		case 2:
			selectedScene = "Tuesday";
			//thumbnail.GetComponent<Image>().sprite = thumbnail_Img[1];
			break;
		case 3:
			selectedScene = "Wednesday";
			//thumbnail.GetComponent<Image>().sprite = thumbnail_Img[2];
			break;
		case 4:
			selectedScene = "Thursday";
			//thumbnail.GetComponent<Image>().sprite = thumbnail_Img[3];
			break;
		case 5:
			selectedScene = "Friday";
			//thumbnail.GetComponent<Image>().sprite = thumbnail_Img[4];
			break;
		default:
			Debug.Log("selected Episode = null");
			break;
		}


		randomItem = GameObject.Find ("Popups/Popup_buyItem/Panel/randomItem");


	}
	
	void Update(){

		
		booster_cnt.text = GameManager.booster.ToString();
		magnet_cnt.text = GameManager.magnet.ToString();
		shield_cnt.text = GameManager.shield.ToString();
		mysteryBox_cnt.text = GameManager.mysteryBox.ToString(); 
	

		switch (GameManager.paperPlaneState) {
		case 0: 
			effect.GetComponent<Image>().sprite = effect_Img[0];
			break;
		case 1:
			effect.GetComponent<Image>().sprite = effect_Img[1];
			break;
		case 2:
			effect.GetComponent<Image>().sprite = effect_Img[2];
			break;
		case 3:
			effect.GetComponent<Image>().sprite = effect_Img[3];
			break;
		case 4:
			effect.GetComponent<Image>().sprite = effect_Img[4];
			break;
		case 5:
			effect.GetComponent<Image>().sprite = effect_Img[5];
			break;
		case 6:
			effect.GetComponent<Image>().sprite = effect_Img[6];
			break;
		case 7:
			effect.GetComponent<Image>().sprite = effect_Img[7];
			break;
		case 8:
			effect.GetComponent<Image>().sprite = effect_Img[8];
			break;
		}
		
	}
	
	void LoadingScreen () {
		loading_screen.SetActive (true);
		Invoke ("GoToGame", 5.0f);
	}
	
	public void StartClicked(){
		Debug.Log ("Start Button Clicked");
		LoadingScreen ();
	}
	
	void GoToGame(){
		backMusic.GetComponent<AudioSource>().clip = (AudioClip) Resources.Load (audio_name);
		loading_screen.SetActive (true);
		Application.LoadLevel (selectedScene);
		
		
	}
	
	
	
	//items
	
	public void ClickedBoosterEquip(){
		if (GameManager.booster_equip == false && item_cnt < 3 && GameManager.booster >0) {
			booster.GetComponent<Image> ().color = Color.Lerp (Color.black,Color.white,0.9f);
			GameManager.booster_equip = true;
			item_cnt++;
			Debug.Log ("Booster equiped" + "  &  item_cnt = " + item_cnt);
		} else if (GameManager.booster_equip == true){
			booster.GetComponent<Image> ().color = Color.Lerp (Color.white,Color.white,1.0f);
			GameManager.booster_equip = false;
			item_cnt--;
			Debug.Log ("Booster unequiped" + "  &  item_cnt = " + item_cnt);
		}
		
	}
	
	public void ClickedMagnetEquip(){
		if (GameManager.magnet_equip == false && item_cnt < 3 && GameManager.magnet >0) {
			magnet.GetComponent<Image> ().color = Color.Lerp (Color.black,Color.white,0.9f);
			GameManager.magnet_equip = true;
			item_cnt++;
			Debug.Log ("Magnet equiped" + "  &  item_cnt = " + item_cnt);
		} else if (GameManager.magnet_equip == true){
			magnet.GetComponent<Image> ().color = Color.Lerp (Color.white,Color.white,1.0f);
			GameManager.magnet_equip = false;
			item_cnt--;
			Debug.Log ("Magnet unequiped" + "  &  item_cnt = " + item_cnt);
		}
	}
	
	public void ClickedShieldEquip(){
		if (GameManager.shield_equip == false && item_cnt < 3 && GameManager.shield >0) {
			shield.GetComponent<Image> ().color = Color.Lerp (Color.black,Color.white,0.9f);
			GameManager.shield_equip = true;
			item_cnt++;
			Debug.Log ("Shield equiped" + "  &  item_cnt = " + item_cnt);
		} else if (GameManager.booster_equip == true){
			shield.GetComponent<Image> ().color = Color.Lerp (Color.white,Color.white,1.0f);
			GameManager.shield_equip = false;
			item_cnt--;
			Debug.Log ("Shield unequiped" + "  &  item_cnt = " + item_cnt);
		}
	}
	
	public void ClickedMysteryBoxEquip(){
		if (GameManager.mysteryBox_equip == 0 && item_cnt < 3 && GameManager.mysteryBox >0) {
			mysteryBox.GetComponent<Image> ().color = Color.Lerp (Color.black,Color.white,0.9f);
			GameManager.mysteryBox_equip = 1;
			item_cnt++;
			Debug.Log ("MysteryBox equiped" + "  &  item_cnt = " + item_cnt);
		} else if (GameManager.mysteryBox_equip > 0){
			mysteryBox.GetComponent<Image> ().color = Color.Lerp (Color.white,Color.white,1.0f);
			GameManager.mysteryBox_equip = 0;
			item_cnt--;
			Debug.Log ("MysteryBox unequiped" + "  &  item_cnt = " + item_cnt);
		}
	}
	
	
	
	
	
	
	
	//item popup
	public void clickedBuyItems(int i)
	{
		//buyItem_popup.SetActive (true);
		items = i;
		bool lack = false;
		
		switch (items) 
		{
		case 0:
			if(GameManager.quillPen > GameManager.booster_price)
			{
				GameManager.quillPen = GameManager.quillPen - GameManager.booster_price;
				GameManager.booster++;
			}else{
			}
			break;
		case 1:
			if(GameManager.quillPen > GameManager.magnet_price)
			{
				GameManager.quillPen = GameManager.quillPen - GameManager.magnet_price;
				GameManager.magnet++;

			}else{
			}
			break;
		case 2:
			if(GameManager.quillPen > GameManager.shield_price)
			{
				GameManager.quillPen = GameManager.quillPen - GameManager.shield_price;
				GameManager.shield++;
				
			}else{
			}
			break;
		case 3:
			if(GameManager.quillPen > GameManager.mysteryBox_price)
			{
				buyItem_popup.SetActive (true);
				GameManager.quillPen = GameManager.quillPen - GameManager.mysteryBox_price;
				mysterybox();

			}else{
				itemTxt.text ="You don't have enough Quilpens!!";
			}
			break;
		}


		
		
	}
	
	


	void mysterybox()
	{
		string RandomItem ="";
		int rand = (int)Random.Range(0,3);
		switch (rand) {		
			case 0:
				RandomItem ="booster!";
				randomItem.GetComponent<Image>().sprite = item_Img[0];
				GameManager.booster++;	
				break;
			case 1:
				RandomItem ="magnet!";
				randomItem.GetComponent<Image>().sprite = item_Img[1];
				GameManager.magnet++;
				break;
			case 2:
				RandomItem ="shield!";
				randomItem.GetComponent<Image>().sprite = item_Img[2];
				GameManager.shield++;
				break;
		}
		itemTxt.text ="You get " + RandomItem;
		Invoke("clickClose",1.0f);

	}

	
	public void clickClose()
	{
		buyItem_popup.SetActive (false);
	}

	public void ButtonSound()
	{
		if(GameManager.sfx)
		{
			//SFX_button.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("ButtonClick");
			SFX_button.Play();
			Debug.Log("Equip.cs에서 ButtonSound 함수실행");
			
		}
		
	}

	public void EquipItemSound()
	{
		if(GameManager.sfx)
		{
			SFX_equipitem.Play ();
			Debug.Log("Equip.cs에서 EquipItemSound() 실행");

		}

	}

	public void BuyItemSound()
	{
		if(GameManager.sfx)
		{
			SFX_itemBuy.Play ();
			Debug.Log("Equip.cs에서 BuyItemSound() 실행");
			
		}
		
	}


	
}
