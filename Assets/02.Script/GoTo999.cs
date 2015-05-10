using UnityEngine;
using System.Collections;

public class GoTo999 : MonoBehaviour {

	private Vector3 startPosition;
	private Vector3 position999;
	private Vector3 playerPosition;

	bool inCam;

	Transform player;
	// Use this for initialization
	void Awake () {
		startPosition = this.transform.position;
		Debug.Log (this.gameObject.name + " : " + startPosition);
		position999 = new Vector3 (999,999,999);
		player = GameObject.Find ("player").transform;
		inCam = false;
	}

	void Start(){
		//this.transform.position = position999;
	}
	
	// Update is called once per frame
	void Update () {
		playerPosition = player.position;
		if (startPosition.x > playerPosition.x-30 && startPosition.x < playerPosition.x+30 && !inCam) {
			this.transform.position = startPosition;
			inCam = true;
			Debug.Log (this.gameObject.name + " in camera");
		} else if((startPosition.x < playerPosition.x-30 || startPosition.x > playerPosition.x+30) && inCam) {
			this.transform.position = position999;
			Debug.Log (this.gameObject.name + " out camera");
		}
	}
}
