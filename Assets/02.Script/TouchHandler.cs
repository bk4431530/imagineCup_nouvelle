using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TouchHandler : MonoBehaviour {
	
	private bool swiped =false;
	public static bool Mswiped =false;
	
	private Touch initialTouch = new Touch();
	private float deltaX;
	private float deltaY;
	private float distance;
	private bool swipedSideways;
	
	Vector2 initialPos;

	
	private LineRenderer lineRender;
	private int numberOfPoints = 0;
	
	void Start()
	{	
		lineRender = GameObject.Find ("lineRenderer").GetComponent<LineRenderer> ();
	}


	void Update()
	{
		//distanxe fomula
		distance = Mathf.Sqrt((deltaX*deltaX) + (deltaY*deltaY));
		swipedSideways = Mathf.Abs(deltaX) > Mathf.Abs(deltaY);
		
		
		//PC


		
		
		if(swiped == true || Input.GetMouseButton(0))
		{
			numberOfPoints++;
			lineRender.SetVertexCount( numberOfPoints );
			Vector3 mousePos = new Vector3(0,0,0);
			mousePos = Input.mousePosition;
			mousePos.z = 1.0f;
			Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
			lineRender.SetPosition(numberOfPoints - 1, worldPos);
			
		}else if(Input.GetMouseButtonUp(0)){
			Mswiped = true;
		}
		else{	
			Mswiped =false;
			numberOfPoints = 0;
			lineRender.SetVertexCount(0);
		}
		
		
		
		
		
		
		

		//Android
		if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.WP8Player)
		{
			if (Input.touchCount > 0)
			{
				Touch touch = Input.GetTouch(0);
				
				if(touch.phase == TouchPhase.Began){
					initialTouch = touch;
					Mswiped =false;
				}
				
				else if(touch.phase == TouchPhase.Moved)
				{
					deltaX = initialTouch.position.x - Input.mousePosition.x;
					deltaY = initialTouch.position.y - Input.mousePosition.y;
					
					
					if(distance > 100f)
					{
						
						if(swipedSideways && deltaX > 0)
						{ //swiped left
						}
						else if(swipedSideways && deltaX <=0)
						{//swiped right
							swiped =true;
							Mswiped = false;
						}
						else if(!swipedSideways && deltaY >0)
						{//swiped down
						}
						else if(!swipedSideways && deltaY <=0)
						{//swiped up
						}
						
					}//swipe 100
				}//moved
				
				
				if(touch.phase == TouchPhase.Ended)
				{
					initialTouch = new Touch();
					swiped = false;
					Mswiped =true;
				}//Ended
				
			}//touch count >0
		}//android
	}//update
	
}//class
