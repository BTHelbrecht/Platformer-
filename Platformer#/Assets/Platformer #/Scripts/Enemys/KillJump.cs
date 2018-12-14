// Jerard Carney
// 12.13.18
// KillJump.cs
// Player jump on enemy 

//Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// new use of headers for organising the inspector


// Public Class
public class KillJump : MonoBehaviour 
{
    // Public Variables
        // Gets the enemy game object, and assigns 100 points to kill value
    [Header("Settings")]
    public GameObject enemy;
    public int killPoints = 100;


    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.tag == "PlayerDown")
        { 
            // Player bounces off enemy when jumping on top.
            PlayerCtrl.killBounce = true;
            // Player reseives points for the kill.
            GM.score += killPoints;
            // Destroys enemy.
            Destroy(enemy);                    
        }
    }
}
