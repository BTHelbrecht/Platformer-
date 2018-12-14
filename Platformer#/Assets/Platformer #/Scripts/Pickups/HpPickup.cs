// Jerard Carney
// 12.13.18
// HpPickup.cs
// Health system

//Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Used Headers for a more organized inspector


// Public Class
public class HpPickup : MonoBehaviour 
{
    // Public Variables
        // Values for max slots aloud and hp gained
    [Header("Settings")]
    public int addHp = 0;
    public int addSlot = 0;

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.tag == "Player")
        {
            //Adds the empty heartslots to player when collected.
            PlayerHp.s_maxHearts += addSlot;
            //Adds the hps to player when collected.
            PlayerHp.s_hp += addHp;
            //Destroys this object when collected.
            Destroy(gameObject);                    
        }
    }
}