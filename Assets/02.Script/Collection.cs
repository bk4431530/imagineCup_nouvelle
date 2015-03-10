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




	void OnEnable () {

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
		PlayerPrefs.SetString ("To",GameManager.To_name);
		PlayerPrefs.SetString ("Letter",GameManager.letter_txt);
		PlayerPrefs.SetString ("From",GameManager.From_name);
		PlayerPrefs.Save ();

		menuSelected = 3;
	} 


	//4.send
	public void sendBtn()
	{

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

	public void complete(){
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



		textview.SetActive (false);
	}


}
