using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class catSprite : MonoBehaviour {
	
	// Array of images for the snake's animation.
	// This is loaded in the Inspector.
	public Sprite[] catImages;
	
	// Dictionary containing an integer frame (sprite) index
	// and the associated polygon collider.
	private Dictionary<int, PolygonCollider2D> olFrameColliders;
	
	// tracks the current frame
	private int curFrame;
	
	// tracks the previous frame
	private int oldFrame;
	
	// a reference to this game object's Sprite Renderer
	private SpriteRenderer oSpriteRenderer;
	
	
	
	
	
	// Awake()
	void Awake()
	{
		oSpriteRenderer = this.GetComponent<SpriteRenderer>();
		//   oSpriteRenderer = transform.GetComponent<SpriteRenderer> ();
		
		Debug.Log ("oSpriteRenderer : ( " + oSpriteRenderer + " )");
		
		oSpriteRenderer.sprite = (Sprite)catImages [0];
		
		Debug.Log ("catImages : " + catImages);
		
		// This section creates the colliders for this snake
		// First we need to instantiate the Dictionary.
		olFrameColliders = new Dictionary<int, PolygonCollider2D>();
		//////
		Debug.Log ("aImages.Length : ( " + catImages.Length + " )");
		// loop through each Sprite (image) in our Images array
		for(int index = 0; index < catImages.Length; index++)
		{
			Debug.Log ("Loop In");
			// switch to the current image we are processing
			oSpriteRenderer.sprite = catImages[index];
			Debug.Log ("oSpriteRenderer.sprite : ( " + catImages[index] + " ) ");
			
			// create the polygon collider and add it to the Dictionary
			olFrameColliders.Add(index, gameObject.AddComponent<PolygonCollider2D>());
			
			// disable the collider
			olFrameColliders[index].enabled = false;
			
			// set this as a Trigger.
			// May or may not apply to YOUR case depends on how you are doing collisions.
			olFrameColliders[index].isTrigger = true;
		}
		
		// Now initialize to the correct image the snake should start out displaying
		curFrame = 0;
		oldFrame = -1;
		Debug.Log ("curFrame : ( " + curFrame + " ) "); 
		oSpriteRenderer.sprite = catImages[curFrame];
		//   Debug.Log ("catImages[curFrame] : ( " + catImages [curFrame] + " )");
		
		// Enable the collider associated with the current frame
		EnableCollider(true);
		Debug.Log ("EnableCOllider 됨");
		
		
		
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		// if the current frame is different from the frame displayed last update
		if (curFrame != oldFrame)
		{
			
			
			Debug.Log ("Current Frame : " + curFrame + "/// Old Frame : " + oldFrame);
			
			
			// update the old frame to the current frame
			// so we can detect the next change in the image
			
			if(curFrame <8)
			{
				// display the current sprite (frame)
				oSpriteRenderer.sprite = catImages[curFrame];
				
				// enable the associated polygon collider
				EnableCollider(true);
				
				oldFrame = curFrame;
				curFrame++;
			}
			else
			{
				Debug.Log ("초기화됨 ");
				curFrame = 0;
				oldFrame = 7;
				EnableCollider(true);
			}
		}
		
	}
	
	void EnableCollider(bool TrueOrFalse)
	{
		
		//this.gameObject.GetComponent<PolygonCollider2D>
		if (oldFrame != -1) {
			Debug.Log ("/////////////////////////////////들어옴");
			// always disable the old collider
			olFrameColliders [oldFrame].enabled = false;
		}
		
		// enable or disable the current collider as requested
		olFrameColliders[curFrame].enabled = TrueOrFalse;
	} 
}