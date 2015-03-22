using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class heartGauge_finish : MonoBehaviour {
	
	public GameObject gauge;
	public static float current_Score=0;

	public GameObject gaugeTxt;
	
	public float HeartPer;//0~1
	int heart;
	
	// Use this for initialization
	void Start () {
		//for Test
		//heart = PlayerPrefs.GetInt ("Heart_ep1");
		current_Score = (GameManager.currentQuillPen/100) + (GameManager.currentLife*2);
		Debug.Log (current_Score);
		
		GameManager.heart_ep1 = GameManager.heart_ep1 + (int)current_Score;
		HeartPer = (float)(GameManager.heart_ep1)*0.01f;
		PlayerPrefs.SetInt ("Heart_ep1",GameManager.heart_ep1);
		PlayerPrefs.Save ();
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
		gauge.GetComponent<Image> ().fillAmount = HeartPer;
	}
}
