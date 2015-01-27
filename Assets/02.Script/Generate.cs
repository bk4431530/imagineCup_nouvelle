using UnityEngine;

public class Generate : MonoBehaviour
{
	public GameObject rocks;
	
	// Use this for initialization
	void Start()
	{
		InvokeRepeating("CreateObstacle", 1f, 1.5f);
	}
	
	void CreateObstacle()
	{
		Instantiate(rocks);
	}
}
