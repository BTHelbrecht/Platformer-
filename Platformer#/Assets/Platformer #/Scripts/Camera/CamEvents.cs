using UnityEngine;
using System.Collections;

public class CamEvents : MonoBehaviour 
{
    [Header("Settings")]
	public bool changeSpeed = false;
	public bool lockXAxis = false;
	public bool lockYAxis = false;

	[Range(1.0f, 10.0f)]
	public float newSpeed = 0.0f;

	void OnTriggerEnter2D (Collider2D col)
	{
		if(col.tag == "Player")										//If object with tag "Player" hits this.
		{
			if(changeSpeed)
			{
				SmoothPlayerCam.changeSpeedTo = newSpeed;			//Change cam speed.
			}

			SmoothPlayerCam.lockXAxis = lockXAxis;					//Lock/Unlock cam X axis.
			SmoothPlayerCam.lockYAxis = lockYAxis;					//Lock/Unlock cam Y axis.
		}
	}
}



/*
-------------------------------------------------------------------------
#################################
######### By SchrippleA #########
#################################
*/