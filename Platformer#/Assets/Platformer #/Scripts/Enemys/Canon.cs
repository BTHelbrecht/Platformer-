using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour 
{
    [Header("Settings")]
    public bool lookLeft = true;
    public GameObject ammoL;
    public GameObject ammoR;
    public Transform spawn;
    public float rateOfFire = 0.0f;

    private float timer = 0.0f;

	void Update () 
    {
        if (lookLeft)
        {
            transform.localScale = new Vector2(1.0f, 1.0f);     //Canon aims left.
        }
        else
        {
            transform.localScale = new Vector2(-1.0f, 1.0f);    //Canon aims right.
        }

        if (timer > rateOfFire)     //Shoots everytime the timer goes over the set rateOfFire.
        {
            if (lookLeft)
            {
                Instantiate(ammoL, new Vector2(spawn.position.x, spawn.position.y), Quaternion.identity);   //Spawn ammo for left aim.
            }
            else
            {
                Instantiate(ammoR, new Vector2(spawn.position.x, spawn.position.y), Quaternion.identity);   //Spawn ammo for right aim.
            }

            timer = 0.0f;   //Resets timer to stop firing untile time timer gets to the rateOfFire value.
        }
	}

    void OnTriggerStay2D (Collider2D col)
    {
        if (col.tag == "Player")
        {
            timer += Time.deltaTime;    //Only shoot if player is infront of canon and near by.
        }
    }

    void OnTriggerExit2D (Collider2D col)
    {
        if (col.tag == "Player")
        {
            timer = 0.0f;
        }
    }
}



/*
-------------------------------------------------------------------------
#################################
######### By SchrippleA #########
#################################
*/