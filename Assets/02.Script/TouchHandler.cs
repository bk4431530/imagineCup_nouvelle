using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TouchHandler : MonoBehaviour {
	
	public static bool swiped;

	
	private Touch initialTouch = new Touch();
	private float deltaX;
	private float deltaY;
	private float distance;
	private bool swipedSideways;
	
	
	
	Vector2 initialPos;



	void Update()
	{
		//distanxe fomula
		distance = Mathf.Sqrt((deltaX*deltaX) + (deltaY*deltaY));
		swipedSideways = Mathf.Abs(deltaX) > Mathf.Abs(deltaY);
		
		
		//PC
		if (Input.GetMouseButtonDown(0)) 
		{
			
		}//mouseButton
		
		if (Input.GetMouseButton (0)) 
		{
			deltaX = initialPos.x - Input.mousePosition.x;
			deltaY = initialPos.y - Input.mousePosition.y;
			
			if(distance >100f){
				if(swipedSideways && deltaX <=0)
				{//swiped right
					swiped =true;
				}
				
			}
		}//button pressed
		
		if (Input.GetMouseButtonUp(0))
		{
			swiped =false;
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		//Android
		if (Application.platform == RuntimePlatform.Android)
		{
			if (Input.touchCount > 0)
			{
				Touch touch = Input.GetTouch(0);
				
				if(touch.phase == TouchPhase.Began){
					initialTouch = touch;
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
					
					
				}//Ended
				
			}//touch count >0
		}//android
	}//update
	
}//class
