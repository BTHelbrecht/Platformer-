// Jerard Carney
// 12.13.18
// HarmfullObjects.cs
// Instant death objects

//Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// new use of headers for organising the inspector


// Public Class
public class HarmfullObject : MonoBehaviour 
{
    // Public variables
        // For tracking damage to player in game
    [Header("Settings")]
    public int damage = 0;

    
    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.tag == "Player")
        {
            //Player takes damage when hit by red  enemies only not cannons... just their bullets
            PlayerHp.s_hp -= damage;        
        }
    }
}
