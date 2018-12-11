using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillJump : MonoBehaviour 
{
    [Header("Settings")]
    public GameObject enemy;
    public int killPoints = 100;

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.tag == "PlayerDown")
        {
            PlayerCtrl.killBounce = true;       //Player bounces off enemy when jumping on top.
            GM.score += killPoints;             //Player reseives points for the kill.
            Destroy(enemy);                     //Destroys enemy.
        }
    }
}



/*
-------------------------------------------------------------------------
#################################
######### By SchrippleA #########
#################################
*/