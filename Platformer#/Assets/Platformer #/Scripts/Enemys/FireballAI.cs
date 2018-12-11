using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballAI : MonoBehaviour 
{
    [Header("Settings")]
    public float speed = 0.0f;
    public float lifeTime = 0.0f;

    private float timer = 0.0f;

	void Update () 
    {
        transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y);    //Move fireball.

        timer += Time.deltaTime;

        if (timer > lifeTime)
        {
            Destroy(gameObject);    //Destroy fireball after a set amount of time (lifeTime).
        }
	}

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.tag == "Player")
        {
            Destroy(gameObject);    //Destroy fireball when it hits the player.
        }
    }
}



/*
-------------------------------------------------------------------------
#################################
######### By SchrippleA #########
#################################
*/