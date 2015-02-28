using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Collection : MonoBehaviour {

	public Sprite[] allImg;
	public bool all;
	public GameObject allBtn;
	public GameObject allMenu;

	public Sprite[] detailImg;
	public bool detail;
	public GameObject detailBtn;
	public GameObject detailMenu;


	public int menuSelected;

	void Start () {
		all = false;
		detail = false;
	}
	
	void Update () {
		allMenu.SetActive(all);
		detailMenu.SetActive(detail);

	}


	public void exitBtn()
	{
	 	Debug.Log ("Exit");
	}

	public void allclicked()
	{
		Debug.Log ("allclick");

		if(all == true)
		{
			Debug.Log("all off");
			allBtn.GetComponent<Image>().sprite = allImg[0];
			all = false;
			
		}else if(all == false)
		{
			Debug.Log("all on");
			allBtn.GetComponent<Image>().sprite = allImg[1];
			all = true;
		}
	}



	public void detailclicked()
	{
		Debug.Log ("detail click");
		
		if(detail == true)
		{
			Debug.Log("detail off");
			detailBtn.GetComponent<Image>().sprite = detailImg[0];
			detail = false;
			
		}else if(all == false)
		{
			Debug.Log("detail on");
			detailBtn.GetComponent<Image>().sprite = detailImg[1];
			detail = true;
		}
	}

}
