using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Loading_Scene : MonoBehaviour {

	GameObject thiscanvas;
	//Text percentage;

	private bool started = false;
	float percent;

	// Use this for initialization
	void Start () {

		thiscanvas = GameObject.Find ("Canvas");

		//percentage = GameObject.Find ("Percent").GetComponent<Text> ();

		if (PlayerPrefs.HasKey("Quilpen")) 
		{
			GameManager.getData();
		}
		else
		{
			GameManager.initData();
		}

	}
	
	// Update is called once per frame
	void Update () {
		percent = Application.GetStreamProgressForLevel ("Select_Scene")*100;
		//percentage.text = "{" + percent + "%)";

		if (Application.GetStreamProgressForLevel ("Select_Scene") == 1 && !started) {
			Invoke ("GoToStart", 2.0f);
			started = true;
		} else if (Application.GetStreamProgressForLevel ("Select_Scene") < 1 && !started) {
			Debug.Log ("Loading " + percent + "%");
		}

	}

	void GoToStart(){
		thiscanvas.transform.FindChild ("Loading").gameObject.SetActive (false);
		//thiscanvas.transform.FindChild ("Percent").gameObject.SetActive (false);
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
