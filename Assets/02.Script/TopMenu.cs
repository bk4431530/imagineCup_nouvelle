using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TopMenu : MonoBehaviour {

	Text quillPenBar;
	Text stampBar;

	public GameObject quill_popup;
	public GameObject stamp_popup;
	public GameObject collection_popup;
	public GameObject setting_popup;


	public string curPopUp;



	// Use this for initialization
	void Start () {
		quillPenBar = GameObject.Find ("Quill_Bar").transform.FindChild("Text").GetComponent<Text>();
		stampBar = GameObject.Find ("Stamp_Bar").transform.FindChild("Text").GetComponent<Text>();

		quill_popup = GameObject.Find ("Popup_Quill");
		stamp_popup = GameObject.Find ("Popup_Stamp");
		collection_popup = GameObject.Find ("Popup_Collection");
		setting_popup = GameObject.Find ("Popup_Setting");
		quill_popup.SetActive (false);
		stamp_popup.SetActive (false);
		collection_popup.SetActive (false);
		setting_popup.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		quillPenBar.text = GameManager.quillPen.ToString();
		stampBar.text = GameManager.stamp.ToString ();
	}

	public void Fadeout () {
		float fadeTime = GameObject.Find ("Fading").GetComponent<Fading>().BeginFade(1);
		Invoke ("GoToHome", fadeTime);
	}

	public void ClickedCollection(){
		Debug.Log ("Collection Button Clicked");
		collection_popup.SetActive (true);
		curPopUp = "Popup_Collection";
	}
	
	public void ClickedSetting(){
		Debug.Log ("Setting Button Clicked");
		setting_popup.SetActive (true);
		curPopUp = "Popup_Setting";
	}

	public void ClickedHome(){
		Debug.Log ("Home Button Clicked");
		Application.LoadLevel ("Select_Scene");
		Fadeout ();
	}

	public void ClickedQuillPenBar(){
		Debug.Log ("QuillPenBar Clicked");
		quill_popup.SetActive (true);
		curPopUp = "Popup_Quill";
	}
	
	public void ClickedStampBar(){
		Debug.Log ("StampBar Clicked");
		stamp_popup.SetActive (true);
		curPopUp = "Popup_Stamp";
	}

	public void ClickedClose(){
		Debug.Log ("Popup Close Button Clicked");
		string pop = curPopUp.Substring (0,curPopUp.Length);
		Debug.Log ("pop = " + pop);
		GameObject.Find (pop).SetActive (false);
	}





	void GoToHome(){
		Application.LoadLevel ("Select_Scene");
	}
}
