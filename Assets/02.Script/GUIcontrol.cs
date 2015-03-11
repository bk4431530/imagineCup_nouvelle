using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIcontrol : MonoBehaviour {
	
	Text pens;
	Text posts;
	
	GameObject life1;
	GameObject life2;
	GameObject life3;
	GameObject life4;
	GameObject life5;

	 GameObject booster;
	 GameObject magnet;
	 GameObject sheild;
	 GameObject mysterybox;
	



	void Start()
	{

		pens = GameObject.Find ("quilpenQty").GetComponent<Text> ();
		posts = GameObject.Find ("postcardQty").GetComponent<Text> ();

		
		booster = GameObject.Find("booster");
		magnet = GameObject.Find("magnet");
		sheild = GameObject.Find("sheild");
		mysterybox = GameObject.Find("mysterybox");
		
		
		life1 = GameObject.Find ("play_life1");
		life2 = GameObject.Find ("play_life2");
		life3 = GameObject.Find ("play_life3");
		life4 = GameObject.Find ("play_life4");
		life5 = GameObject.Find ("play_life5");


		booster.SetActive (false);
		magnet.SetActive (false);
		sheild.SetActive (false);
		mysterybox.SetActive (false);


	}
	

	
	
	
	
	
	void Update () {


		
		if (PlayerControl.MultipleFeather) 
		{
			pens.text = (GameManager.currentQuillPen*2).ToString();
			pens.color= Color.red;
		}else{
			pens.text = (GameManager.currentQuillPen).ToString();
		}
		
		
		posts.text = (GameManager.currentPiece).ToString();
		
		
		
		if (GameManager.currentLife == 4) {
			life1.SetActive(false);
		}else if(GameManager.currentLife == 3){
			life2.SetActive(false);
		}else if(GameManager.currentLife == 2){
			life3.SetActive(false);
		}else if(GameManager.currentLife == 1){
			life4.SetActive(false);
		}else if(GameManager.currentLife == 0){
			life5.SetActive(false);
		}

	
		if (GameManager.booster_equip) {
			booster.SetActive(true);
		}else if(GameManager.magnet_equip){
			magnet.SetActive(true);
		}else if(GameManager.shield_equip){
			sheild.SetActive(true);
		}else if(GameManager.mysteryBox > 0){
			mysterybox.SetActive(true);
		}


		
		
		
	}


	
	
}//class
