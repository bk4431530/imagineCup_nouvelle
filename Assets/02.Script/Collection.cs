using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Collection : MonoBehaviour {

	public int menuSelected;
	public GameObject[] menus;
	public GameObject[] buttons;
	public Sprite[] on_Img;
	public Sprite[] off_Img;

 	

	int letter_equip;


	//3.write
	public Text to;
	public Text letter;
	public Text from;

	string To_name;
	string letter_txt;
	string From_name;

	//4.send
	public Text zipcodeR;
	public Text zipcodeL;
	public Text address;
	public Text send_preview;

	string ZipCode;
	string Addr;

	void Start () {
		menuSelected = 0;

		menus [menuSelected].SetActive (true);

		
		

		

		



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


		//Write
		To_name = to.text;
		letter_txt = letter.text;
		From_name = from.text;

		//Send
		ZipCode = zipcodeL.text + zipcodeR.text;
		Addr = address.text;
		
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




}
