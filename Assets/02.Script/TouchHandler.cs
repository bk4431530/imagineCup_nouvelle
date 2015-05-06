using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TouchHandler : MonoBehaviour {
	
	//line
	private LineRenderer lineRenderer;
	private int i = 0;
	
	//touch
	
	private Touch initialTouch = new Touch();
	
	
	
	public static bool Mswiped =false;
	public static bool Bswiped =false;
	
	
	public static int speedLevel =0;
	
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
			Mswiped=false;
			Bswiped=false;


		}
		else
		{	
			Mswiped =false;
			Bswiped=false;

			numberOfPoints = 0;
			lineRenderer.SetVertexCount(0);
		}


		deltaX = initialMPos.x - Input.mousePosition.x;
		deltaY = initialMPos.y - Input.mousePosition.y;
		distance = Mathf.Sqrt((deltaX*deltaX) + (deltaY*deltaY));
		swipedSideways = Mathf.Abs(deltaX) > Mathf.Abs(deltaY);


		if (numberOfPoints == 0) {
			initialMPos = Input.mousePosition;
		} 
		else if (swipedSideways && deltaX <= 0  && deltaY <= 0) {
			Mswiped =true;

		}else if(swipedSideways && deltaX > 0 && deltaY > 0){
			Bswiped=true;

		}




		//android
		if (Input.touchCount > 0) 
		{
			Touch touch = Input.GetTouch (0);
			
			if (touch.phase == TouchPhase.Began) 
			{
				Mswiped = false;
				Bswiped = false;
				
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
				
				if(distance >100f){
					if (swipedSideways && deltaX > 0) 
					{ //swiped left
						Bswiped = true;
						
					} 
					else if (swipedSideways && deltaX <= 0 ) 
					{//swiped right
						Mswiped = true;
						
					} 
					else if (!swipedSideways && deltaY > 0) 
					{//swiped down
					} 
					else if (!swipedSideways && deltaY <= 0) 
					{//swiped up
					}
				}
				
			}
			
			if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Stationary) 
			{
				Mswiped = false;
				Bswiped = false;
				
				initialTouch = new Touch ();
				lineRenderer.SetVertexCount (0);
				i = 0;
				
			}
		}
		//andrroid

	}
}




