using UnityEngine;
using System.Collections;

public class BGN : MonoBehaviour {

	public AudioClip[] SoundClips = new AudioClip[2];

	void Awake(){
		DontDestroyOnLoad(gameObject);
		this.gameObject.GetComponent<AudioSource> ().clip = SoundClips [0];
		//This is played every time the script is called.
	}


	void Update(){
	}
}
