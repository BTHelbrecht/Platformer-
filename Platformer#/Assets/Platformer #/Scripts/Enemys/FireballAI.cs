// Jerard Carney
// 12.13.18
// FireballAI.cs
// Cannon Bullets

//Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// new use of headers for organising the inspector


// Public Class
public class FireballAI : MonoBehaviour 
{
    // Public Variables
        // Speed of bullet and time it stays active in game
    [Header("Settings")]
    public float speed = 0.0f;
    public float lifeTime = 0.0f;

    // Timer for lifespan of bullets
    private float timer = 0.0f;


	void Update () 
    {
        // Moves fireball.
        transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y); 

        // Timer based on actual time
        timer += Time.deltaTime;

        // Destroy fireball after a set amount of time (lifeTime).
        if (timer > lifeTime)
        {
            Destroy(gameObject);  
        }
	}

    void OnTriggerEnter2D (Collider2D col)
    {
        //Destroy fireball when it hits the player.
        if (col.tag == "Player")
        {
            Destroy(gameObject);   
        }
    }
}
