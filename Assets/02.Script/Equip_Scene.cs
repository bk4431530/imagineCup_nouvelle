
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
	int price;
	
	Text booster_cnt;
	Text magnet_cnt;
	Text shield_cnt;
	Text mysteryBox_cnt;
	
	AudioSource backMusic;
	
	
	string selectedScene;
	GameObject thumbnail;
	public Sprite[] thumbnail_Img;

	string audio_name;

	
	public int money;
	
	void Start () {
		booster = GameObject.Find ("Booster");
		magnet = GameObject.Find ("Magnet");
		shield = GameObject.Find ("Shield");
		mysteryBox = GameObject.Find ("MysteryBox");
		buyItem_popup = GameObject.Find ("Popup_buyItem");
		loading_screen = GameObject.Find ("Loading_Screen");
		thumbnail = GameObject.Find ("Canvas/leftMenu/Image");
		
		backMusic = GameManager.backMusic;
		itemTxt = GameObject.Find ("ItemTxt").GetComponent<Text> ();
		
		booster_cnt = booster.transform.FindChild("count").GetComponent<Text> ();
		magnet_cnt = magnet.transform.FindChild("count").GetComponent<Text> ();
		shield_cnt = shield.transform.FindChild("count").GetComponent<Text> ();
		mysteryBox_cnt = mysteryBox.transform.FindChild("count").GetComponent<Text> ();
		
		buyItem_popup.SetActive (false);
		loading_screen.SetActive (false);
		
		GameManager.quillPen = money;
		GameManager.currentEpisode = 1;
		
		
	}
	
	void Update(){
		
		
		booster_cnt.text = GameManager.booster.ToString();
		magnet_cnt.text = GameManager.magnet.ToString();
		shield_cnt.text = GameManager.shield.ToString();
		mysteryBox_cnt.text = GameManager.mysteryBox.ToString();
		
		switch (GameManager.currentEpisode) {
		case 1:
			Debug.Log("monday");
			selectedScene = "Monday";
			thumbnail.GetComponent<Image>().sprite = thumbnail_Img[0];
			audio_name="BGM_Monday";
			break;
		case 2:
			selectedScene = "Tuesday";
			thumbnail.GetComponent<Image>().sprite = thumbnail_Img[1];
			break;
		case 3:
			selectedScene = "Wednesday";
			thumbnail.GetComponent<Image>().sprite = thumbnail_Img[2];
			break;
		case 4:
			selectedScene = "Thursday";
			thumbnail.GetComponent<Image>().sprite = thumbnail_Img[3];
			break;
		case 5:
			selectedScene = "Friday";
			thumbnail.GetComponent<Image>().sprite = thumbnail_Img[4];
			break;
		default:
			Debug.Log("selected Episode = null");
			break;
		}
		
		
	}
	
	void LoadingScreen () {
		loading_screen.SetActive (true);
		Invoke ("GoToGame", 1.0f);
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
		buyItem_popup.SetActive (true);
		items = i;
		bool lack = false;
		
		switch (items) 
		{
		case 0:
			if(GameManager.quillPen > GameManager.booster_price)
			{
				itemTxt.text = "Do you want to buy a Booster?";
				price = GameManager.booster_price;
			}else{
				itemTxt.text ="You don't have enough Quilpens!!";
			}
			break;
		case 1:
			if(GameManager.quillPen > GameManager.magnet_price)
			{
				itemTxt.text = "Do you want to buy a Magnet?";
				price = GameManager.magnet_price;
				
			}else{
				itemTxt.text ="You don't have enough Quilpens!!";
			}
			break;
		case 2:
			if(GameManager.quillPen > GameManager.shield_price)
			{
				itemTxt.text = "Do you want to buy a Shield?";
				price = GameManager.shield_price;
				
			}else{
				itemTxt.text ="You don't have enough Quilpens!!";
			}
			break;
		case 3:
			if(GameManager.quillPen > GameManager.mysteryBox_price)
			{
				itemTxt.text = "Do you want to buy a Mystery Box";
				price = GameManager.mysteryBox_price;
				
			}else{
				itemTxt.text ="You don't have enough Quilpens!!";
			}
			break;
		}
		
		
	}
	
	
	public void clickYes()
	{
		GameManager.quillPen = GameManager.quillPen - price;
		switch (items) {		
		case 0:
			GameManager.booster++;
			break;
		case 1:
			GameManager.magnet++;
			break;
		case 2:
			GameManager.shield++;
			break;
		case 3:
			GameManager.mysteryBox++;
			break;
		}
		//itemTxt.text ="You don't have enough Quilpens!!";
		
		buyItem_popup.SetActive (false);
	}
	
	public void clickClose()
	{
		buyItem_popup.SetActive (false);
	}
	
	
	
}
