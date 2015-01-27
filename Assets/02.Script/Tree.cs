using UnityEngine;
using System.Collections;

public enum TreeState
{
	Normal,
	Catch
}

public class Tree : MonoBehaviour {


	public TreeState treeState = TreeState.Normal;


	void OnCollisionEnter2D(Collision2D other)
	{
		Die();
	}
	
	void Die()
	{
		Application.LoadLevel(Application.loadedLevel);
	}



	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.name == "player")
		{
			treeState = TreeState.Catch;
		}
	}
}
