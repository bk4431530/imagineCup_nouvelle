using UnityEngine;
using System.Collections;

public class TouchHandler : MonoBehaviour {

	public static bool swiped;

	Vector3 point;

	
	private Touch initialTouch = new Touch();
	
	
	void Start()
	{	
		
	}



	void Update()
	{
		//PC

		if (Input.GetMouseButtonUp(0)) 
		{				
			swiped = true;		
		}//click



		



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
				float deltaX = initialTouch.position.x - Input.mousePosition.x;
				float deltaY = initialTouch.position.y - Input.mousePosition.y;
				//distanxe fomula
				float distance = Mathf.Sqrt((deltaX*deltaX) + (deltaY*deltaY));
				
				
				bool swipedSideways = Mathf.Abs(deltaX) > Mathf.Abs(deltaY);
				
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
