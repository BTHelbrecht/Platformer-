using UnityEngine;
using System.Collections;

public class SmoothPlayerCam : MonoBehaviour 
{
	static public float changeSpeedTo;
	static public bool lockXAxis;
	static public bool lockYAxis;

    [Header("Settings")]
	public Transform player;
	public bool smoothCam = true;
	public bool blockX = false;
	public bool blockY = false;

	[Range(-25.0f, -2.0f)]
	public float distance = -10.0f;

	[Range(1.0f, 10.0f)]
	public float speed = 5.0f;

	private Vector3 goHere;

	void Start ()
	{												//Set the default values of this variables.
		changeSpeedTo = speed;
		lockXAxis = blockX;
		lockYAxis = blockY;
	}

	void FixedUpdate () 
	{												//Update the new values of this variables.
		speed = changeSpeedTo;
		blockX = lockXAxis;
		blockY = lockYAxis;

		if (smoothCam)								//Start smoothCamera.
		{
			if (blockY)								//Save player Xpos, use own Ypos and add the distance of the camera.
			{										//Move the camera to the goHere position.
				goHere = new Vector3(player.position.x, transform.position.y, distance);
				transform.position = Vector3.Lerp(transform.position, goHere, Time.deltaTime * speed);					
			}

			if (blockX)
			{
				goHere = new Vector3(transform.position.x, player.position.y, distance);
				transform.position = Vector3.Lerp(transform.position, goHere, Time.deltaTime * speed);
			}

			if (!blockX & !blockY || blockX & blockY)
			{										//Don't block the X or Y axis.
				goHere = new Vector3(player.position.x, player.position.y, distance);
				transform.position = Vector3.Lerp(transform.position, goHere, Time.deltaTime * speed);
			}
		}
		else
		{											//No smooth movement.
			goHere = new Vector3(player.position.x, player.position.y, distance);
			transform.position = new Vector3(player.position.x, player.position.y, goHere.z);
		}
	}
}



/*
-------------------------------------------------------------------------
#################################
######### By SchrippleA #########
#################################
*/