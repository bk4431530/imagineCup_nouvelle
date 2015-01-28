using UnityEngine;
using System.Collections;

public class Generate_Bubble : MonoBehaviour {

	public GameObject bubbleR; 


	// Use this for initialization
	void Start () {

		InvokeRepeating ("CreateBubble", 1f, 1f);
		//bubble = GameObject.Find("bubble");
	}

	void Update()
	{
		/*if(this.transform.position.y > 8)
		{
			Destroy (this);
		} */


	}
	
	void CreateBubble()
	{
		//Instantiate (bubble, new Vector3(Random.Range (-8, 8), Random.Range (-2,0),-2), Quaternion.identity);

		GameObject bubble = Instantiate(bubbleR, new Vector3(Random.Range (12, 18), Random.Range (-7,-6),-2), Quaternion.identity) as GameObject;

	}
}
