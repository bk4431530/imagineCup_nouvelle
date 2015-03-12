using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Collection : MonoBehaviour {

	public int menuSelected =0;
	public GameObject[] menus = new GameObject[4];
	public GameObject[] buttons = new GameObject[4];
	public Sprite[] on_Img = new Sprite[4];
	public Sprite[] off_Img = new Sprite[4];

	public Image[] black_all = new Image[10];


	//1.All  
	public Sprite[] cardImg = new Sprite[10];
	int card_equip;

	//2.Detail
	Image postcard_preview;
	Image black_preview;

	Text card_NameTxt;
	Text card_contTxt;
	Text card_themeTxt;
	string[] cardName = new string[10];
	string[] cardCont = new string[10];



	//3.write
	Text to;
	Text letter;
	Text from;
	Image letterPreview;


	//4.send
	Text zipcodeR;
	Text zipcodeL;
	Text address;
	Text send_preview;



	//text view
	public GameObject textview;
	public Text inputTxt;
	public InputField inputF;
	bool input_isfocused;


	public GameObject equip_popUp;
	public Text popUp_txt;

	public GameObject equip;

	void Awake () { //원래 awake

		//2.detail
		postcard_preview = GameObject.Find ("letter_preview1").GetComponent<Image> ();
		card_NameTxt = GameObject.Find ("postcardTxt1").GetComponent<Text> ();
		card_themeTxt = GameObject.Find ("postcardTxt3").GetComponent<Text> ();
		card_contTxt =GameObject.Find ("postcardTxt2").GetComponent<Text> ();
		black_preview = GameObject.Find ("black_preview").GetComponent<Image> ();

		//equip_popUp = GameObject.Find ("Popup_postcardEquip");

		//3.write
		to = GameObject.Find ("to_txt").GetComponent<Text> ();
		letter = GameObject.Find ("letter_txt").GetComponent<Text> ();
		from = GameObject.Find ("from_txt").GetComponent<Text> ();
		letterPreview = GameObject.Find ("letter_preview2").GetComponent<Image> ();

		//4.send
		zipcodeR = GameObject.Find ("zipR_txt").GetComponent<Text> ();
		zipcodeL = GameObject.Find ("zipL_txt").GetComponent<Text> ();
		address = GameObject.Find ("addr_txt").GetComponent<Text> ();
		send_preview =GameObject.Find ("letterPre_txt").GetComponent<Text> ();


		textview.SetActive (false);
		equip_popUp.SetActive (false);

		GameManager.postCard [0] = 5;
		GameManager.postCard [1] = 3;
		GameManager.postCard [2] = 2;
		GameManager.postCard [3] = 1;
		GameManager.postCard [4] = 4;
		GameManager.postCard [5] = 1;
		GameManager.postCard [6] = 2;
		GameManager.postCard [7] = 4;
		GameManager.postCard [8] = 5;
		GameManager.postCard [9] = 2;




	}
	
	
	void Update()
	{
		equip.transform.position = black_all [GameManager.paperPlaneState].transform.position;

		for (int i =0; i<10; i++) 
		{
			black_all[i].fillAmount =1- (float)GameManager.postCard[i]*0.2f;
		}

		for (int i =0; i<4; i++) 
		{
			if(i != menuSelected){
				menus[i].SetActive(false);
				buttons[i].GetComponent<Image>().sprite = off_Img[i];
			}
			else
			{
				menus [menuSelected].SetActive (true);
				buttons[i].GetComponent<Image>().sprite = on_Img[i];
				
			}
		}//for



		to.text = GameManager.To_name;
		letter.text = GameManager.letter_txt;
		from.text = GameManager.From_name;



		zipcodeL.text = GameManager.ZipL;
		zipcodeR.text = GameManager.ZipR;
		address.text = GameManager.Addr;
		
		send_preview.text = GameManager.letter_txt;


		if (inputF.isFocused) {
			if(input_isfocused == false)
			{
				input_isfocused = true;
			}
		}
		
		if (input_isfocused == true) {
			if (inputF.isFocused == false){

				switch (inputMenu) 
				{
				case 1:
					GameManager.To_name = inputTxt.text;
					break;
				case 2:
					GameManager.letter_txt = inputTxt.text;
					break;
				case 3:
					GameManager.From_name = inputTxt.text;
					break;
				case 4:
					GameManager.ZipL = inputTxt.text;
					break;
				case 5:
					GameManager.ZipR = inputTxt.text;
					break;
				case 6:
					GameManager.Addr = inputTxt.text;
					break;
				}
				

				textview.SetActive(false);
				input_isfocused = false;
			}
		}


	}



	public void allClicked()
	{
		Debug.Log ("allclick");
		menuSelected=0;
	}

	public void detailClicked()
	{
		Debug.Log ("detail click");
		menuSelected=1;
	}
	
	public void writeClicked()
	{
		Debug.Log ("Write click");
		menuSelected=2;
	}

	public void sendClicked()
	{
		Debug.Log ("Send click");
		menuSelected=3;
	}
	

	public void exitBtn()
	{
		Debug.Log ("Exit");
	}



	//1.All
	public void letterClicked(int i)
	{
		black_preview.fillAmount =1 - GameManager.postCard [i] * 0.2f;
		Debug.Log ("perxent"+GameManager.postCard [i] * 0.2f);

		Debug.Log ("letter"+i+"clickes");
		postcard_preview.sprite = cardImg[i];
		letterPreview.sprite = cardImg [i];


		card_equip = i;

		switch (i) 
		{
		case 0:
			card_NameTxt.text ="Basic Pattern PostCard";
			card_themeTxt.text =" I fall in love when the first time I met you ";
			card_contTxt.text ="This is the basic card,you can play on the original game map";
			break;
		case 1:
			card_NameTxt.text ="Cat Pattern PostCard";
			card_themeTxt.text ="We can only learn to love by loving";
			card_contTxt.text ="If you choose this card, you can play on cat game map";
			break;
		case 2:
			card_NameTxt.text ="Flower Pattern PostCard";
			card_themeTxt.text ="Love is pressing a flower from bouqet he sent you";
			card_contTxt.text ="If you choose this card, you can watch blossom effect on game map";
			break;
		case 3:
			card_NameTxt.text ="Heart Pattern PostCard";
			card_themeTxt.text ="Love is all you need";
			card_contTxt.text ="If you choose this card, you can watch heart effect on game map";
			break;
		case 4:
			card_NameTxt.text ="Mist Pattern PostCard";
			card_themeTxt.text ="To love is to recieve glimpse of heaven";
			card_contTxt.text ="If you choose this card, you can watch Mist effect on game map";
			break;
		case 5:
			card_NameTxt.text ="Rain Pattern PostCard";
			card_themeTxt.text ="It's not how nuch we give,but how much we put into givig";
			card_contTxt.text ="If you choose this card, you can watch rain effect on game map";
			break;
		case 6:
			card_NameTxt.text ="Rainbow Pattern PostCard";
			card_themeTxt.text ="Everybody wants happiness nobody wants pain, but can have rainbow without the little pain";
			card_contTxt.text ="If you choose this card, you can watch rainbow effect on Paperplane";
			break;
		case 7:
			card_NameTxt.text ="Snowman Pattern PostCard";
			card_themeTxt.text ="Gravitaion can not be held responsible for people falling in love";
			card_contTxt.text ="If you choose this card, you can watch snow effect on game map";
			break;
		case 8:
			card_NameTxt.text ="Sunshine Pattern PostCard";
			card_themeTxt.text ="You are my sunshine, My only sunshine";
			card_contTxt.text ="If you choose this card,\n you can watch sunshine effect on game map";
			break;
		}
		menuSelected = 1;
	}

	//2.Detail
	public void EquipBtn()
	{
		if (GameManager.paperPlaneState != card_equip)
		{
			GameManager.paperPlaneState = card_equip;
		}
		Debug.Log ("equip " +card_equip.ToString()+"th letter");

		if (card_equip < 5) 
		{
			popUp_txt.text = "You have to complete this postcard.";
			equip_popUp.SetActive(true);
		}

	}

	public void PopupExit()
	{
		equip_popUp.SetActive(false);

	}

	public void WriteBtn()
	{
		menuSelected = 2;
	}

	//3.Write
	public void nextBtn()
	{
		PlayerPrefs.SetString ("To",GameManager.To_name);
		PlayerPrefs.SetString ("Letter",GameManager.letter_txt);
		PlayerPrefs.SetString ("From",GameManager.From_name);
		PlayerPrefs.Save ();

		menuSelected = 3;
	} 


	//4.send
	public void sendBtn()
	{
		popUp_txt.text = "Sending the letter is completed..!";
		equip_popUp.SetActive(true);

		PlayerPrefs.SetString ("ZipL",GameManager.ZipL);
		PlayerPrefs.SetString ("ZipR",GameManager.ZipR);
		PlayerPrefs.SetString ("Address",GameManager.Addr);
		PlayerPrefs.Save ();


		Debug.Log ("send click");

	}






	int inputMenu = 0;

	//textView
	public void inputClicked(string input){
		textview.SetActive (true);
		inputF.text = " "; 
		inputF.characterLimit = 0;
		//3.Write
		if (input == "to") 
		{
			inputMenu = 1;
		}
		else if(input == "letter")
		{
			inputMenu = 2;
		}
		else if(input == "from")
		{
			inputMenu = 3;
		}

		//4.send
		else if(input == "zipL")
		{
			inputMenu = 4;
			inputF.characterLimit =4;
		}else if(input == "zipR")
		{
			inputMenu = 5;
			inputF.characterLimit =4;

		}else if(input == "address")
		{
			inputMenu = 6;
		}

	}

	
}
