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
	private float startTime;
	private float distance;

	public QuillPenState QS = QuillPenState.Normal;

	void Start(){
		startTime = Time.time;
		magnet = GameObject.Find ("magnet");
	}
	
	void Update(){
		if(QS == QuillPenState.Magnetic)
		{
			float distCovered = (Time.time - startTime) * speed;
			distance = Vector2.Distance(transform.position, magnet.transform.position);
			float fracJourney = distCovered / distance;// 속력 / 길이 = m/s / m = 1/s 시간 fracJourney = 0.1f

			transform.LookAt(magnet.transform.position); 
			transform.position = Vector2.Lerp(transform.position, magnet.transform.position, Time.deltaTime*fracJourney); 
		}
	}
}
