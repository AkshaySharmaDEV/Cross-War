using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchJoystickRotation : MonoBehaviour
{
	public Joystick joystick;
	public GameObject Object;
	Vector2 GameobjectRotation;
	private float GameobjectRotation2;
	private float GameobjectRotation3;
    
	public RectTransform Handle;
	public RectTransform Target;


	public Shooting Fire;

	

	


	void Update()
	{
		//Gets the input from the jostick
		GameobjectRotation = new Vector2(joystick.Horizontal, joystick.Vertical);

		GameobjectRotation3 = GameobjectRotation.y;

		Object.transform.Rotate( 0f ,0f , GameobjectRotation3 * 5f, Space.World );


		

		float dist = Vector3.Distance(Handle.position, Target.position);

		Debug.Log(dist);

		if(dist >= 2 && dist <=3)
		{
			Fire.fire();
		}

		



		
	}

	
}