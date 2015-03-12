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

	//sound
	public static AudioSource SFX_quillpen;

	public QuillPenState QS = QuillPenState.Normal;

	void Start()
	{
		startTime = Time.time;
		magnet = GameObject.Find ("player").transform.FindChild("magnet").gameObject;
		hit = false;

		//sound
		
		SFX_quillpen = GameObject.Find ("/SFX/quillpen").GetComponent<AudioSource> ();
		SFX_quillpen.GetComponent<AudioSource> ().clip = (AudioClip)Resources.Load ("QuillpenGet");
		
		

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
			QuillpenSound();

			GameObject clone= (GameObject)Instantiate (particle, this.transform.position, this.transform.rotation);
			clone.AddComponent(typeof(DestroyMySelf));
			Destroy(this.gameObject,0.07f);
			Invoke("whenHit",0.06f);
		}

	}


	void whenHit()
	{
		GameManager.currentQuillPen++;
	}

	
	public void QuillpenSound()
	{
		if(GameManager.sfx)
		{
			SFX_quillpen.Play();
			Debug.Log(" QuillpenSound 함수실행");			
		}
		
	}

}
