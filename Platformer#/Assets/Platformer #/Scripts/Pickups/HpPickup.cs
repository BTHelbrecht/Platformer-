using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpPickup : MonoBehaviour 
{
    [Header("Settings")]
    public int addHp = 0;
    public int addSlot = 0;

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.tag == "Player")
        {
            PlayerHp.s_maxHearts += addSlot;        //Adds the empty heartslots to player when collected.
            PlayerHp.s_hp += addHp;                 //Adds the hps to player when collected.
            Destroy(gameObject);                    //Destroys this object when collected.
        }
    }
}



/*
-------------------------------------------------------------------------
#################################
######### By SchrippleA #########
#################################
*/