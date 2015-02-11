using UnityEngine;
using System.Collections;

public class Magnet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Collider2D[] hitColliders = Physics2D.OverlapCircleAll (transform.position, 2.0f);
		for(int i = 0; i < hitColliders.Length; i++)
		{
			if(hitColliders[i].gameObject.name == "Quilpen")
			{
				hitColliders[i].gameObject.GetComponent<QuillPen>().QS = QuillPen.QuillPenState.Magnetic;
				Debug.Log("On Magnetic on QuilPen");
			}
		}
	}
	
}
