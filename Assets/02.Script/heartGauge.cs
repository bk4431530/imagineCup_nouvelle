using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class heartGauge : MonoBehaviour {

	//heart gauge
	public RectTransform barTransform;
	
	public float cachedY;
	public float maxXvalue;
	
	public float HeartPer;//0~1
	public float currentXvalue;
	public Image heartBar;




	// Use this for initialization
	void Start () {
		//heart gauge
		cachedY = barTransform.position.y;
		maxXvalue = barTransform.position.x;

					
	}
	
	// Update is called once per frame
	void Update () {
		currentXvalue = maxXvalue*HeartPer;
		barTransform.position = new Vector3 (currentXvalue,cachedY);
	}
}
