using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour 
{
    [Header("Settings")]
    public float speed = 0.0f;
    public int damage = 0;
    public float takeBreakFor = 0.0f;

    [Header("Animations")]
    public GameObject idleAnimation;
    public GameObject moveAnimation;

    private bool movingRight = false;
    private float timer = 0.0f;
    private float idleTimer = 0.0f;

    void Start ()                           //Checks start values.
    {
        timer = takeBreakFor;
        idleTimer = takeBreakFor * 1.5f;
    }

	void Update () 
    {
        if (timer <= 0)                     //Move phase until the idleTimer hits <= 0.
        {
            idleTimer -= Time.deltaTime;

            if (idleTimer <= 0)             //Resets timers and restart the AI cycle.
            {
                timer = takeBreakFor;
                idleTimer = takeBreakFor;
            }

            idleAnimation.SetActive(false);
            moveAnimation.SetActive(true); 

            if (movingRight)                //Moves enemy right.
            {
                transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);

                idleAnimation.transform.localScale = new Vector2(1.0f, 1.0f);
                moveAnimation.transform.localScale = new Vector2(1.0f, 1.0f);
            }
            else                            //Moves enemy left and looks left.
            {
                transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y);

                idleAnimation.transform.localScale = new Vector2(-1.0f, 1.0f);
                moveAnimation.transform.localScale = new Vector2(-1.0f, 1.0f);
            }
        }
        else                                //Idle phase until the timer hits <= 0.
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
            PlayerHp.s_hp -= damage;        //Player takes damage if hit.
        }

        if (col.tag == "EnemyTurn")         //Turns enemy if it walks through a turn zone.
        {
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