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
	public GameObject particle;
	private float distance;
	bool hit;

	public QuillPenState QS = QuillPenState.Normal;

	void Start()
	{
		startTime = Time.time;
		magnet = GameObject.Find ("player").transform.FindChild("magnet").gameObject;
		hit = false;
	}
	
	void Update(){
		if(QS == QuillPenState.Magnetic)
		{
			transform.LookAt(magnet.transform.position); 
			transform.position = Vector2.Lerp(transform.position, magnet.transform.position, 0.07f);
			Destroy(this.gameObject,0.07f);
			Invoke("whenHit",0.06f);
		}

	}


	void OnTriggerEnter2D(Collider2D other)
	{

		if (QS == QuillPenState.Normal && other.gameObject.name == "player") 
		{
			Destroy(this.gameObject,0.07f);
			Invoke("whenHit",0.06f);
		}

	}


	void whenHit()
	{
		GameManager.quillPen++;
		Instantiate (particle, this.transform.position, this.transform.rotation);

	}


}
