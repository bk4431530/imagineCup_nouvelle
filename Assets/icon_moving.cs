using UnityEngine;
using System.Collections;

public class icon_moving : MonoBehaviour {




	void Start () {

		iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath ("icon_path"),
		                                        //"orienttopath", true, 
		                                        //"axis","x",

		                                        "time", 20,
		                                        "easetype",iTween.EaseType.linear,
		                                        "looptype",iTween.LoopType.loop));

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
