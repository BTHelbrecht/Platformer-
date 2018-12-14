// Jerard Carney
// 12.13.18
// Coins.cs
// Collecting Coins

//Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Used Headers for a more organized inspector

// Public Class
public class Coins : MonoBehaviour 
{
    // Public Variable
        // Values each coin at 10 points
    [Header("Settings")]
    public int points = 10;

    void OnTriggerEnter2D (Collider2D col)
    {
        //If player touches this object then do this...
        if (col.tag == "Player")                   
        {
            //Gives player points.
            GM.score += points;
            //Destorys this gameobject.
            Destroy(gameObject);                   
        }
    }
}
