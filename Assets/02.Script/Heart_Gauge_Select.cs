﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Heart_Gauge_Select : MonoBehaviour {
	
	//heart gauge

	public GameObject gauge;

	string this_Ep;

	public float HeartPer;//0~1
	
	
	// Use this for initialization
	void Start () {
		//heart gauge
		this_Ep = this.gameObject.name.ToString();
		//for Test
		HeartPer = (float)(GameManager.heart_ep1)*0.03f;

		//Debug.Log("heart_ep" + this_Ep + " : " + HeartPer);
	}
	
	// Update is called once per frame
	void Update () {
		gauge.GetComponent<Image> ().fillAmount = HeartPer;
	}
}
