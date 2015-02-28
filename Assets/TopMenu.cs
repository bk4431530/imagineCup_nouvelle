using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TopMenu : MonoBehaviour {

	Text quillPenBar;
	Text stampBar;

	// Use this for initialization
	void Start () {
		quillPenBar = GameObject.Find ("Quill_Bar").transform.FindChild("Text").GetComponent<Text>();
		stampBar = GameObject.Find ("Stamp_Bar").transform.FindChild("Text").GetComponent<Text>();
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
	}
	
	public void ClickedSetting(){
		Debug.Log ("Setting Button Clicked");
	}

	public void ClickedHome(){
		Debug.Log ("Home Button Clicked");
		Fadeout ();
	}

	public void ClickedQuillPenBar(){
		Debug.Log ("QuillPenBar Clicked");
	}
	
	public void ClickedStampBar(){
		Debug.Log ("StampBar Clicked");
		
	}

	void GoToHome(){
		Application.LoadLevel ("Select_Scene");
	}
}
