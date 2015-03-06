using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Select_Scene : MonoBehaviour {
	
	public int selectedEp;
	
	public GameObject locks;

	public GameObject exit_popup;
	public GameObject openEp_popup;
	public GameObject caution_popup;

	Text guide_text;

	// Use this for initialization
	void Start () {
		guide_text = GameObject.Find ("Guide").GetComponent<Text>();
		locks = GameObject.Find ("Lock");

		exit_popup = GameObject.Find ("Popup_Exit");
		openEp_popup = GameObject.Find ("Popup_OpenEp");
		caution_popup = GameObject.Find ("Popup_Caution");
		exit_popup.SetActive (false);
		openEp_popup.SetActive (false);
		caution_popup.SetActive (false);

		for(int i = 1; i <= GameManager.episode; i++)
		{
			string ep = i.ToString();
			locks.transform.FindChild(ep).gameObject.SetActive(false);
		}

		switch (GameManager.episode) {
		case 0:
			guide_text.text = "Please watch the story 'Fall in love' to start the game.";
			break;
		case 1:
			guide_text.text = "Clear the episode 'Monday' to unlock 'Tuesday'.";
			break;
		case 2:
			guide_text.text = "Clear the episode 'Tuesday' to unlock 'Wednesday'.";
			break;
		case 3:
			break;
		case 4:
			break;
		case 5:
			break;
		case 6:
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)){
			openEp_popup.SetActive (false);
			caution_popup.SetActive (false);
			exit_popup.SetActive (true);
		}
	}
	
	void Fadeout () {
		float fadeTime = GameObject.Find ("Fading").GetComponent<Fading>().BeginFade(1);

		if (GameManager.currentEpisode > 0 && GameManager.currentEpisode < 6) 
		{
			Invoke ("GoToEquip", fadeTime);
		} else if (GameManager.currentEpisode == 0){
			Invoke ("GoToIntro", fadeTime);
		} else if (GameManager.currentEpisode == 6){
			Invoke ("GoToEnding", fadeTime);
		}
	}

	//episode_select
	public void ClickedIntro(){
		Debug.Log ("Intro Selected");

		GameManager.currentEpisode = 0;
		Fadeout ();
	}

	public void ClickedMonday(){
		Debug.Log ("Monday Selected");
		if (GameManager.episode > 0) 
		{
			GameManager.currentEpisode = 1;
			Fadeout ();
		} else {
			Debug.Log ("Monday is locked");
		}
	}

	public void ClickedTuesday(){
		Debug.Log ("Tuesday Selected");
		if (GameManager.episode > 1) 
		{
			GameManager.currentEpisode = 2;
			Fadeout ();
		} else {
			Debug.Log ("Tuesday is locked");
			if(GameManager.episode == 1)
			{
				selectedEp = 2;
				GameObject.Find ("Ep2").transform.FindChild("Back").gameObject.SetActive(true);
			}
		}
	}


	void GoToEquip(){
		Debug.Log("Go to Equop_Scene");
		Application.LoadLevel ("Equip_Scene");
	}

	void GoToIntro(){
		GameObject.Find ("Fading").GetComponent<Fading> ().BeginFade (-1);
		if (GameManager.episode == 0) {
			GameManager.episode = 1;
			PlayerPrefs.SetInt ("Episode",GameManager.episode);
			PlayerPrefs.Save();

			Debug.Log("Episode = " + GameManager.episode);
		}
		Application.LoadLevel ("Intro");
	}

	void GoToEnding(){
		//Application.LoadLevel ("Ending_Scene");
	}

	public void ClickedNo(){
		Debug.Log ("No button is clicked");
		string currentEp = "Ep" + selectedEp.ToString ();
		GameObject.Find (currentEp).transform.FindChild("Back").gameObject.SetActive (false);
	}

	public void ClickedYes(){
		Debug.Log ("Yes button is clicked");
		openEp_popup.SetActive (true);
	}

	public void ClickedExitYes(){
		Debug.Log ("ExitYes button is clicked");
		Application.Quit(); 
	}

	public void ClickedExitNo(){
		Debug.Log ("ExitNo button is clicked");
		exit_popup.SetActive (false);
	}

	public void ClickedOpenYes(){
		Debug.Log ("OpenYes button is clicked");
		if (GameManager.stamp >= GameManager.openEp_price) {
			GameManager.stamp = GameManager.stamp-GameManager.openEp_price;
			PlayerPrefs.SetInt("Stamp",GameManager.stamp);
			GameManager.episode = selectedEp;
			PlayerPrefs.SetInt ("Episode",GameManager.episode);
			PlayerPrefs.Save();

			Debug.Log("Stamp = " + GameManager.stamp);
			Debug.Log("Episode = " + GameManager.episode);

			openEp_popup.SetActive (false);

			string ep = selectedEp.ToString();
			locks.transform.FindChild(ep).gameObject.SetActive(false);
		} else {
			openEp_popup.SetActive (false);
			caution_popup.SetActive (true);
			Debug.Log("You don't have enough stamps to open the Episode!!");
		}
	}
	
	public void ClickedOpenNo(){
		Debug.Log ("OpenNo button is clicked");
		openEp_popup.SetActive (false);
		string currentEp = "Ep" + selectedEp.ToString ();
		GameObject.Find (currentEp).transform.FindChild("Back").gameObject.SetActive (false);
	}



	public void ClickedCautionOk(){
		Debug.Log ("CautionOk button is clicked");
		string currentEp = "Ep" + selectedEp.ToString ();
		GameObject.Find (currentEp).transform.FindChild("Back").gameObject.SetActive (false);
		caution_popup.SetActive (false);
	}
}
