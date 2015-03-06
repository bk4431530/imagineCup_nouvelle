using UnityEngine;
using System.Collections;

public class icon_moving : MonoBehaviour {

	// Use this for initialization
	void Start () {
		iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath ("icon_path"), "orienttopath", true, "time", 50));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
