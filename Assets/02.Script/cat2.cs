using UnityEngine;
using System.Collections;


public class cat2 : MonoBehaviour{

	public GameObject player;

	public float player_pos;

	Animator catAnimator;

	public new Transform myTransform;
	public new Transform pTransform;


	// Use this for initialization
	void Start () {
		myTransform = transform;
		player = GameObject.Find ("player");
		pTransform = player.transform;
		catAnimator = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.x > player_pos) {
			catAnimator.SetTrigger("start");
			//this.GetComponent<catSprite2>().enabled = true;
		}

		if (pTransform.position.x > myTransform.position.x+5) {
			player.GetComponent<CatchedbyCat2>().enabled = false;
		}
	}

}