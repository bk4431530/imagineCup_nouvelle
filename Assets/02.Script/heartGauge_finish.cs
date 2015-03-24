using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class heartGauge_finish : MonoBehaviour {
	
	public GameObject gauge;
	public static float current_Score=0;

	public GameObject gaugeTxt;
	
	public float HeartPer;//0~1
	public float heart;
	
	// Use this for initialization
	void Start () {
		//for Test
		//heart = PlayerPrefs.GetInt ("Heart_ep1");
		current_Score = (GameManager.currentQuillPen/100) + (GameManager.currentLife*2);
		Debug.Log (current_Score);
		
		GameManager.heart_ep1 = GameManager.heart_ep1 + (int)current_Score;
		HeartPer = (float)(GameManager.heart_ep1)*0.03f;
		PlayerPrefs.SetInt ("Heart_ep1",GameManager.heart_ep1);
		PlayerPrefs.Save ();
		/*
		if(GameManager.heart_ep1 <= 20){ 
			gaugeTxt.GetComponent<Text>().text = "try again"; 
		}else if(GameManager.heart_ep1 >20 && GameManager.heart_ep1 <=40){ 
			gaugeTxt.GetComponent<Text>().text = "try hard"; 
		}else if(GameManager.heart_ep1 >40 && GameManager.heart_ep1 <=60){ 
			gaugeTxt.GetComponent<Text>().text = "nice"; 
		}else if(GameManager.heart_ep1 >60 && GameManager.heart_ep1 <=80){ 
			gaugeTxt.GetComponent<Text>().text = "good job"; 
		}else if(GameManager.heart_ep1 >80){ 
			gaugeTxt.GetComponent<Text>().text = "perfect !"; 
		} */

		heart = GameManager.heart_ep1 * 3;
		
		if(heart <= 20){ 
			gaugeTxt.GetComponent<Text>().text = "try again"; 
		}else if(heart >20 && heart <=40){ 
			gaugeTxt.GetComponent<Text>().text = "try hard"; 
		}else if(heart >40 && heart <=60){ 
			gaugeTxt.GetComponent<Text>().text = "nice"; 
		}else if(heart >60 && heart <=80){ 
			gaugeTxt.GetComponent<Text>().text = "good job"; 
		}else if(heart >80){ 
			gaugeTxt.GetComponent<Text>().text = "perfect !"; 
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		gauge.GetComponent<Image> ().fillAmount = HeartPer;

		


	}
}
