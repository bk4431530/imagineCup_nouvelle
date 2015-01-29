using UnityEngine;
using System.Collections;

public class TouchHandler : MonoBehaviour {

	public Color c1 = Color.yellow;
	public Color c2 = Color.red;
	
	private GameObject lineGO;
	private LineRenderer lineRenderer;
	private int i = 0;
	
	public static bool swiped; 


	
	private Touch initialTouch = new Touch();
	
	
	void Start()
	{
		//ready for draw line
		lineGO = new GameObject("Line");
		lineGO.AddComponent<LineRenderer>();
		lineRenderer = lineGO.GetComponent<LineRenderer>();
		lineRenderer.material = new Material(Shader.Find("Mobile/Particles/Additive"));
		lineRenderer.SetColors(c1, c2);
		lineRenderer.SetWidth(0.1F, 0);
		lineRenderer.SetVertexCount(0);
		
		
	}
	
	void Update()
	{
		
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);
			
			if(touch.phase == TouchPhase.Began){
				initialTouch = touch;
			}

			else if(touch.phase == TouchPhase.Moved)
			{
				lineRenderer.SetVertexCount(i+1);
				Vector3 mPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -2);
				lineRenderer.SetPosition(i, Camera.main.ScreenToWorldPoint(mPosition));
				i++;
				
				
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
						swiped = true;
					}
					else if(!swipedSideways && deltaY >0)
					{//swiped down
					}
					else if(!swipedSideways && deltaY <=0)
					{//swiped up
					}
					
				}
				
			}
			
			
			if(touch.phase == TouchPhase.Ended)
			{
				initialTouch = new Touch();
				swiped = false;
				lineRenderer.SetVertexCount(0);
				i = 0;
				
			}
			
		}
	}
}
