using UnityEngine;
using System.Collections;

public class SmoothCamera2D : MonoBehaviour {
	
	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	Transform target;

	//shake
	public float shake = 0f;
	public float shakeAmount = 0.7f;
	public float decreaseFactor = 1.0f;
	Vector3 originalPos;


	void Start()
	{
		target = GameObject.Find ("player").transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (target)
		{
			Vector3 point = camera.WorldToViewportPoint(target.position);
			Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(0.2f, point.y, point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}
	

		//shake
		originalPos = transform.localPosition;
		
		if (shake > 0)
		{
			transform.localPosition = new Vector3( originalPos.x + Random.insideUnitSphere.x * shakeAmount,originalPos.y,originalPos.z);
			
			shake -= Time.deltaTime * decreaseFactor;
		}
		else
		{
			shake = 0f;
			transform.localPosition = originalPos;
		}

		
	}
}
