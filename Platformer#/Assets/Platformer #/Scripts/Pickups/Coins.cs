using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour 
{
    [Header("Settings")]
    public int points = 10;

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.tag == "Player")                    //If player touches this object then do this...
        {
            GM.score += points;                     //Gives player points.
            Destroy(gameObject);                    //Destorys this gameobject.
        }
    }
}



/*
-------------------------------------------------------------------------
#################################
######### By SchrippleA #########
#################################
*/