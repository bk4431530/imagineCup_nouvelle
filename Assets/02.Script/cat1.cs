using UnityEngine;
using System.Collections;


public class cat1 : CatchedbyCat {

	public CatState catState = CatState.Normal; //cat state default


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(clickCount == 3)
		{
			catState = CatState.Normal;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("고양이는 비행기 콜라이더를 감지함 : " + other.collider2D.name);
		if(other.collider2D.name == "player")
		{
			catState = CatState.Catch;
			
		}



	}


}
