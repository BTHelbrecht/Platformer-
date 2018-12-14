// Jerard Carney
// 12.13.18
// SmoothPlayerCam.cs
// Smooth Camera Movement

//Libraries
using UnityEngine;
using System.Collections;

/* 
I recently have found the use of headers,
this made organizing the inspector much easier and nicer to use.
I will be using this from now on and trying to make
all variable open to the user/developer.
*/

// Public Class
public class SmoothPlayerCam : MonoBehaviour 
{
    // Public Variables
        // Too change camera speed, and to set true or false for y/x axis
	static public float changeSpeedTo;
	static public bool lockXAxis;
	static public bool lockYAxis;

    // Camera variable settings, able to play with in INSPECTOR
    [Header("Settings")]
	public Transform player;
	public bool smoothCam = true;
	public bool blockX = false;
	public bool blockY = false;

    // Range of floats of how far the camera will move ahead of the player
	[Range(-25.0f, -2.0f)]
	public float distance = -10.0f;

    // Range of floats of how fast the camera will move with the player
	[Range(1.0f, 10.0f)]
	public float speed = 5.0f;

    // places vestor3 on player
	private Vector3 goHere;

    // On start assiegns all Variables
	void Start ()
	{												//Set the default values of this variables.
		changeSpeedTo = speed;
		lockXAxis = blockX;
		lockYAxis = blockY;
	}



    // On time update Update the new values of this variables.
    void FixedUpdate () 
	{												
		speed = changeSpeedTo;
		blockX = lockXAxis;
		blockY = lockYAxis;


        //Start smoothCamera.
        if (smoothCam)								
		{

            //Save player Xpos, use own Ypos and add the distance of the camera.
            //Move the camera to the goHere position.
            if (blockY)								
			{										
				goHere = new Vector3(player.position.x, transform.position.y, distance);
				transform.position = Vector3.Lerp(transform.position, goHere, Time.deltaTime * speed);					
			}

			if (blockX)
			{
				goHere = new Vector3(transform.position.x, player.position.y, distance);
				transform.position = Vector3.Lerp(transform.position, goHere, Time.deltaTime * speed);
			}

            //Don't block the X or Y axis. 
            if (!blockX & !blockY || blockX & blockY)
			{										
				goHere = new Vector3(player.position.x, player.position.y, distance);
				transform.position = Vector3.Lerp(transform.position, goHere, Time.deltaTime * speed);
			}
		}
        //No smooth movement.
        else
        {											
			goHere = new Vector3(player.position.x, player.position.y, distance);
			transform.position = new Vector3(player.position.x, player.position.y, goHere.z);
		}
	}
}
