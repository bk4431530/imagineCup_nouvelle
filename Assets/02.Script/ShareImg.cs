using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;

public class ShareImg : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	private bool isProcessing = false;

	public bool btnDown;

	 GameObject shareBtn;


	void Start(){
		shareBtn = GameObject.Find ("ShareBtn");
	}

	public void OnPointerDown (PointerEventData eventData){ 
		Debug.Log ("OnPointerDown");
		btnDown = true;
		shareBtn.GetComponent<Image> ().enabled = false;
	}
	
	public void OnPointerUp (PointerEventData eventData){

		Debug.Log ("OnPointerUp");
		btnDown = false;
		if (!isProcessing)
			StartCoroutine( ShareScreenshot() );
	}

	public IEnumerator ShareScreenshot()
	{
		isProcessing = true;

		// wait for graphics to render
		yield return new WaitForEndOfFrame();

		//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- PHOTO
		// create the texture
		Texture2D screenTexture = new Texture2D(Screen.width, Screen.height,TextureFormat.RGB24,true);
		
		// put buffer into texture
		screenTexture.ReadPixels(new Rect(0f, 0f, Screen.width, Screen.height),0,0);
		
		// apply
		screenTexture.Apply();
		//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- PHOTO
		
		byte[] dataToSave = screenTexture.EncodeToPNG();

		string destination = Path.Combine(Application.persistentDataPath,System.DateTime.Now.ToString("yyyy-MM-dd-HHmmss") + ".png");
				
		File.WriteAllBytes(destination, dataToSave);

		if(!Application.isEditor)
		{
			// block to open the file and share it ------------START
			AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
			AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
			intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
			AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
			AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse","file://" + destination);
			intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), uriObject);
			//intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), "testo");
			//intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), "SUBJECT");
			intentObject.Call<AndroidJavaObject>("setType", "image/jpeg");
			AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
			
			// option one WITHOUT chooser:
			currentActivity.Call("startActivity", intentObject);
			
			// option two WITH chooser:
			//AndroidJavaObject jChooser = intentClass.CallStatic<AndroidJavaObject>("createChooser", intentObject, "YO BRO! WANNA SHARE?");
			//currentActivity.Call("startActivity", jChooser);
			
			// block to open the file and share it ------------END
			
		}
		isProcessing = false;
		shareBtn.GetComponent<Image>().enabled = true;
	}
}
