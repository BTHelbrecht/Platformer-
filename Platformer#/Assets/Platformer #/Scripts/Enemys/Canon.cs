// Jerard Carney
// 12.13.18
// Cannon.cs
// Cannon Controls

//Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// new use of headers for organising the inspector


// Public Class 
public class Canon : MonoBehaviour 
{
    // Public Variables
        // Facing of cannon, facing of ammo, spawn of ammo, time of firing.
    [Header("Settings")]
    public bool lookLeft = true;
    public GameObject ammoL;
    public GameObject ammoR;
    public Transform spawn;
    public float rateOfFire = 0.0f;

    // Private Variable
        // For rate of fire
    private float timer = 0.0f;

	void Update () 
    {
        // Canon aims left.
        if (lookLeft)
        {
            transform.localScale = new Vector2(1.0f, 1.0f);    
        }
        // Canon aims right.
        else
        {
            transform.localScale = new Vector2(-1.0f, 1.0f);    
        }


        // Shoots everytime the timer goes over the set rateOfFire.
        if (timer > rateOfFire)    
        {
            // Spawn ammo for left aim.
            if (lookLeft)
            {
                Instantiate(ammoL, new Vector2(spawn.position.x, spawn.position.y), Quaternion.identity);   
            }
            // Spawn ammo for right aim.
            else
            {
                Instantiate(ammoR, new Vector2(spawn.position.x, spawn.position.y), Quaternion.identity);   
            }

            // Resets timer to stop firing untile time timer gets to the rateOfFire value.
            timer = 0.0f;   
        }
	}

    void OnTriggerStay2D (Collider2D col)
    {
        // Only shoot if player is infront of canon and near by. Uses Colliders for this effect.
        if (col.tag == "Player")
        {
            timer += Time.deltaTime;    
        }
    }

    void OnTriggerExit2D (Collider2D col)
    {
        // Timmer starts when player enter proximity collider
        if (col.tag == "Player")
        {
            timer = 0.0f;
        }
    }
}
