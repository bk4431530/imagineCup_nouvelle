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

	string ZipCode;
	string Addr;



	void Start () {
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
