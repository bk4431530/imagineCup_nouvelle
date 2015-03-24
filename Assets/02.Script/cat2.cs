using UnityEngine;
using System.Collections;


public class cat2 : MonoBehaviour{

	public GameObject player;

	public float player_pos;

	Animator catAnimator;


	// Use this for initialization
	void Start () {
		player = GameObject.Find ("player");
		catAnimator = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.x > player_pos) {
			catAnimator.SetTrigger("start");
			//this.GetComponent<catSprite2>().enabled = true;
		}
	}

}