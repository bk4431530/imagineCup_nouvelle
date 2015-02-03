using UnityEngine;
using System.Collections;

public class StartGUI : MonoBehaviour {

	private int loadProgress=0;
	private string levelToRoad= "scene1";
	public GameObject loadingText; 

	
	public GUISkin button;
	
	void OnGUI(){
		
		GUI.skin = button;
		
		if(GUI.Button(new Rect(0, 0,Screen.width, Screen.height), " ")){
			StartCoroutine(DisplayLoadingScreen(levelToRoad));
		}//if
		
	}//gui
	
	
	
	IEnumerator DisplayLoadingScreen(string level){
		
		AsyncOperation async = Application.LoadLevelAsync (level);
		
		loadingText.guiText.text = "Loading Progress" + loadProgress + "%";
		
		while (! async.isDone) 
		{
			loadProgress = (int)(async.progress*100);//(0~1)
			
			loadingText.guiText.text = "Loading Progress" + loadProgress + "%";
			
			yield return null;
		}
		
		
	}//

}
