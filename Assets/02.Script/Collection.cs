﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Collection : MonoBehaviour {

	public int menuSelected;
	public GameObject[] menus;
	public GameObject[] buttons;
	public Sprite[] on_Img;
	public Sprite[] off_Img;

 	public Text to;
	public Text letter;
	public Text from;




	//3.write
	string To_name;
	string letter_txt;
	string From_name;

	//4.send
	string zipCode;
	string Addr;

	void Start () {
		menuSelected = 0;
	}
	
	void Update () {

		menus [menuSelected].SetActive (true);

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



		To_name = to.text;
		Debug.Log (To_name);
		letter_txt = letter.text;
		From_name = from.text;




	}










	public void allclicked()
	{
		Debug.Log ("allclick");
		menuSelected=0;
	}



	public void detailclicked()
	{
		Debug.Log ("detail click");
		menuSelected=1;
	}


	public void Writeclicked()
	{
		Debug.Log ("Write click");
		menuSelected=2;
	}

	public void Sendclicked()
	{
		Debug.Log ("Send click");
		menuSelected=3;
	}







	public void exitBtn()
	{
		Debug.Log ("Exit");
	}







}
