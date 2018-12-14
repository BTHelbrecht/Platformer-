// Jerard Carney
// 12.13.18
// EnemyAI.cs
// Red blob enemy AI

//Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// new use of headers for organising the inspector


// Public Class
public class EnemyAI : MonoBehaviour 
{
    // Public Variable
        // Enemy speed, time of break/idle, and damage taken to player
    [Header("Settings")]
    public float speed = 0.0f;
    public int damage = 0;
    public float takeBreakFor = 0.0f;

        // Enemy animations
    [Header("Animations")]
    public GameObject idleAnimation;
    public GameObject moveAnimation;

    // Private Variables
        // Enemy Diraction facing, timer between idles, timer of idle amount
    private bool movingRight = false;
    private float timer = 0.0f;
    private float idleTimer = 0.0f;

    void Start ()                          
    {
        //Checks start values.
        timer = takeBreakFor;
        idleTimer = takeBreakFor * 1.5f;
    }

	void Update () 
    {
        //Move phase until the idleTimer hits <= 0.
        if (timer <= 0)                     
        {
            idleTimer -= Time.deltaTime;

            //Resets timers and restart the AI cycle.
            if (idleTimer <= 0)           
            {
                timer = takeBreakFor;
                idleTimer = takeBreakFor;
            }

            idleAnimation.SetActive(false);
            moveAnimation.SetActive(true);

            //Moves enemy right.
            if (movingRight)               
            {
                transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);

                idleAnimation.transform.localScale = new Vector2(1.0f, 1.0f);
                moveAnimation.transform.localScale = new Vector2(1.0f, 1.0f);
            }
            //Moves enemy left and looks left.
            else
            {
                transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y);

                idleAnimation.transform.localScale = new Vector2(-1.0f, 1.0f);
                moveAnimation.transform.localScale = new Vector2(-1.0f, 1.0f);
            }
        }
        //Idle phase until the timer hits <= 0.
        else
        {
            timer -= Time.deltaTime;

            idleAnimation.SetActive(true);
            moveAnimation.SetActive(false); 
        }
	}

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.tag == "Player")
        {
            //Player takes damage if hit.
            PlayerHp.s_hp -= damage;      
        }

        if (col.tag == "EnemyTurn")        
        {
            //Turns enemy if it walks through a turn zone.
            if (movingRight)
            {
                movingRight = false;
            }
            else
            {
                movingRight = true;
            }
        }
    }
}



/*
-------------------------------------------------------------------------
#################################
######### By SchrippleA #########
#################################
*/