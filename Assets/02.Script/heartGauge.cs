using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class heartGauge : MonoBehaviour {

	//heart gauge
	public RectTransform barTransform;
	
	private float cachedY;
	private float minXvalue;
	private float maxXvalue;
	
	private float currentHeart;
	

	public float per; //1~100
	public Image heartBar;
	


	private void handlebar()
	{

		float currentXvalue =(currentHeart/100) * (maxXvalue - minXvalue);
		
		barTransform.position = new Vector3 (currentXvalue,cachedY);
	}


	// Use this for initialization
	void Start () {
		//heart gauge
		cachedY = barTransform.position.y;
		maxXvalue = barTransform.position.x/2;
		minXvalue = barTransform.position.x - barTransform.rect.width;

					
	}
	
	// Update is called once per frame
	void Update () {

		if(currentHeart < per){
			currentHeart++; 
		}
		handlebar ();
	
	}
}
