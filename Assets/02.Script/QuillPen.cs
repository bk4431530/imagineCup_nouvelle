using UnityEngine;
using System.Collections;

public class QuillPen : MonoBehaviour {

	public enum QuillPenState
	{
		Normal,
		Magnetic
	}

	public GameObject magnet;
	public float speed = 1.0f;
	public float startTime;
	private float distance;

	public QuillPenState QS = QuillPenState.Normal;

	void Start()
	{
		startTime = Time.time;
		magnet = GameObject.Find ("player").transform.FindChild("magnet").gameObject;
	}
	
	void Update(){
		if(QS == QuillPenState.Magnetic)
		{
			transform.LookAt(magnet.transform.position); 
			transform.position = Vector2.Lerp(transform.position, magnet.transform.position, 0.04f); 

		}
	}
}
