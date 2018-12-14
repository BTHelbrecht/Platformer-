// Jerard Carney
// 12.13.18
// CamEvents.cs
// Colliders for camera movement halts

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
public class CamEvents : MonoBehaviour 
{
    // Public Variables
    // // Too change camera speed, and to set true or false for y/x axis
    [Header("Settings")]
	public bool changeSpeed = false;
	public bool lockXAxis = false;
	public bool lockYAxis = false;

    // Range to assigne float new speed when player is in collider. an otpion in inspector
	[Range(1.0f, 10.0f)]
	public float newSpeed = 0.0f;

	void OnTriggerEnter2D (Collider2D col)
	{
        //If object with tag "Player" hits this.
        if (col.tag == "Player")										
		{
            //Change cam speed.
            if (changeSpeed)
			{
				SmoothPlayerCam.changeSpeedTo = newSpeed;			
			}

            //Lock/Unlock cam X axis.
            SmoothPlayerCam.lockXAxis = lockXAxis;
            //Lock/Unlock cam Y axis.
            SmoothPlayerCam.lockYAxis = lockYAxis;					
		}
	}
}
