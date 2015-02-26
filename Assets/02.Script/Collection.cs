using UnityEngine;
using System.Collections;

public class Collection : MonoBehaviour {

	public Sprite[] allImg;
	public bool all = true;
	public GameObject allBtn;

	void Start () {
	
	}
	
	void Update () {
	
	}


	public void exitBtn()
	{
	 	Debug.Log ("Exit");
	}

	public void allclicked()
	{
		if(all == true)
		{
			all = false;
			
		}else
		{
			all = true;

		}
	}
}
