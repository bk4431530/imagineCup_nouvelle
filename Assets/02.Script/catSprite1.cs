using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum CatState
{
	Normal,
	Catch
}

public class catSprite1 : CatchedbyCat1 {
	
	public CatState catState = CatState.Normal; //cat state default
	
	public Sprite[] catImages;
	
	public Dictionary<int, PolygonCollider2D> olFrameColliders;
	
	public int curFrame;
	public int oldFrame;
	
	private SpriteRenderer oSpriteRenderer;
	
	public float d_time = 0.147f;
	
	
	
	
	// Awake()
	void Awake()
	{
		CreateSprite ();
		
		// Enable the collider associated with the current frame
		
		EnableCollider(true);
		Debug.Log ("EnableCollider 됨");
		
	}
	
	
	void CreateSprite()
	{
		oSpriteRenderer = this.GetComponent<SpriteRenderer>();
		
		oSpriteRenderer.sprite = (Sprite)catImages [0];
		
		olFrameColliders = new Dictionary<int, PolygonCollider2D>();
		
		
		
		for(int index = 0; index < catImages.Length; index++)
		{
			
			oSpriteRenderer.sprite = catImages[index];
			
			olFrameColliders.Add(index, gameObject.AddComponent<PolygonCollider2D>());
			
			//         Debug.Log (olFrameColliders[index]);
			
			olFrameColliders[index].enabled = false;
			
			olFrameColliders[index].isTrigger = true;
		}
		
		curFrame = 0;
		oldFrame = -1;
		Debug.Log ("cur Frame : " + curFrame + " / oldFrame : " + oldFrame);
		
		oSpriteRenderer.sprite = catImages[curFrame];
		
	}
	
	void EnableCollider(bool TrueOrFalse)
	{
		
		if(oldFrame > -1)
		{   
			// always disable the old collider
			olFrameColliders[oldFrame].enabled = false;
		}
		
		// enable or disable the current collider as requested
		olFrameColliders[curFrame].enabled = TrueOrFalse;
		
		
	} 
	
	
	
	
	// Use this for initialization
	void Start () {
		InvokeRepeating("ChangeSprite", d_time, d_time);
	}
	
	
	// Update is called once per frame
	void Update () {
	}
	
	
	void ChangeSprite ()
	{
		//////////////////State 변경////////////////
		if(CatchedbyCat2.clickCount == 3)
		{
			catState = CatState.Normal;
			
			Debug.Log ("clickCount = " + CatchedbyCat2.clickCount);
			
		}
		
		// if the current frame is different from the frame displayed last update
		if (curFrame != oldFrame)
		{
			
			if(curFrame < catImages.Length)
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
				//            Debug.Log ("초기화됨 ");
				/*
				curFrame = 0;
				oldFrame = catImages.Length-1;
				*/
				curFrame = oldFrame;
			}
		}
		
	}
	
	
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.collider2D.name == "player")
		{
			catState = CatState.Catch;
			
		}
	}
	
}