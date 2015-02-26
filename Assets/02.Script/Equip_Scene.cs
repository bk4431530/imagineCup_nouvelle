using UnityEngine;
using System.Collections;

public class Equip_Scene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Fadeout () {
		float fadeTime = GameObject.Find ("Fading").GetComponent<Fading>().BeginFade(1);
		Invoke ("GoToGame", fadeTime);
	}

	public void StartClicked(){
		Debug.Log ("Start Button Clicked");
		Fadeout ();
	}

	void GoToGame(){
		switch (GameManager.currentEpisode) {
		case 1:
			Application.LoadLevel ("Monday");
			break;
		case 2:
			Application.LoadLevel ("Tuesday");
			break;
		case 3:
			Application.LoadLevel ("Wednesday");
			break;
		case 4:
			Application.LoadLevel ("Thursday");
			break;
		case 5:
			Application.LoadLevel ("Thursday");
			break;
		default:
			Debug.Log("selected Episode = null");
			break;
		}
	}
}
