using UnityEngine;
using System.Collections;

public enum CatState
{
	Normal,
	Catch
}

public class cat1 : MonoBehaviour {

	public CatState catState = CatState.Normal; //cat state default

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("충돌한 비행기 콜라이더 이름 : " + other.collider2D.name);
		if(other.gameObject.name == "player")
		{
			catState = CatState.Catch;
			
		}
	}


}
