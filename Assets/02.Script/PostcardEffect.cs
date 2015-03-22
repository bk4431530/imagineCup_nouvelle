using UnityEngine;
using System.Collections;

public class PostcardEffect : MonoBehaviour {
	
	public static Behaviour flareLayer;
	public static GameObject trailRenderer;
	
	// Use this for initialization
	void Start () {
		flareLayer = (Behaviour)Camera.main.GetComponent("FlareLayer");
		flareLayer.enabled = false;

		trailRenderer = GameObject.Find ("trailReenderer");
		trailRenderer.SetActive (false);
		
		//for test
		//GameManager.paperPlaneState = 8;

		for(int i =0; i<3; i++){
			switch(GameManager.paperPlaneState[i]){
			case 0 : //basic
				break;
			case 1 :
				break;
			case 2 :
				break;
			case 3 :
				break;
			case 4 :
				break;
			case 5 :
				break;
			case 6 :
				trailRenderer.SetActive (true);
				break;
			case 7 :
				break;
			case 8 : //morning
				flareLayer.enabled = true;
				break;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}