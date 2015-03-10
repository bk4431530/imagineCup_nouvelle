using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Collection : MonoBehaviour {

	public int menuSelected =0;
	public GameObject[] menus = new GameObject[4];
	public GameObject[] buttons = new GameObject[4];
	public Sprite[] on_Img = new Sprite[4];
	public Sprite[] off_Img = new Sprite[4];
	


	int letter_equip;


	//3.write
	Text to;
	Text letter;
	Text from;

	string To_name;
	string letter_txt;
	string From_name;

	//4.send
	Text zipcodeR;
	Text zipcodeL;
	Text address;
	Text send_preview;

	string ZipL;
	string ZipR;
	string Addr;

	//text view
	public GameObject textview;
	public Text inputTxt;
	public InputField inputF;




	void OnEnable () {
		/*
		menus [0] = GameObject.Find ("1.All");
		menus [1] = GameObject.Find ("2.Detail");
		menus [2] = GameObject.Find ("3.Write");
		menus [3] = GameObject.Find ("4.Send");

		buttons [0] = GameObject.Find ("AllBtn");
		buttons [1] = GameObject.Find ("DetailBtn");
		buttons [2] = GameObject.Find ("writeBtn");
		buttons [3] = GameObject.Find ("sendBtn");
		*/
		//3.write
		to = GameObject.Find ("to_txt").GetComponent<Text> ();
		letter = GameObject.Find ("letter_txt").GetComponent<Text> ();
		from = GameObject.Find ("from_txt").GetComponent<Text> ();

		//4.send
		zipcodeR = GameObject.Find ("zipR_txt").GetComponent<Text> ();
		zipcodeL = GameObject.Find ("zipL_txt").GetComponent<Text> ();
		address = GameObject.Find ("addr_txt").GetComponent<Text> ();
		send_preview =GameObject.Find ("letterPre_txt").GetComponent<Text> ();


		textview.SetActive (false);



	}
	
	
	void Update()
	{

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


		/*Write
		To_name = to.text;
		letter_txt = letter.text;
		From_name = from.text;
		*/
		to.text = To_name;
		letter.text = letter_txt;
		from.text = From_name;


		/*Send
		ZipCode = zipcodeL.text + zipcodeR.text;
		Addr = address.text;
		*/
		zipcodeL.text = ZipL;
		zipcodeR.text = ZipR;
		address.text = Addr;
		
		send_preview.text = letter_txt;
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
		letter_equip = i;
		menuSelected = 1;
	}

	//2.Detail
	public void EquipBtn()
	{
		Debug.Log ("equip " +letter_equip.ToString()+"th letter");
	}

	public void WriteBtn()
	{
		menuSelected = 2;
	}

	//3.Write
	public void nextBtn()
	{
		PlayerPrefs.SetString ("To"," ");
		PlayerPrefs.SetString ("Letter"," ");
		PlayerPrefs.SetString ("From"," ");
		PlayerPrefs.Save ();

		menuSelected = 3;
	} 


	//4.send
	public void sendBtn()
	{
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

	public void complete(){
		switch (inputMenu) 
		{
		case 1:
			To_name = inputTxt.text;
			break;
		case 2:
			letter_txt = inputTxt.text;
			break;
		case 3:
			From_name = inputTxt.text;
			break;
		case 4:
			ZipL = inputTxt.text;
			break;
		case 5:
			ZipR = inputTxt.text;
			break;
		case 6:
			Addr = inputTxt.text;
			break;
		}



		textview.SetActive (false);
	}


}
