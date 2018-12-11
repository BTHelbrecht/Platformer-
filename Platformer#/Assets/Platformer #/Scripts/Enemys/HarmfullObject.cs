using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarmfullObject : MonoBehaviour 
{
    [Header("Settings")]
    public int damage = 0;

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.tag == "Player")
        {
            PlayerHp.s_hp -= damage;        //Player takes damage when hit.
        }
    }
}



/*
-------------------------------------------------------------------------
#################################
######### By SchrippleA #########
#################################
*/