using UnityEngine;
using System.Collections;

public class GameManger : MonoBehaviour {
	/*
	private static GameManger instance;
	private static GameObject container;  

	public static GameManger GetInstance()
	{
		if (!instance)  
		{  
			container = new GameObject();  
			container.name = "Logger";  
			instance = container.AddComponent(typeof(GameManger)) as GameManger;  
			Debug.Log("gamemanager");
		}  
		
		return instance;   
	}

*/
	public static int life = 5;
	public static int quilpens = 0;
	public static int puzzles = 0;


	void saveData()
	{
		PlayerPrefs.SetInt ("Life",life);
		PlayerPrefs.SetInt ("Quilpens",quilpens);
		PlayerPrefs.SetInt ("Puzzles",puzzles);
	}


	public void getData()
	{
		life = PlayerPrefs.GetInt ("Life");
		quilpens = PlayerPrefs.GetInt ("Quilpens");

	}

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
