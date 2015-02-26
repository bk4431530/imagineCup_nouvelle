using UnityEngine;
using System.Collections;

public class Select_Scene : MonoBehaviour {
	
	public int selectedEp;

	public GameObject texts;
	public GameObject locks;

	// Use this for initialization
	void Start () {
		texts = GameObject.Find ("Text");
		locks = GameObject.Find ("Lock");
	}
	
	// Update is called once per frame
	void Update () {
		
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

	//top_menu
	public void ClickedCollection(){
		Debug.Log ("Collection Button Clicked");
	}
	
	public void ClickedSetting(){
		Debug.Log ("Setting Button Clicked");
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
			Debug.Log("Episode = " + GameManager.episode);
			texts.transform.FindChild("1").gameObject.SetActive(false);
			locks.transform.FindChild("1").gameObject.SetActive(false);
		}
		//Application.LoadLevel ("Intro_Scene");
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
	}
}
