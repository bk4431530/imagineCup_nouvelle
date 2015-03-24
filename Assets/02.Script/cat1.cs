using UnityEngine;
using System.Collections;


public class cat1 : MonoBehaviour{

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
		if (pTransform.position.x > player_pos) {
			catAnimator.SetTrigger("start");
			//this.GetComponent<catSprite1>().enabled = true;
		}

		if (pTransform.position.x > myTransform.position.x+5) {
			player.GetComponent<CatchedbyCat1>().enabled = false;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.collider2D.name == "player")
		{
			//this.GetComponent<Animator>().enabled = true;
			//catState = CatState.Catch;
			
		}
	}

}