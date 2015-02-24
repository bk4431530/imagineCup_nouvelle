using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Loading_Scene : MonoBehaviour {

	GameObject thiscanvas;

	private bool started = false;

	// Use this for initialization
	void Start () {

		thiscanvas = GameObject.Find ("Canvas");

		if (PlayerPrefs.HasKey("Quilpen")) 
		{
			GameManager.getData();
		}
		else
		{
			GameManager.saveData();
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (Application.GetStreamProgressForLevel ("Select_Scene") == 1 && !started) {
			Invoke ("GoToStart", 1.0f);
			started = true;
		} else if (Application.GetStreamProgressForLevel ("Select_Scene") < 1 && !started) {
			Debug.Log ("Loading " + (Application.GetStreamProgressForLevel ("Select_Scene"))*100 + "%");
		}

	}

	void GoToStart(){
		thiscanvas.transform.FindChild ("Loading").gameObject.SetActive (false);
		thiscanvas.transform.FindChild ("Start").gameObject.SetActive (true);
		thiscanvas.GetComponent<Button> ().enabled = true;
	}

	public void Fadeout () {
		float fadeTime = GameObject.Find ("Fading").GetComponent<Fading>().BeginFade(1);
		Invoke ("GoToSelect", fadeTime);
	}

	void GoToSelect(){
		Application.LoadLevel ("Select_Scene");
	}
}
