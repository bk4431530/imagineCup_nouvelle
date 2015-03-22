using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TouchHandler : MonoBehaviour {
	
	//line
	private LineRenderer lineRenderer;
	private int i = 0;
	
	//touch
	public static bool swipe =false; 
	public static bool swiped=false; 
	private Touch initialTouch = new Touch();
	
	
	
	public static bool Mswiped =false;

	
	Vector3 initialMPos;
	private int numberOfPoints = 0;
	
	float deltaX;
	float deltaY;
	float distance;
	float jdistance;
	bool swipedSideways;

	void Start()
	{	
		lineRenderer = GameObject.Find ("lineRenderer").GetComponent<LineRenderer> ();
		lineRenderer.SetVertexCount(0);
		
	}
	

	void Update()
	{

		if(Input.GetMouseButton(0))
		{
			numberOfPoints++;
			lineRenderer.SetVertexCount( numberOfPoints );
			Vector3 mousePos = new Vector3(0,0,0);
			mousePos = Input.mousePosition;
			mousePos.z = 1.0f;
			Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
			lineRenderer.SetPosition(numberOfPoints - 1, worldPos);
			
		}else if(Input.GetMouseButtonUp(0))
		{
			Mswiped=true;
		}
		else
		{	
			Mswiped =false;
			numberOfPoints = 0;
			lineRenderer.SetVertexCount(0);
		}


		/*
		 //PC swipe 
		 deltaX = initialMPos.x - Input.mousePosition.x;
		 deltaY = initialMPos.y - Input.mousePosition.y;
		distance = Mathf.Sqrt((deltaX*deltaX) + (deltaY*deltaY));

		if (numberOfPoints == 0) {
			initialMPos = Input.mousePosition;
		} 
*/
	



		/*
		//android
		if (Input.touchCount > 0) 
		{
			Touch touch = Input.GetTouch (0);
			
			if (touch.phase == TouchPhase.Began) 
			{
				Mswiped = false;
				jdistance =10000;
				initialTouch = touch;

			} 
			else if (touch.phase == TouchPhase.Moved) 
			{
				lineRenderer.SetVertexCount(i+1);
				Vector3 mPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
				lineRenderer.SetPosition(i, Camera.main.ScreenToWorldPoint(mPosition));
				i++;
				
				
				deltaX = initialTouch.position.x - Input.mousePosition.x;
				deltaY = initialTouch.position.y - Input.mousePosition.y;
				//distanxe fomula
				distance = Mathf.Sqrt((deltaX*deltaX) + (deltaY*deltaY));
				
				
				swipedSideways = Mathf.Abs(deltaX) > Mathf.Abs(deltaY);
				
				if (swipedSideways && deltaX > 0) 
				{ //swiped left
				} 
				else if (swipedSideways && deltaX <= 0 ) 
				{//swiped right
					if(distance < jdistance && distance > 10f)
					{
						Mswiped = true;
						jdistance = distance;
					}else if(distance > jdistance){
						Mswiped = false;
					}
				} 
				else if (!swipedSideways && deltaY > 0) 
				{//swiped down
				} 
				else if (!swipedSideways && deltaY <= 0) 
				{//swiped up
				}
				
				
			}
			
			if (touch.phase == TouchPhase.Ended) 
			{
				Mswiped = false;
				initialTouch = new Touch ();
				lineRenderer.SetVertexCount (0);
				i = 0;
				
			}
		}
		//andrroid
		*/
	}
}