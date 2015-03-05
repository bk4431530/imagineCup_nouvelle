using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Equip_Scene : MonoBehaviour {

	GameObject booster;
	GameObject magnet;
	GameObject shield;
	GameObject mysteryBox;

	int item_cnt = 0;

	public GameObject buyItem_popup;
	public int items;
	public Text itemTxt;
	int price;

	AudioSource backMusic;

	// Use this for initialization
	void Start () {
		booster = GameObject.Find ("Booster");
		magnet = GameObject.Find ("Magnet");
		shield = GameObject.Find ("Shield");
		mysteryBox = GameObject.Find ("MysteryBox");
		buyItem_popup.SetActive (false);

		backMusic = GameObject.Find ("BGM").GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Fadeout () {
		float fadeTime = GameObject.Find ("Fading").GetComponent<Fading>().BeginFade(1);
		Invoke ("GoToGame", fadeTime);
	}

	public void StartClicked(){
		Debug.Log ("Start Button Clicked");
		Fadeout ();
	}

	void GoToGame(){
		switch (GameManager.currentEpisode) {
		case 1:
			backMusic.GetComponent<AudioSource>().clip = (AudioClip) Resources.Load ("main_sunnyday");
			Application.LoadLevel ("Monday");
			break;
		case 2:
			Application.LoadLevel ("Tuesday");
			break;
		case 3:
			Application.LoadLevel ("Wednesday");
			break;
		case 4:
			Application.LoadLevel ("Thursday");
			break;
		case 5:
			Application.LoadLevel ("Thursday");
			break;
		default:
			Debug.Log("selected Episode = null");
			break;
		}
	}

	public void ClickedBoosterEquip(){
		if (GameManager.booster_equip == false && item_cnt < 3) {
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
		if (GameManager.magnet_equip == false && item_cnt < 3) {
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
		if (GameManager.shield_equip == false && item_cnt < 3) {
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
		if (GameManager.mysteryBox_equip == 0 && item_cnt < 3) {
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
				itemTxt.text = "Do you want to buy booster?";
				price = GameManager.booster_price;
			}else{
				itemTxt.text ="you can't buy booster because lack of money, do you want charge some quilpens?";
			}
			break;
		case 1:
			if(GameManager.quillPen > GameManager.magnet_price)
			{
				itemTxt.text = "Do you want to buy magnet?";
				price = GameManager.magnet_price;

			}else{
				itemTxt.text ="you can't buy magnet because lack of money, do you want charge some quilpens?";
			}
			break;
		case 2:
			if(GameManager.quillPen > GameManager.shield_price)
			{
				itemTxt.text = "Do you want to buy booster?";
				price = GameManager.shield_price;

			}else{
				itemTxt.text ="you can't buy booster because lack of money, do you want charge some quilpens?";
			}
			break;
		case 3:
			if(GameManager.quillPen > GameManager.mysteryBox_price)
			{
				itemTxt.text = "Do you want to buy booster?";
				price = GameManager.mysteryBox_price;

			}else{
				itemTxt.text ="you can't buy booster because lack of money, do you want charge some quilpens?";
			}
			break;
		}
				

	}


	public void clickYes()
	{
		GameManager.quillPen = GameManager.quillPen - price;
	}

	public void clickClose()
	{
		buyItem_popup.SetActive (false);
	}



}
